using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace WpfApp.Service
{
    public class FrameNavigationService : ViewModelBase, IFrameNavigationService
    {
        #region Fields

        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly Stack<string> _historic;

        private string _currentPageKey;

        #endregion

        #region Ctor

        public FrameNavigationService(string frameName) : base()
        {
            FrameName = frameName;
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new Stack<string>();
        }

        #endregion

        #region Properties

        public const string CurrentPageKeyPropertyName = "CurrentPageKey";
        public string FrameName { get; private set; }

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey
        {
            get => _currentPageKey;
            set => Set(CurrentPageKeyPropertyName, ref _currentPageKey, value);
        }

        /// <summary>
        /// Получение переданых параметров при переходе навигации
        /// </summary>
        public object Parameter { get; private set; }

        /// <summary>
        /// Получение значения возможности перехода навигации на уровень назад
        /// </summary>
        public bool CanGoBack => _historic.Count > 1;

        #endregion

        #region Public methods

        /// <summary>
        /// If possible, instructs the navigation service
        /// to discard the current page and display the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            if (CanGoBack)
            {
                _historic.Pop();
                NavigateTo(_historic.Pop(), null);
            }
        }

        /// <summary>
        /// Instructs the navigation service to display a new page
        /// corresponding to the given key. Depending on the platforms,
        /// the navigation service might have to be configured with a
        /// key/page list.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Instructs the navigation service to display a new page
        /// corresponding to the given key, and passes a parameter
        /// to the new page.
        /// Depending on the platforms, the navigation service might
        /// have to be Configure with a key/page list.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey)) throw new ArgumentException($"No such page: {pageKey}", "pageKey");
                if (GetDescendantFromName(Application.Current.MainWindow, FrameName) is Frame frame)
                    frame.Source = _pagesByKey[pageKey];
                Parameter = parameter;
                _historic.Push(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        /// <summary>
        /// Настройка ссылки для навигации по приложению
        /// </summary>
        /// <param name="key">Строковое название страницы</param>
        /// <param name="pageType">Относительный путь до XAML файла страницы</param>
        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
                if (_pagesByKey.ContainsKey(key))
                    _pagesByKey[key] = pageType;
                else _pagesByKey.Add(key, pageType);
        }

        #endregion

        #region Private methods

        private FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count < 1) return null;
            for (int i = 0; i < count; i++)
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name)
                        return frameworkElement;
                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                        return frameworkElement;
                }
            return null;
        }


        #endregion

    }
}