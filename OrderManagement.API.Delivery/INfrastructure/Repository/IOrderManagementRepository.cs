namespace OrderManagement.API.Delivery.INfrastructure.Repository
{
    public interface IOrderManagementRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllOrderAsync();
        Task<TEntity> GetOrderByCustomerIdAsync(Guid id);
        Task AddOrderAsync(TEntity entity);
        Task UpdateOrderAsync(TEntity entity);
        Task DeleteOrderAsync(Guid id);

    }
}
