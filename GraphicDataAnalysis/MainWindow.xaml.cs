using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicDataAnalysis
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * 统计图加载
         */
        private void PieChartLoad(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            // 饼状图
            InitPieChart();
            // 横列条形图
            InitBasicRowChart();
            // 气泡图
            InitBubbleChart();
            // 多条折线图
            InitMultBasicLineChart();
            // 堆叠图
            InitStackedAreaLineChart();
            // 垂直条形图
            InitBasicColumnChart();
            // 单条折线图
            InitSingleBasicLineChart();
        }

        #region 饼状图
        private void InitPieChart()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        #endregion
        
        #region 横列条形图
        private void InitBasicRowChart()
        {
            BasicRowSeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            BasicRowSeriesCollection.Add(new RowSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            BasicRowSeriesCollection[1].Values.Add(48d);

            BasicRowLabels = new[] { "Maria", "Susan", "Charles", "Frida" };
            BasicRowFormatter = value => value.ToString("N");

            DataContext = this;
        }
        #endregion
        
        #region 气泡图
        private void InitBubbleChart()
        {
            var r = new Random();
            BubbleValuesA = new ChartValues<ObservablePoint>();
            BubbleValuesB = new ChartValues<ObservablePoint>();
            BubbleValuesC = new ChartValues<ObservablePoint>();

            for (var i = 0; i < 20; i++)
            {
                BubbleValuesA.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
                BubbleValuesB.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
                BubbleValuesC.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            }

            DataContext = this;
        }
        #endregion

        #region 多条折线图
        private void InitMultBasicLineChart()
        {
            MultBasicLineSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square
                    //PointGeometrySize = 15
                }
            };

            MultBasicLineLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            MultBasicLineYFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            MultBasicLineSeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                //PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            MultBasicLineSeriesCollection[3].Values.Add(5d);

            DataContext = this;
            DataContext = this;
        }
        #endregion

        #region 推叠图
        private void InitStackedAreaLineChart()
        {
            StackedAreaSeriesCollection = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Title = "Africa",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .228),
                        new DateTimePoint(new DateTime(1960, 1, 1), .285),
                        new DateTimePoint(new DateTime(1970, 1, 1), .366),
                        new DateTimePoint(new DateTime(1980, 1, 1), .478),
                        new DateTimePoint(new DateTime(1990, 1, 1), .629),
                        new DateTimePoint(new DateTime(2000, 1, 1), .808),
                        new DateTimePoint(new DateTime(2010, 1, 1), 1.031),
                        new DateTimePoint(new DateTime(2013, 1, 1), 1.110)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "N & S America",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .339),
                        new DateTimePoint(new DateTime(1960, 1, 1), .424),
                        new DateTimePoint(new DateTime(1970, 1, 1), .519),
                        new DateTimePoint(new DateTime(1980, 1, 1), .618),
                        new DateTimePoint(new DateTime(1990, 1, 1), .727),
                        new DateTimePoint(new DateTime(2000, 1, 1), .841),
                        new DateTimePoint(new DateTime(2010, 1, 1), .942),
                        new DateTimePoint(new DateTime(2013, 1, 1), .972)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Asia",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), 1.395),
                        new DateTimePoint(new DateTime(1960, 1, 1), 1.694),
                        new DateTimePoint(new DateTime(1970, 1, 1), 2.128),
                        new DateTimePoint(new DateTime(1980, 1, 1), 2.634),
                        new DateTimePoint(new DateTime(1990, 1, 1), 3.213),
                        new DateTimePoint(new DateTime(2000, 1, 1), 3.717),
                        new DateTimePoint(new DateTime(2010, 1, 1), 4.165),
                        new DateTimePoint(new DateTime(2013, 1, 1), 4.298)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Europe",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .549),
                        new DateTimePoint(new DateTime(1960, 1, 1), .605),
                        new DateTimePoint(new DateTime(1970, 1, 1), .657),
                        new DateTimePoint(new DateTime(1980, 1, 1), .694),
                        new DateTimePoint(new DateTime(1990, 1, 1), .723),
                        new DateTimePoint(new DateTime(2000, 1, 1), .729),
                        new DateTimePoint(new DateTime(2010, 1, 1), .740),
                        new DateTimePoint(new DateTime(2013, 1, 1), .742)
                    },
                    LineSmoothness = 0
                }
            };

            StackedAreaXFormatter = val => new DateTime((long)val).ToString("yyyy");
            StackedAreaYFormatter = val => val.ToString("N") + " M";

            DataContext = this;
        }
        #endregion

        #region 垂直条形图
        private void InitBasicColumnChart()
        {
            BasicColumnSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            BasicColumnSeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            BasicColumnSeriesCollection[1].Values.Add(48d);

            BasicColumnLabels = new[] { "Maria", "Susan", "Charles", "Frida" };
            BasicColumnFormatter = value => value.ToString("N");

            DataContext = this;
        }
        #endregion

        #region 单条折线图
        private void InitSingleBasicLineChart()
        {
            SingleBasicLineSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                }
            };

            SingleBasicLineLabels = new[] { "Jan"};
            SingleBasicLineYFormatter = value => value.ToString("C");

            DataContext = this;
        }
        #endregion

        #region 属性集
        public SeriesCollection SingleBasicLineSeriesCollection { get; set; }
        public string[] SingleBasicLineLabels { get; set; }
        public Func<double, string> SingleBasicLineYFormatter { get; set; }

        public SeriesCollection BasicColumnSeriesCollection { get; set; }
        public string[] BasicColumnLabels { get; set; }
        public Func<double, string> BasicColumnFormatter { get; set; }

        public SeriesCollection StackedAreaSeriesCollection { get; set; }
        public Func<double, string> StackedAreaXFormatter { get; set; }
        public Func<double, string> StackedAreaYFormatter { get; set; }
    
        public SeriesCollection MultBasicLineSeriesCollection { get; set; }
        public string[] MultBasicLineLabels { get; set; }
        public Func<double, string> MultBasicLineYFormatter { get; set; }

        public ChartValues<ObservablePoint> BubbleValuesA { get; set; }
        public ChartValues<ObservablePoint> BubbleValuesB { get; set; }
        public ChartValues<ObservablePoint> BubbleValuesC { get; set; }

        public SeriesCollection BasicRowSeriesCollection { get; set; }
        public string[] BasicRowLabels { get; set; }
        public Func<double, string> BasicRowFormatter { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }

        #endregion
    }
}
