﻿using System;

namespace Infrastructure.Implementations
{
    public class AmbientContextSuppressor : IDisposable
    {
        private DbContextScope _savedScope;
        private bool _disposed;

        public AmbientContextSuppressor()
        {
            _savedScope = DbContextScope.GetAmbientScope();
            DbContextScope.HideAmbientScope();
        }

        public void Dispose()
        {
            if (_disposed) return;
            if (_savedScope != null)
            {
                DbContextScope.SetAmbientScope(_savedScope);
                _savedScope = null;
            }

            _disposed = true;
        }
    }
}