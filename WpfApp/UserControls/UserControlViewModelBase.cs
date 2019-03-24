using System;
using GalaSoft.MvvmLight;

namespace WpfApp.UserControls
{
    public class UserControlViewModelBase<T> : ViewModelBase where T : class
    {
        private T _entity;

        public T Entity
        {
            get { return _entity; }
            set { Set(nameof(Entity), ref _entity, value); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { Set(nameof(Title), ref _title, value); }
        }

        public virtual void Init(T entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public virtual void Init(T entity, string title)
        {
            Init(entity);
            Title = title;
        }
    }
}