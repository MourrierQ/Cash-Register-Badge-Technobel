using Badge.UI.ViewModels;
using Patterns.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils
{
    public class ViewModelLocator:LocatorBase
    {
        private static ViewModelLocator _Instance;

        public ViewModelLocator Instance
        {
            get { return _Instance ?? (_Instance = new ViewModelLocator()); }
        }

        private OrderEditorViewModel _orderEditorViewModel;

        public OrderEditorViewModel OrderEditorViewModel
        {
            get { return _orderEditorViewModel ?? (_orderEditorViewModel = GetEditorViewModel()); }
        }


        public ViewModelLocator()
        {
            Container.Register<OrderEditorViewModel>();
        }

        public OrderEditorViewModel GetEditorViewModel()
        {
            return Container.GetInstance<OrderEditorViewModel>();
        }

    }
}
