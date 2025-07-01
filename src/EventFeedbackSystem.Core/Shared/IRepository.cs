using EventFeedbackSystem.Core.Shared;

namespace EventFeedbackSystem.Shared;

public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey> where TKey : struct
{
    IQueryable<TEntity> GetAll(bool asNoTracking = true);
    IQueryable<TEntity> GetAllWithoutFilter(bool asNoTracking = true);

    TEntity? Get(TKey id);
    Task<TEntity?> GetAsync(TKey id);

    void Add(TEntity entity, bool saveChanges = true);
    Task AddAsync(TEntity entity, bool saveChanges = true);

    void AddRange(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task AddRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);

    void Update(TEntity entity, bool saveChanges = true);
    Task UpdateAsync(TEntity entity, bool saveChanges = true);

    void UpdateRange(IEnumerable<TEntity> entities, bool saveChanges = true);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);

    void Remove(TEntity entity, bool saveChanges = true);
    Task RemoveAsync(TEntity entity, bool saveChanges = true);

    void Remove(TKey id, bool saveChanges = true);
    Task RemoveAsync(TKey id, bool saveChanges = true);

    void SaveChanges();
    Task SaveChangesAsync();
}