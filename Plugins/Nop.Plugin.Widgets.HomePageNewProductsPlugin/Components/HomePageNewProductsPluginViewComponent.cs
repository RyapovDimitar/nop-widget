using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.HomePageNewProductsPlugin.Models;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using System;
using System.Linq;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin.Components
{
    [ViewComponent(Name = "New Products On Homepage")]
    public class HomePageNewProductsPluginViewComponent : NopViewComponent
    {
        public const string PICTURE_URL_MODEL_KEY = "Nop.plugins.widgets.homepagenewproductsplugin.pictureurl-{0}-{1}";
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IWebHelper _webHelper;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IProductModelFactory _productModelFactory;

        public HomePageNewProductsPluginViewComponent(
            IProductService productService,
            IStaticCacheManager cacheManager,
            IWebHelper webHelper,
            IPictureService pictureService,
            ISettingService settingsService,
            IProductModelFactory productModelFactory)
        {
            _productService = productService;
            _cacheManager = cacheManager;
            _webHelper = webHelper;
            _pictureService = pictureService;
            _settingService = settingsService;
            _productModelFactory = productModelFactory;
        }

        public IViewComponentResult Invoke(int? productThumbPictureSize)
        {
            //load products
            var products = _productService.GetAllProducts();
            //availability dates
            var numberOfProducts = _settingService.LoadSetting<HomePageNewProductsPluginSettings>().NumberOfProducts;
            products = products.Where(p => _productService.ProductIsAvailable(p))
                .OrderByDescending(p => p.CreatedOnUtc).Take(numberOfProducts).ToList();

            if (!products.Any())
                return Content("No products found");

            //prepare model
            var model = new PublicInfoModel();
            model.Products = products;

            model.ProductModels = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            return View("~/Plugins/Widgets.HomePageNewProductsPlugin/Views/PublicInfo.cshtml", model);
            //return View(model);
        }

        protected string GetPictureUrl(int pictureId)
        {
            var cacheKey = string.Format(PICTURE_URL_MODEL_KEY,
                pictureId, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

            return _cacheManager.Get(cacheKey, () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = _pictureService.GetPictureUrl(pictureId, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
