using Badge.ModelClient.Models;
using Badge.UI.Utils;
using MVVM;
using MVVM.Command;
using Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private bool _Added;
        private string _DisplayName;
        private decimal _Price;
        private ICommand _OnAddProductToOrder;


        public bool Added
        {
            get { return _Added; }
            private set {
                _Added = value;
                RaisePropertyChanged();
            }
        }

        public string DisplayName
        {
            get { return _DisplayName; }
            private set { _DisplayName = value; }
        }


        public decimal Price
        {
            get { return _Price; }
            private set { _Price = value; }
        }

        public string DisplayTotal
        {
            get { return $"{Total}€"; }

        }


        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            private set { _Total = value; }
        }



        public Product _CurrentProduct { get; private set; }

        public ProductViewModel(Product p)
        {
            MediatorLocator.Instance.GetMediatorToProduct().Register(Reactivate);
            DisplayName = p.ProductName;
            Price = p.Price;
            _CurrentProduct = p;
            _Added = false;
        }

        private void Reactivate(int id)
        {
            if(_CurrentProduct.ID == id)
            {
                Added = false;
                RaisePropertyChanged("OnAddProductToOrder");
            }
        }

        public ICommand OnAddProductToOrder
        {
            get { return _OnAddProductToOrder ?? (_OnAddProductToOrder = new RelayCommand(ExecuteAddToOrder, CanAddToOrder)); }
        }

        private bool CanAddToOrder()
        {
            return !_Added;
        }

        private void ExecuteAddToOrder()
        {
            _Added = true;
            RaisePropertyChanged("OnAddProductToOrder");
            Mediator<Product>.Instance.Send(_CurrentProduct);
        }

        public void SetTotal(decimal total)
        {
            Total = total;
        }
    }
}
