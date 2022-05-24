namespace AsyncApi.Core.Model;

public interface IRepository<TEntity, in TIdentity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken);
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken);
    Task DeleteByIdAsync(TIdentity identity, CancellationToken cancellationToken);
}