using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin
{
    public class HomePageNewProductsPluginSettings : ISettings
    {
        public int NumberOfProducts { get; set; }

        public string WidgetZone { get; set; }
    }
}
