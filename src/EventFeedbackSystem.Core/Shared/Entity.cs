namespace EventFeedbackSystem.Core.Shared;

public class Entity<TKey> where TKey : struct
{
    public TKey Id { get; set; }
    public bool IsDeleted { get; set; } = false;

    public void Delete()
    {
        IsDeleted = true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TKey> other)
            return false;

        return Id.Equals(other.Id);
    }
}
