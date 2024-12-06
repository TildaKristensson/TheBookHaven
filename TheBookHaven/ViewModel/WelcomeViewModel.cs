using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookHaven.ViewModel
{
    internal class WelcomeViewModel
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        public WelcomeViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }
    }
}
