namespace Infrastructure.Interfaces
{
    public interface IDbContextReadOnlyScope
    {
        IDbContextCollection DbContexts { get; }
    }
}