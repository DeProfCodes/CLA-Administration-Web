let apexPieChart;

function DrawPieChart(chartId, pieData, pieDataLabel, colorsData)
{
    var options = {
        series: pieData,
        chart: {
            width: 380,
            type: 'pie',
        },
        labels: pieDataLabel,
        colors: colorsData,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    if (apexPieChart != null)
        apexPieChart.destroy();

    apexPieChart = new ApexCharts(document.querySelector(chartId), options);
    apexPieChart.render();
}