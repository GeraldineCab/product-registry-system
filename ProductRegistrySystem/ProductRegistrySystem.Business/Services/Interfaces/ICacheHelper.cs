namespace ProductRegistrySystem.Business.Services.Interfaces
{
    public interface ICacheHelper
    {
        /// <summary>
        /// Retrieves status from cache
        /// </summary>
        /// <returns>The product status</returns>
        int GetStatusFromCache(int productId);
    }
}
