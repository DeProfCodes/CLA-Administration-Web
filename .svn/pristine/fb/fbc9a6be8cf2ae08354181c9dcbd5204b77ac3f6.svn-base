
let apexChart;

function BuildRowGanttChartToolTipData(rowData)
{
    const row1 = { key: rowData.Property1.ColumnName, value: rowData.Property1.ColumnValue };
    const row2 = { key: rowData.Property2.ColumnName, value: rowData.Property2.ColumnValue };
    const row3 = { key: rowData.Property3.ColumnName, value: rowData.Property3.ColumnValue };
    const row4 = { key: rowData.Property4.ColumnName, value: rowData.Property4.ColumnValue };
    
    var row1Html = (row1.key != null && row1.value != null) ? `<div>${row1.key}: <span class="gantt-tooltip-value"> ${row1.value}</span></div>` : "";
    var row2Html = (row2.key != null && row2.value != null) ? `<div>${row2.key}: <span class="gantt-tooltip-value"> ${row2.value}</span></div>` : "";
    var row3Html = (row3.key != null && row3.value != null) ? `<div>${row3.key}: <span class="gantt-tooltip-value"> ${row3.value}</span></div>` : "";
    var row4Html = (row4.key != null && row4.value != null) ? `<div>${row4.key}: <span class="gantt-tooltip-value"> ${row4.value}</span></div>` : "";

    return (
             `<div class="gantt-tooltip-container">
                ${row1Html}
                ${row2Html}
                ${row3Html}
                ${row4Html}
              </div>`
    );
}

function CreateGanttChart(chartId, data, height, seriesName, tooltipData)
{
    var options =
    {
        series:
            [
                {
                    name: seriesName,
                    data: data
                }
            ],
        chart: {
            height: height,
            type: 'rangeBar',
            zoom: {
                enabled: false
            }
        },
        plotOptions: {
            bar: {
                horizontal: true,
                borderRadius: 3,
                rangeBarOverlap: false,
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
                var label = opts.w.globals.labels[opts.dataPointIndex];
                var a = moment(val[0]);
                var b = moment(val[1]);
                var diff = b.diff(a, 'days')
                
                var timeLabel = diff != 0 ? (diff > 1 ? ' days' : ' day') : "";
                
                if(diff == 0)
                {
                    let diffInMilliseconds = Math.abs(b - a);
                    diff = parseInt(diffInMilliseconds / (1000 * 60 * 60));

                    timeLabel = (diff > 1 ? ' hours' : ' hour');
                }

                return label + ': ' + diff + timeLabel;
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
        },
        tooltip: {
            shared: false,
            custom: [
                function ({ seriesIndex, dataPointIndex, w }) 
                {
                    return BuildRowGanttChartToolTipData(tooltipData[dataPointIndex]);
                },
            ],
        },
    };

    if (apexChart != null)
        apexChart.destroy();

    apexChart = new ApexCharts(document.querySelector(chartId), options);
    apexChart.render();
}