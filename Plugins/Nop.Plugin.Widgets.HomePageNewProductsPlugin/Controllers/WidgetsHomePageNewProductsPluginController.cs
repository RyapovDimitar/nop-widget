using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Plugin.Widgets.HomePageNewProductsPlugin.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsHomePageNewProductsPluginController : BasePluginController
    {

        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsHomePageNewProductsPluginController(ISettingService settingsService,
            IStoreContext storeContext)
        {
            _settingService = settingsService;
            _storeContext = storeContext;
        }

        public IActionResult Configure()
        {
            //var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            //var newWidgetSettings = _settingService.LoadSetting<NewWidgetSettings>(storeScope);
            var newWidgetSettings = _settingService.LoadSetting<HomePageNewProductsPluginSettings>();
            var model = new ConfigurationModel();
            model.NumberOfProducts = newWidgetSettings.NumberOfProducts;
            var availableWidgetZones = new List<SelectListItem>();
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBeforeBestSellers),
                Value = PublicWidgetZones.HomepageBeforeBestSellers
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBeforeCategories),
                Value = PublicWidgetZones.HomepageBeforeCategories
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBeforeNews),
                Value = PublicWidgetZones.HomepageBeforeNews
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBeforePoll),
                Value = PublicWidgetZones.HomepageBeforePoll
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBeforeProducts),
                Value = PublicWidgetZones.HomepageBeforeProducts
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageBottom),
                Value = PublicWidgetZones.HomepageBottom
            });
            availableWidgetZones.Add(new SelectListItem()
            {
                Text = nameof(PublicWidgetZones.HomepageTop),
                Value = PublicWidgetZones.HomepageTop,
                Selected = true
            });
            model.AvailableWidgetZones = availableWidgetZones;


            return View("~/Plugins/Widgets.HomePageNewProductsPlugin/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            HomePageNewProductsPluginSettings settings = new HomePageNewProductsPluginSettings()
            {
                NumberOfProducts = model.NumberOfProducts,
                WidgetZone = model.WidgetZone
            };

            _settingService.SaveSetting<HomePageNewProductsPluginSettings>(settings);

            //now clear settings cache
            _settingService.ClearCache();

            return Configure();
        }
    }
}
