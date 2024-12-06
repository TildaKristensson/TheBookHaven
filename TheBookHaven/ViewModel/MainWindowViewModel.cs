using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookHaven.Command;

namespace TheBookHaven.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public WelcomeViewModel WelcomeViewModel { get; }

        public RelayCommand EnterTheBookHavenCommand { get; }

        private bool _isWelcomeView;
        private bool _isMainView;
        public bool IsWelcomeView
        {
            get { return _isWelcomeView; }
            set
            {
                _isWelcomeView = value;
                RaisePropertyChanged(nameof(_isWelcomeView));
                RaisePropertyChanged(nameof(_isMainView));
            }

        }

        public bool IsMainView
        {
            get { return _isMainView; }
            set
            {
                _isMainView = value;
                RaisePropertyChanged(nameof(_isMainView));
                RaisePropertyChanged(nameof(_isWelcomeView));
            }
        }
        public MainWindowViewModel()
        {
            //using var db = new TheBookHavenContext();

            WelcomeViewModel = new WelcomeViewModel(this);

            IsWelcomeView = true;
            IsMainView = false;

            EnterTheBookHavenCommand = new RelayCommand(EnterTheBookHaven);

        }

        private void EnterTheBookHaven(object obj)
        {
            IsMainView = true;
            IsWelcomeView = false;
        }
    }
}
