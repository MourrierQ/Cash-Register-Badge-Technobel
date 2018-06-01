using Badge.ModelClient.Models;
using Badge.UI.Repositories;
using Badge.UI.Utils;
using LiveCharts;
using LiveCharts.Wpf;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.ViewModels
{
    public class TurnoverViewModel:ViewModelBase
    {
        private decimal _GlobalTurnover;
        private decimal _SelectedTurnover;
        private decimal _GlobalVolunteerCost;
        private decimal _SelectedVolunteerCost;
        private DateTime _SelectedDate;
        private List<decimal> _TotalVolunteerByEvening;
        private List<decimal> _TotalGlobalByEvening;
        private List<string> _Dates;


        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set {
                _SelectedDate = value;
                UpdateSelected();
            }
        }


        public decimal GlobalTurnover
        {
            get { return _GlobalTurnover; }
            set {
                _GlobalTurnover = value;
                RaisePropertyChanged(nameof(DisplayGlobalTurnover));
            }
        }


        public decimal SelectedTurnover
        {
            get { return _SelectedTurnover; }
            set {
                _SelectedTurnover = value;
                RaisePropertyChanged(nameof(DisplaySelectedTurnover));
            }
        }

        //Display properties
        //=====================================================
        //=====================================================
        //=====================================================
        public string DisplayGlobalTurnover {
            get {
                return $"Global Turnover : {GlobalTurnover}€";
            }
        }

        public string DisplaySelectedTurnover
        {
            get
            {
                return $"Selected Turnover : {SelectedTurnover}€";
            }
        }


        public decimal GlobalVolunteerCost
        {
            get { return _GlobalVolunteerCost; }
            set {
                _GlobalVolunteerCost = value;
                RaisePropertyChanged(nameof(DisplayGlobalVolunteerCost));
            }
        }



        public decimal SelectedVolunteerCost
        {
            get { return _SelectedVolunteerCost; }
            set {
                _SelectedVolunteerCost = value;
                RaisePropertyChanged(nameof(DisplaySelectedVolunteerCost));
            }
        }

        public string DisplayGlobalVolunteerCost
        {
            get
            {
                return $"Global Volunteer Cost : {GlobalVolunteerCost}€";
            }
        }

        public string DisplaySelectedVolunteerCost
        {
            get
            {
                return $"Volunteer Cost : {SelectedVolunteerCost}€";
            }
        }


        //Properties for the chart
        //===============================================================
        //===============================================================
        //===============================================================
        public List<decimal> TotalGlobalByEvening
        {
            get { return _TotalGlobalByEvening ?? (_TotalGlobalByEvening = new List<decimal>()); }
            set {
                _TotalGlobalByEvening = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SeriesCollection));
            }
        }


        public List<decimal> TotalVolunteerByEvening
        {
            get { return _TotalVolunteerByEvening ?? (_TotalVolunteerByEvening = new List<Decimal>()); }
            set {
                _TotalVolunteerByEvening = value;
                //Tried to refresh the graph 
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SeriesCollection));

            }
        }



        public SeriesCollection SeriesCollection { get; set; }

        public Func<decimal, string> Formatter = value => value.ToString("");

        public List<string> Dates
        {
            get { return _Dates ?? (_Dates = new List<string>()); }
            set { _Dates = value; }
        }

        public string[] DateLabel
        {
            get
            {
                return Dates.ToArray();
            }
        }

        /// <summary>
        /// Loads Graph data
        /// Gets the turnovers for each day from a hardcoded Starting point. 
        /// </summary>
        private void LoadGlobalGraph()
        {

            DateTime Start = new DateTime(2018, 5, 20);
            TimeSpan ts = new TimeSpan(24, 0, 0);
            DateTime End = DateTime.Now;
            TotalGlobalByEvening.Clear();
            TotalVolunteerByEvening.Clear();

            

            while (Start < (End + ts))
            {
                decimal totalGlobal = RepositoryLocator.Instance.GetOrderLineRepository().GetGlobalTurnoverByDate(Start);
                decimal totalVolunteer = RepositoryLocator.Instance.GetOrderLineRepository().GetTotalVolunteerByDate(Start);
                TotalGlobalByEvening.Add(totalGlobal);
                TotalVolunteerByEvening.Add(totalVolunteer);
                Dates.Add($"{Start.Day}/{Start.Month}");
                Start = Start + ts;
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Global",
                    Values = new ChartValues<decimal>(TotalGlobalByEvening)
                },

                new LineSeries
                {
                    Title = "Volunteer",
                    Values = new ChartValues<decimal>(TotalVolunteerByEvening)
                }
            };

        }






        /// <summary>
        /// - loads data
        /// - Sets up the graph lines
        /// - Registers the methods to the mediators 
        /// </summary>
        public TurnoverViewModel()
        {
            SelectedDate = DateTime.Now;

            LoadGlobalGraph();
            

            MediatorLocator.Instance.GetMediatorForHistory().Register(SetSelectedDate);
            MediatorLocator.Instance.GetMediatorToRefreshTurnover().Register(LoadGlobalTurnover);
            MediatorLocator.Instance.GetMediatorToRefreshTurnover().Register(UpdateSelected);
            MediatorLocator.Instance.GetMediatorToRefreshTurnover().Register(LoadGlobalGraph);
            LoadGlobalTurnover();
            UpdateSelected();
        }


        //Registered methods
        //=====================================================
        //=====================================================
        //=====================================================
        private void SetSelectedDate(DateTime d)
        {
            SelectedDate = d;
        }

        private void LoadGlobalTurnover()
        {
            GlobalVolunteerCost = RepositoryLocator.Instance.GetOrderLineRepository().GetTotalVolunteer();
            GlobalTurnover = RepositoryLocator.Instance.GetOrderLineRepository().GetGlobalTurnover();
        }

        public void UpdateSelected()
        {
            SelectedTurnover = RepositoryLocator.Instance.GetOrderLineRepository().GetGlobalTurnoverByDate(SelectedDate);
            SelectedVolunteerCost = RepositoryLocator.Instance.GetOrderLineRepository().GetTotalVolunteerByDate(SelectedDate);
        }


    }
}
