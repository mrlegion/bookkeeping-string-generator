using System;

namespace Mehdime.DbScope.Interfaces
{
    public interface IDbContextReadOnlyScope : IDisposable
    {
        IDbContextCollection DbContexts { get; }
    }
}