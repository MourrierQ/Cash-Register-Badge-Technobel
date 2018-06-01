using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using Badge.UI.Utils;
using MVVM;
using MVVM.Command;
using Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class OrderEditorViewModel:ViewModelBase
    {
        private ObservableCollection<OrderLineViewModel> _OrderLines;
        private int _CurrentOrderID;
        private ICommand _OnCancelCommand;
        private ICommand _OnOrderCommand;

        private bool _Volunteer;

        public bool Volunteer
        {
            get { return _Volunteer; }
            set {
                _Volunteer = value;
                RaisePropertyChanged();
            }
        }


        private decimal _Total;
        private decimal Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
                RaisePropertyChanged(nameof(DisplayTotal));
                RaisePropertyChanged(nameof(OnOrderCommand));
            }
        }

        public ObservableCollection<OrderLineViewModel> OrderLines
        {
            get {
                return _OrderLines ?? (_OrderLines = new ObservableCollection<OrderLineViewModel>());
            }
        }


        public string DisplayTotal
        {
            get { return $"Total : {Total}€"; }
        }





        public int CurrentOrderID
        {
            get { return _CurrentOrderID; }
            set {
                _CurrentOrderID = value;
                RaisePropertyChanged();
            }
        }


        public ICommand OnOrderCommand
        {
            get { return _OnOrderCommand ?? (_OnOrderCommand = new RelayCommand(ExecuteOrder, CanOrder)); }
        }

        private void ExecuteOrder()
        {
            //Insert a new Order and get its ID
            CurrentOrderID = RepositoryLocator.Instance.GetOrderRepository().Insert(new Order(Volunteer));

            if(CurrentOrderID != 0)
            {
                DataTable Entities = SetDataTable();
                RepositoryLocator.Instance.GetOrderLineRepository().InsertAll(Entities);
                MediatorLocator.Instance.GetMediatorToRefreshTurnover().Send();
                foreach (OrderLineViewModel ol in OrderLines)
                {
                    MediatorLocator.Instance.GetMediatorToProduct().Send(ol.Product.ID);
                }
                OrderLines.Clear();
                if (Volunteer) Volunteer = false;
                RaisePropertyChanged(nameof(OnOrderCommand));
                RaisePropertyChanged(nameof(OnCancelCommand));
                UpdateTotal();
            }
        }

        private DataTable SetDataTable()
        {
            //DataTable used to send all the order lines at once to a stored procedure
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderID");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");

            foreach(OrderLineViewModel ol in OrderLines)
            {
                if(ol.Quantity > 0) dt.Rows.Add(CurrentOrderID, ol.Product.ID, ol.Product.Price, ol.Quantity);
            }

            return dt;
        }

        private bool CanOrder()
        {
            return OrderLines.Count > 0 && Total > 0;
        }

        public ICommand OnCancelCommand
        {
            get { return _OnCancelCommand ?? (_OnCancelCommand = new RelayCommand(ExecuteCancel, CanCancel)); }

        }

        private void ExecuteCancel()
        {
            foreach(OrderLineViewModel ol in OrderLines)
            {
                MediatorLocator.Instance.GetMediatorToProduct().Send(ol.Product.ID);
            }

            OrderLines.Clear();
            if (Volunteer) Volunteer = false;
            RaisePropertyChanged(nameof(OnCancelCommand));
            MediatorLocator.Instance.GetMediatorForTotal().Send();

        }

        private bool CanCancel()
        {
            return OrderLines.Count > 0;
        }

        public OrderEditorViewModel()
        {
            //Register the add Line method to the Product button being pressed
            Mediator<Product>.Instance.Register(AddOrderLine);
            MediatorLocator.Instance.GetMediatorToOrder().Register(RemoveOrderLine);
            MediatorLocator.Instance.GetMediatorForTotal().Register(UpdateTotal);
        }

        private void UpdateTotal()
        {
            Total = OrderLines.Sum(ol => ol.Quantity * ol.Product.Price);
        }

        private void RemoveOrderLine(int id)
        {
            OrderLineViewModel ol = OrderLines.Where(o => o.Product.ID == id).SingleOrDefault();
            if(ol != null)
            {
                OrderLines.Remove(ol);
            }
            UpdateTotal();
            
            //Refresh the commands 
            RaisePropertyChanged(nameof(OnCancelCommand));
            RaisePropertyChanged(nameof(OnOrderCommand));
        }

        public void AddOrderLine(Product p)
        {
            OrderLines.Add(new OrderLineViewModel(p));
            UpdateTotal();
            //refresh the commands
            RaisePropertyChanged(nameof(OnCancelCommand));
            RaisePropertyChanged(nameof(OnOrderCommand));
        }

   

    }
}
