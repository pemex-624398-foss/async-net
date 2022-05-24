using System.Data;
using AsyncApi.Core.Model;

namespace AsyncApi.Infrastructure.Database.Repositories;

public class DbRepository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class
{
    protected DbRepository(IDbConnectionFactory connectionFactory, string connectionKey)
    {
        ConnectionFactory = connectionFactory;
        ConnectionKey = connectionKey;
    }

    protected DbRepository(IDbTransaction transaction)
    {
        Transaction = transaction;
    }
    
    protected IDbConnectionFactory? ConnectionFactory { get; }
    protected string? ConnectionKey { get; }
    protected IDbTransaction? Transaction { get; }
    
    protected IDbConnection GetConnection() =>
        Transaction?.Connection
        ?? ConnectionFactory?.GetConnection(ConnectionKey!) 
        ?? throw new InvalidOperationException();

    public virtual Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
    
    public virtual Task InsertAsync(TEntity entity, CancellationToken cancellationToken) 
    {
        throw new NotSupportedException();
    }

    public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken) 
    {
        throw new NotSupportedException();
    }
    
    public virtual Task PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken) 
    {
        throw new NotSupportedException();
    }

    public virtual Task DeleteByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
}