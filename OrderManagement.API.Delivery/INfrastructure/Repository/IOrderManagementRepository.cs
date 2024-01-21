namespace OrderManagement.API.Delivery.INfrastructure.Repository
{
    public interface IOrderManagementRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllOrderAsync();

    }
}
