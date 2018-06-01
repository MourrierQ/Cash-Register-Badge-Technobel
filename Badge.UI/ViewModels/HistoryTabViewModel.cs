using Badge.UI.Utils;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class HistoryTabViewModel : ViewModelBase
    {
        private CategoriesHistoryViewModel _CatHistoryVM;

        public CategoriesHistoryViewModel CatHistoryVM
        {
            get { return _CatHistoryVM ?? (_CatHistoryVM = new CategoriesHistoryViewModel()); }
        }

        private TurnoverViewModel _TurnoverVM;

        public TurnoverViewModel TurnoverVM
        {
            get { return _TurnoverVM ?? (_TurnoverVM = new TurnoverViewModel()); }
        }


        private DateTime _SelectedDate;

        public DateTime SelectedDate { 
            get {
                if(_SelectedDate == default(DateTime))
                {
                    _SelectedDate = DateTime.Now;
                }
                return _SelectedDate;
            }
            set {
                _SelectedDate = value;
                RaisePropertyChanged();
                MediatorLocator.Instance.GetMediatorForHistory().Send(_SelectedDate);
            }
        }


    }
}
