using LiveCharts;
using LiveCharts.Configurations;
using NetVision.DataCore.Model;
using NetVision.DataCore.PerformanceValueTypes;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel.Plot
{
    public class ChartViewModel : ViewModelPropertyUpdater
    {
        private IPerformanceService _data;
        private double min_axis_value, max_axis_value, axis_x_max;
        private ChartValues<PlotModel> _valuesList;
        public ChartViewModel()
        {
            _data = new PerformanceService();
            StartReading = new RelayCommand(StartPlot,CanExecute);
            StopReading = new RelayCommand(StopPlot, CanExecute);
        }
        public ChartValues<PlotModel> ChartValues
        {
            get
            {
                return _valuesList;
            }
            set
            {
                _valuesList = value;
                OnPropertyChanged("ChartValues");
            }
        }
        public PerformanceValueType ValueType { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public bool IsReading { get; set; }
        public string Title { get; set; }
        public double Axis_X { get; set; }
       /*{
            get
            {
                return min_axis_value;
            }
            set
            {
                min_axis_value = value;
                OnPropertyChanged("XAxis");
            }
        }
       */
        public double Axis_Y { get; set; }
       
        public double Axis_X_Max
        {
            get
            {
                return axis_x_max;
            }
            set
            {
                axis_x_max = value;
                OnPropertyChanged("Axis_X_Max");
            }
        }
        
        public double Axis_Y_Min { get; set; }
        
        public string Labels { get; set; }
        public void setLimitsOfAxes(DateTime time, int interval)
        {
            Axis_X = time.Ticks - TimeSpan.FromSeconds(interval).Ticks;
            Axis_X_Max = time.Ticks + TimeSpan.FromSeconds(1).Ticks;
        }
        public void ConfigureChart()
        {
            var mapper = Mappers.Xy<PlotModel>()
                                 .X(model => model.Arg.Ticks)
                                 .Y(model => model.ChartValue);
            Charting.For<PlotModel>(mapper);
            AxisUnit = TimeSpan.TicksPerSecond;
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            Axis_Y_Min = 0.0;
            Axis_Y = 100;
            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");
            _valuesList = new ChartValues<PlotModel>();
            ChartValues = new ChartValues<PlotModel>();
            _valuesList.Add(new PlotModel()
            {
                Arg = DateTime.Now,
                ChartValue = 0
            });
            setLimitsOfAxes(DateTime.Now, 1);
        }

        public ICommand StartReading { get; set; }
        public ICommand StopReading { get; set; }

        private bool CanExecute(object param)
        {
            return true;
        }

       
        public void PlotValues(float y, DateTime time)
        {
            if (!IsReading)
            {
                throw new Exception("Reading not started!");
            }

            _valuesList.Add(new PlotModel()
            {
                Arg = time,
                ChartValue = (int)y
            }) ;

            setLimitsOfAxes(DateTime.Now, 5);
        }

        public void StartPlot(object param)
        {
            ConfigureChart();
            IsReading = true;
        }

        public void StopPlot(object param)
        {
            IsReading = false;
        }
    }
}
