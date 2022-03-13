namespace Store.Project.Model.Interface
{
    public interface ICustomProductInformation
    {
        public string Name { get; set; }
        public string Ean { get; set; }
        public string CdnUrl { get; set; }
    }
}
