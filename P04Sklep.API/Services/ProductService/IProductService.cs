using P05Sklep.Shared;

namespace P04Sklep.API.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceReponse<Product[]>> GetProductAsync();
    }
}
