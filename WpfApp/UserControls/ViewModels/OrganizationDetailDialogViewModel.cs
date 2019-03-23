using System;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Entities;
using MaterialDesignThemes.Wpf;

namespace WpfApp.UserControls.ViewModels
{
    public class OrganizationDetailDialogViewModel : UserControlViewModelBase
    {
        private Organization _organization;

        public Organization Organization
        {
            get { return _organization; }
            set { Set(nameof(Organization), ref _organization, value); }
        }

        public override void Init(object obj)
        {
            Organization = obj as Organization;
            if (Organization == null) throw new ArgumentNullException(nameof(obj));
        }
    }
}