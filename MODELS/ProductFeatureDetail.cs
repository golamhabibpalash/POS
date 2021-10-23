using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class ProductFeatureDetail : CommonProps
    {
        public string FeatureDetailName { get; set; }
        public string FeatureDetailValue { get; set; }
        public int ProductFeatureId { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}
