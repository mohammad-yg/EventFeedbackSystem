namespace EventFeedbackSystem.EntityFrameworkCore;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TKey : struct where TEntity : Entity<TKey>
{
    protected readonly DbSet<TEntity> _table;
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAll(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _table.AsNoTracking();

        return _table;
    }
    public virtual IQueryable<TEntity> GetAllWithoutFilter(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _table.IgnoreQueryFilters().AsNoTracking();

        return _table.IgnoreQueryFilters();
    }

    public virtual TEntity? Get(TKey id)
    {
        return _table.FirstOrDefault(e => e.Id.Equals(id));
    }
    public virtual Task<TEntity?> GetAsync(TKey id)
    {
        return _table.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual void Add(TEntity entity, bool saveChanges = true)
    {
        _context.Add(entity);
        if (saveChanges)
            _context.SaveChanges();
    }
    public virtual async Task AddAsync(TEntity entity, bool saveChanges = true)
    {
        await _context.AddAsync(entity);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }
    public void AddRange(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.AddRange(entities);
        if (saveChanges)
            _context.SaveChanges();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        await _table.AddRangeAsync(entities);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public virtual void Update(TEntity entity, bool saveChanges = true)
    {
        _table.Update(entity);
        if (saveChanges)
            _context.SaveChanges();
    }
    public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = true)
    {
        _table.Update(entity);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public void UpdateRange(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.UpdateRange(entities);
        if (saveChanges)
            _context.SaveChanges();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
    {
        _table.UpdateRange(entities);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public virtual void Remove(TEntity entity, bool saveChanges = true)
    {
        _table.Remove(entity);
        if (saveChanges)
            SaveChanges();
    }
    public virtual async Task RemoveAsync(TEntity entity, bool saveChanges = true)
    {
        _table.Remove(entity);
        if (saveChanges)
            await SaveChangesAsync();
    }

    public virtual void Remove(TKey id, bool saveChanges = true)
    {
        var entity = _table.FirstOrDefault(e => e.Id.Equals(id));
        if (entity is not null)
        {
            _table.Remove(entity);
            if (saveChanges is true)
                SaveChanges();
        }
    }
    public virtual async Task RemoveAsync(TKey id, bool saveChanges = true)
    {
        var entity = await _table.FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (entity is not null)
        {
            _table.Remove(entity);
            if (saveChanges is true)
                await SaveChangesAsync();
        }
    }

    public virtual void SaveChanges()
    {
        _context.SaveChanges();
    }
    public virtual Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
