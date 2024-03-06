import ReactECharts from 'echarts-for-react';
const BarChart = ({ labels, serie }) => {
    const options = {
        title: {
            text: "Clima Diario",
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        toolbox: {
            feature: {
                saveAsImage: {}
            }
        },
        legend: {},
        xAxis: {
            type: 'category',
            boundaryGap: false,
            data: labels
        },
        yAxis: {
            type: 'value'
        },
        series: [
            {
                data: serie,
                type: 'line',
                stack: 'Total',
                smooth: true,

            }
        ]
    };
    return <ReactECharts option={options} />
}
export default BarChart;
BarChart.defaultProps = {
    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
    serie: [120, 200, 150, 80, 70, 110, 130]
}