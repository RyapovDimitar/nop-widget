using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Catalog;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.HomePageNewProductsPlugin.Models
{
    public class PublicInfoModel : BaseNopModel
    {
        public IList<Product> Products { get; set; }

        public IList<ProductOverviewModel> ProductModels { get; set; }
    }
}
