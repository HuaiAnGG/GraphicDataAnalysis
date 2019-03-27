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
        private void GraphChartLoad(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            GrapContract grapContract = new GrapContract();

            grapContract.InitBasicColumnChart();
            grapContract.InitBasicRowChart();
            grapContract.InitBubbleChart();
            grapContract.InitMultBasicLineChart();
            grapContract.InitPieChart();
            grapContract.InitSingleBasicLineChart();
            grapContract.InitStackedAreaChart();

            DataContext = grapContract;
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
    }
}
