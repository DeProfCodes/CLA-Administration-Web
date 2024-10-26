
function DrawPieChart(apexPieChart, chartId, pieData, pieDataLabel, colorsData, dimensions)
{
    var options = {
        series: pieData,
        chart: {
            width: 500,
            type: 'pie',
            events: {
                dataPointSelection: function(event, chartContext, config) 
                {
                    var clickedLabel = pieDataLabel[config.dataPointIndex];
                    onPieChartLabelClick(clickedLabel);
                }
            }
        },
        labels: pieDataLabel,
        colors: colorsData,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 210,
                    height: 210
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    if (apexPieChart instanceof ApexCharts)
        apexPieChart.destroy();

    apexPieChart = new ApexCharts(document.querySelector(chartId), options);
    apexPieChart.render();
}