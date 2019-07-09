using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public List<SelectListItem> AvailableWidgetZones { get; set; }
        public int NumberOfProducts { get; set; }

        public string WidgetZone { get; set; }
        public bool NumberOfProducts_OverrideForStore { get; set; }
    }
}
