using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> _ViewModels;

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if(_ViewModels == null)
                {
                    _ViewModels = new ObservableCollection<ViewModelBase>();
                    _ViewModels.Add(new OrderTabViewModel());
                }
                return _ViewModels;
            }
        }

    }
}
