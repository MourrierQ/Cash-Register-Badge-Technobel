using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using Badge.UI.Utils;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class CategoriesHistoryViewModel:ViewModelBase
    {
        private ObservableCollection<CategoryViewModel> _Categories;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get {
                if(_Categories == null)
                {
                    _Categories = new ObservableCollection<CategoryViewModel>();
                    LoadCategories();
                }
                return _Categories;
            }
        }

        public DateTime _SelectedDate { get; private set; }

        public CategoriesHistoryViewModel()
        {
            _SelectedDate = DateTime.Now;
            MediatorLocator.Instance.GetMediatorForHistory().Register(SetSelectedDate);
            MediatorLocator.Instance.GetMediatorToRefreshTurnover().Register(LoadCategories);
        }

        private void SetSelectedDate(DateTime d)
        {
            _SelectedDate = d;
            LoadCategories();
        }

        private void LoadCategories()
        {
            Categories.Clear();
            IEnumerable<Category> categories = RepositoryLocator.Instance.GetCategoryRepository().Get();

            if (categories != null)
            {
                foreach (Category c in categories)
                {
                    Categories.Add(new CategoryViewModel(c.CategoryName, c.ID, _SelectedDate));
                }
            }
            RaisePropertyChanged(nameof(Categories));
            
        }

        
    }
}
