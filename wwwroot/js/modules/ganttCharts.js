
let apexChart;

function CreateGanttChart(chartId, data, height)
{
    if(apexChart != null)
    {
        apexChart.destroy();
        apexChart = null;
    }
    var options = 
    {
        series: 
        [
            {
                name: "moduleGantt",
                data: data
            }
        ],
        chart: {
            height: height,
            type: 'rangeBar'
        },
        plotOptions: {
            bar: {
                horizontal: true,
                distributed: true,
                dataLabels: {
                    hideOverflowingLabels: false
                }
            }
        },
        dataLabels: {
            enabled: true,
            formatter: function (val, opts)
            {
                var label = opts.w.globals.labels[opts.dataPointIndex]
                var a = moment(val[0])
                var b = moment(val[1])
                var diff = b.diff(a, 'days')
                return label + ': ' + diff + (diff > 1 ? ' days' : ' day')
            },
            style: {
                colors: ['#04316d', '#04316d']
            }
        },
        xaxis: {
            type: 'datetime'
        },
        yaxis: {
            show: true
        },
        annotations: {
            xaxis: [
            {
              x: new Date(TodayDate()).getTime(),
              borderColor: "#04316d",
              label: {
                borderColor: "#04316d",
                style: {
                  color: "#fff",
                  background: "#04316d"
                },
                orientation: "horizontal",
                text: "Today: " + TodayDate()
              }
            }
          ]
        },
        grid: {
            row: {
                colors: ['#f3f4f5', '#fff'],
                opacity: 1
            }
        }
    };
    
    if(apexChart == null)
    {
        apexChart = new ApexCharts(document.querySelector(chartId), options);
        apexChart.render();
    }
    else
    {
        apexChart.updateSeries([{
            name: "moduleGantt",
            data: data
          }]);
    }
}