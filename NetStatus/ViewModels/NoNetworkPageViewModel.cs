using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Prism.Navigation;

namespace NetStatus.ViewModels
{
    public class NoNetworkPageViewModel : BindableBase, INavigationAware
    {
        public NoNetworkPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NoNetworkPageViewModel)}:  ctor");
        }

        ~NoNetworkPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NoNetworkPageViewModel)}:  destruction");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters) { }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}
