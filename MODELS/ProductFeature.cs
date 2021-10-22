using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ProductFeature : CommonProps
    {
        public string FeatureName { get; set; } //Ex:Color, Size etc
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<ProductFeatureDetail> ProductFeatureDetails { get; set; }
    }
}
