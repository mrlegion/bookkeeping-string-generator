using System;
using GalaSoft.MvvmLight.Views;

namespace WpfApp.Service
{
    /// <summary>
    /// Description this class
    /// </summary>
    public interface IFrameNavigationService : INavigationService
    {
        #region Properties

        object Parameter { get; }
        string FrameName { get; }
        bool CanGoBack { get; }

        #endregion

        #region Public methods

        void Configure(string key, Uri pageType);

        #endregion
    }
}