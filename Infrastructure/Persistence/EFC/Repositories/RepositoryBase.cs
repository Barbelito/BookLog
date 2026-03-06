using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

public abstract class RepositoryBase<TModel, TId, TEntity, TContext>(TContext context)
    : IRepositoryBase<TModel, TId>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext _context = context;
    protected DbSet<TEntity> Set => _context.Set<TEntity>();

    protected abstract TModel ToModel(TEntity entity);
    protected abstract TEntity ToEntity(TModel model);

    public virtual async Task<TModel?> AddAsync(TModel model, CancellationToken ct = default)
    {
        var entity = ToEntity(model);
        await Set.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
        return ToModel(entity);
    }

    public virtual async Task<IReadOnlyList<TModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await Set.ToListAsync(ct);
        return entities.Select(ToModel).ToList();
    }

    public virtual async Task<TModel?> GetByIdAsync(TId id, CancellationToken ct = default)
    {
        var entity = await Set.FindAsync(new object[] { id }, ct);
        return entity is null ? default : ToModel(entity);
    }

    public virtual async Task<bool> RemoveAsync(TId id, CancellationToken ct = default)
    {
        var entity = await Set.FindAsync(new object[] { id }, ct);
        if (entity is null)
            return false;

        Set.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }

    public virtual async Task<TModel?> UpdateAsync(TModel updatedModel, CancellationToken ct = default)
    {
        var updatedEntity = ToEntity(updatedModel);
        _context.Update(updatedEntity);
        await _context.SaveChangesAsync(ct);
        return ToModel(updatedEntity);
    }
}
