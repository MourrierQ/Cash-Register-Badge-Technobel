using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class OrderTabViewModel:ViewModelBase
    {
        private MenuViewModel _MenuVM;

        public MenuViewModel MenuVM
        {
            get { return _MenuVM ?? (_MenuVM = new MenuViewModel()); }
        }

        private OrderEditorViewModel _OrderEditorVM;

        public OrderEditorViewModel OrderEditorVM
        {
            get { return _OrderEditorVM ?? (_OrderEditorVM = new OrderEditorViewModel()); }
        }

        


    }
}
