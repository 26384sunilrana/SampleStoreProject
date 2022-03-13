using Store.Project.Model.Interface;

namespace Store.Project.Model.Implementation
{
    public class CustomProductInformation : ICustomProductInformation
    {
        public string Name { get; set; }
        public string Ean { get; set; }
        public string CdnUrl { get ; set; }
    }
}
