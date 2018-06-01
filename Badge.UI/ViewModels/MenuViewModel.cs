using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Badge.UI.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<CategoryViewModel> _Categories;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get {
                if(_Categories == null)
                {
                    _Categories = new ObservableCollection<CategoryViewModel>();
                    this.LoadCategories();
                }
                return _Categories;
            }
        }

        /// <summary>
        /// fetch all the categories from the DB and create a CategoryViewmodel for each of them
        /// </summary>
        private void LoadCategories()
        {
            IEnumerable<Category> categories = RepositoryLocator.Instance.GetCategoryRepository().Get();
            
           if(categories != null)
            {
                foreach (Category c in categories)
                {
                    Categories.Add(new CategoryViewModel(c.CategoryName, c.ID));
                }
            }
        }

    }
}

