function DrawPieChart(apexPieChart, chartId, pieData, pieDataLabel, colorsData, dimensions, onLabelClick, labelType = "%") 
{
    var options = {
        series: pieData,
        chart: {
            width: dimensions.Width,
            height: dimensions.height,
            type: 'pie',
            events: {
                dataPointSelection: function (event, chartContext, config)
                {
                    var clickedLabel = pieDataLabel[config.dataPointIndex];
                    if (typeof onLabelClick === 'function')
                    {
                        onLabelClick(clickedLabel);
                    }
                }
            },
            animations: {
                enabled: false
            }
        },
        labels: pieDataLabel,
        colors: colorsData,
        legend: {
            position: 'right',
            offsetY: 10
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: Math.min(210, dimensions.Width),
                    height: Math.min(210, dimensions.height)
                },
                legend: {
                    position: 'bottom'
                }
            }
        }],
        plotOptions: {
            pie: {
                expandOnClick: false
            }
        },
        dataLabels: {
            enabled: true,
            formatter: function (val, opts)
            {
                var value = ""; 
                
                if (labelType == "%") value = val.toFixed(0) + '%'; 
                if (labelType == "#") value = opts.w.config.series[opts.seriesIndex];
                if (labelType == "#%") value = `${opts.w.config.series[opts.seriesIndex]} (${val.toFixed(0)}%)`;

                return value;
            }
        }
    };

    if (apexPieChart instanceof ApexCharts)
    {
        apexPieChart.destroy();
    }

    apexPieChart = new ApexCharts(document.querySelector(chartId), options);
    apexPieChart.render().then(() =>
    {
        apexPieChart.redraw();
    });
}
