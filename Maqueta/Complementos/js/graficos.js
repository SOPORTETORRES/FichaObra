/* -------------------------------------------------------------------------- */

/*                             Echarts Pie Chart                              */

/* -------------------------------------------------------------------------- */


var echartsPieChartInit = function echartsPieChartInit() {
    var $pieChartEl = document.querySelector('.echart-pie-chart-example');

    if ($pieChartEl) {
        'const adjudicacion = document.getElementById('<%= txtadjudicacion.ClientID %>').value;
        var userOptions = utils.getData($pieChartEl, 'options');
        var chart = window.echarts.init($pieChartEl);

        var getDefaultOptions = function getDefaultOptions() {
            return {
                legend: {
                    left: 'left',
                    textStyle: {
                        color: utils.getGrays()['600']
                    }
                },
                series: [{
                    type: 'pie',
                    radius: window.innerWidth < 530 ? '45%' : '60%',
                    label: {
                        color: utils.getGrays()['700']
                    },
                    center: ['50%', '55%'],
                    data: [{
                        value: 100,
                        name: 'adjudicacion',
                        itemStyle: {
                            color: utils.getColor('primary')
                        }
                    }, {
                        value: 500,
                        name: 'Propuesta',
                        itemStyle: {
                            color: utils.getColor('danger')
                        }
                    }, {
                        value: 580,
                        name: 'Twitter',
                        itemStyle: {
                            color: utils.getColor('info')
                        }
                    }, {
                        value: 484,
                        name: 'Linkedin',
                        itemStyle: {
                            color: utils.getColor('success')
                        }
                    }, {
                        value: 300,
                        name: 'Github',
                        itemStyle: {
                            color: utils.getColor('warning')
                        }
                    }],
                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: utils.rgbaColor(utils.getGrays()['600'], 0.5)
                        }
                    }
                }],
                tooltip: {
                    trigger: 'item',
                    padding: [7, 10],
                    backgroundColor: utils.getGrays()['100'],
                    borderColor: utils.getGrays()['300'],
                    textStyle: {
                        color: utils.getColors().dark
                    },
                    borderWidth: 1,
                    transitionDuration: 0,
                    axisPointer: {
                        type: 'none'
                    }
                }
            };
        };

        echartSetOption(chart, userOptions, getDefaultOptions); //- set chart radius on window resize

        utils.resize(function () {
            if (window.innerWidth < 530) {
                chart.setOption({
                    series: [{
                        radius: '45%'
                    }]
                });
            } else {
                chart.setOption({
                    series: [{
                        radius: '60%'
                    }]
                });
            }
        });
    }
};