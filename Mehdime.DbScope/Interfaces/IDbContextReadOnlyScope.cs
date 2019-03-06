namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextReadOnlyScope
    {
        IDbContextCollection DbContexts { get; }
    }
}