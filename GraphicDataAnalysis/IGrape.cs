using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicDataAnalysis
{
    /**
     * 图形接口类
     */ 
    interface IGrape
    {
        // 饼状图
        void InitPieChart();
        // 横列条形图
        void InitBasicRowChart();
        // 气泡图
        void InitBubbleChart();
        // 多条折线图
        void InitMultBasicLineChart();
        // 堆叠图
        void InitStackedAreaChart();
        // 垂直条形图
        void InitBasicColumnChart();

        // 单条折线图
        void InitSingleBasicLineChart();
    }
}
