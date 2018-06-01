using Badge.ModelClient.Models;
using Badge.UI.Utils;
using MVVM;
using MVVM.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class OrderLineViewModel : ViewModelBase
    {
        private decimal _Price;
        private string _ProductName;
        private int _Quantity;
        private Product _Product;

        public decimal Price
        {
            get { return _Price; }
            private set { _Price = value; }
        }


        public string DisplayPrice
        {
            get { return $"{Price * Quantity}€"; }
        }


        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }


        public int Quantity
        {
            get {
                return _Quantity;
            }
            set {
                _Quantity = value;
                RaisePropertyChanged();
            }
        }


        public Product Product
        {
            get { return _Product; }
            private set { _Product = value; }
        }

        private ICommand _OnPlusCommand;

        public ICommand OnPlusCommand
        {
            get { return _OnPlusCommand ?? (_OnPlusCommand = new RelayCommand(ExecutePlusCommand, CanExecutePlusCommand)); }
        }

        private bool CanExecutePlusCommand()
        {
            return true;
        }

        private void ExecutePlusCommand()
        {
            Quantity++;
            MediatorLocator.Instance.GetMediatorForTotal().Send();

            RaisePropertyChanged("DisplayPrice");
        }

        private ICommand _OnMinusCommand;

        public ICommand OnMinusCommand
        {
            get { return _OnMinusCommand ?? (_OnMinusCommand = new RelayCommand(ExecuteMinusCommand, CanExecuteMinusCommand)); }
        }

        private bool CanExecuteMinusCommand()
        {
            return Quantity > 0;
        }

        private void ExecuteMinusCommand()
        {
            Quantity--;
            MediatorLocator.Instance.GetMediatorForTotal().Send();

            RaisePropertyChanged("DisplayPrice");
        }

        private ICommand _OnRemoveCommand;

        public ICommand OnRemoveCommand
        {
            get { return _OnRemoveCommand ?? (_OnRemoveCommand = new RelayCommand(ExecuteRemove)); }
            set { _OnRemoveCommand = value; }
        }

        private void ExecuteRemove()
        {

            //Event to refresh the Command for that particular product
            MediatorLocator.Instance.GetMediatorToProduct().Send(_Product.ID);
            
            //Tells the OrderEditor to remove the corresponding line
            MediatorLocator.Instance.GetMediatorToOrder().Send(_Product.ID);
            
            //Tells the OrderEditor to reevaluate the total
            MediatorLocator.Instance.GetMediatorForTotal().Send();
        }

        public OrderLineViewModel(Product p)
        {
            Quantity = 1;
            Product = p;
            ProductName = p.ProductName;
            Price = p.Price;
        }


    }
}
