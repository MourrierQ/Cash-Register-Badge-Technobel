using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class CategoryViewModel: ViewModelBase
    {
        private string _CategoryName;

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

       

        public string DisplayTotal
        {
            get { return $"{Total}€"; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        private ObservableCollection<ProductViewModel> _Products;

        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return _Products ?? (_Products = new ObservableCollection<ProductViewModel>()); 
            }
            set { _Products = value; }
        }


        /// <summary>
        /// Overloaded ctors.
        /// I decided to use the same view model for the menu AND the history
        /// This ctor will create a productViewModel for each product corresponding to the category
        /// </summary>
        public CategoryViewModel(string name, int id)
        {
            CategoryName = name;
            IEnumerable<Product> prods = RepositoryLocator.Instance.GetProductRepository().GetByCategory(id);
            
            if(prods != null)
            {
                foreach(Product p in prods)
                {
                    Products.Add(new ProductViewModel(p));
                }
            }
        }

        /// <summary>
        /// This one is used for the history, it will fetch the total of all the sales for this category
        /// </summary>
        public CategoryViewModel(string name, int id, DateTime d):this(name,id)
        {
            foreach(ProductViewModel p in Products)
            {
                decimal productTotal = LoadProductTotal(d, p._CurrentProduct.ID);
                Total += productTotal;
                p.SetTotal(productTotal);
            }
        }

        private decimal LoadProductTotal(DateTime d, int id)
        {
             return RepositoryLocator.Instance.GetOrderLineRepository().GetProductTotalByDate(d, id);
        }
    }
}
