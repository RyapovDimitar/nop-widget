using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin
{
    public class HomePageNewProductsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        public HomePageNewProductsPlugin(IWebHelper webHelper,
            ISettingService settingsService)
        {
            _webHelper = webHelper;
            _settingService = settingsService;
        }

        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "New Products On Homepage";
        }

        public IList<string> GetWidgetZones()
        {
            var widgetSettings = _settingService.LoadSetting<HomePageNewProductsPluginSettings>();
            var widgetZone = _settingService.LoadSetting<HomePageNewProductsPluginSettings>().WidgetZone;
            if (string.IsNullOrEmpty(widgetZone))
            {
                widgetZone = PublicWidgetZones.HomepageTop;
                widgetSettings.WidgetZone = widgetZone;
                _settingService.SaveSetting<HomePageNewProductsPluginSettings>(widgetSettings);
            }
            return new List<string>
            {
                widgetZone
            };
            //return new List<string> { PublicWidgetZones.HomepageTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsHomePageNewProductsPlugin/Configure";
        }
    }
}
