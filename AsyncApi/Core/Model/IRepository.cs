namespace AsyncApi.Core.Model;

public interface IRepository<TEntity, in TIdentity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TIdentity id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task PatchAsync(string propertyName, object value);
    Task DeleteByIdAsync(TIdentity identity);
}