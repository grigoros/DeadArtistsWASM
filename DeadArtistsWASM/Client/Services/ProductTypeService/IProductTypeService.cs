namespace DeadArtistsWASM.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;
        public List<ProductType> ProductTypes { get; set; }
        public List<ProductType> AdminProductTypes { get; set; }
        Task GetProductTypes();
        Task GetAdminProductTypes();
        Task AddProductType(ProductType productType);
        Task UpdateProductType(ProductType productType);
        Task DeleteProductType(int productTypeId);
        ProductType CreateNewProductType();
    }
}
