angular.module('telecareDashboardServices', [])

    .constant('API_BASE', 'https://hams.azurewebsites.net/client/')

    .factory('participantResource', function($resource, API_BASE, $http, $filter) {
        return $resource(API_BASE + 'participants/:participantId', null, {
            query: {
                method: 'GET',
                isArray: true,
                transformResponse: $http.defaults.transformResponse.concat([function(data) {
                    data.forEach(function(participant) {
                        var dobAsMoment = moment(participant.dob);

                        // format date
                        participant.dob = dobAsMoment.format('YYYY/MM/DD');

                        //calculate age
                        participant.age = moment().diff(dobAsMoment, 'years');

                        // concatenate names
                        participant.fullName = participant.firstName + ' ' + participant.lastName;
                    });

                    // sort alphabetically
                    data = $filter('orderBy')(data, 'lastName');

                    return data;
                }])
            }
        });
    })

    .factory('thingResource', function($resource, API_BASE) {
        return $resource(API_BASE + 'participants/:participantId/things');
    })

    .service('data', function($resource) {
        var resource = $resource('http://apifinal2.azurewebsites.net/api/Participants/');

        this.getParticipants = function() {
            return resource.get();
        };
    })

    .factory('thingsConfig', function() {
        return [{
            category: 'health',
            title: 'Weight',
            property: 'weight',
            value: {
                number: function() {
                    return sprintf('%.1f', this.value);
                },
                units: 'kg'
            },
            chart: function(records) {
                return {
                    series: [{
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.value];
                        }),
                        name: 'Weight'
                    }],
                    options: {
                        chart: {
                            type: 'line'
                        }
                    }
                };
            },
            details: function(records) {
                if (records.length === 0) {
                    return '';
                }
                var values = records.map(function(record) {
                    return record.value;
                });
                var average = values.average(),
                    change = values.last() - values.first();
                return sprintf('<p>Average weight last week: <span class="value">%.1f kg</span></p>' +
                    '<p>Net change last week: <span class="value">%+.1f kg</span></p>',
                    average, change);
            },
            warnings: {
                value: function(record) {
                    return false;
                },
                time: function(duration) {
                    return duration.asDays() > 20;
                }
            }
        }, {
            category: 'health',
            title: 'Blood pressure',
            property: 'bloodPressure',
            value: {
                number: function() {
                    return this.systolic + '/' + this.diastolic;
                },
                units: '' // should be 'mmHg' but doesn't fit on the tile
            },
            chart: function(records) {
                return {
                    series: [{
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.systolic];
                        }),
                        name: 'Systolic'
                    }, {
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.diastolic];
                        }),
                        name: 'Diastolic'
                    }],
                    options: {
                        chart: {
                            type: 'line'
                        }
                    }
                };
            },
            details: function(records) {
                if (records.length === 0) {
                    return '';
                }
                var valuesSystolic = records.map(function(record) {
                    return record.systolic;
                });
                var valuesDiastolic = records.map(function(record) {
                    return record.diastolic;
                });
                return sprintf('<p>Average systolic pressure last week: <span class="value">%.0f mmHg</span></p>' +
                    '<p>Average diastolic pressure last week: <span class="value">%.0f mmHg</span></p>',
                    valuesSystolic.average(), valuesDiastolic.average());
            },
            warnings: {
                value: function(record) {
                    return record.systolic > 140 ||
                        record.diastolic > 90 ||
                        record.systolic < 90 ||
                        record.diastolic < 60;
                },
                time: function(duration) {
                    return duration.asHours() > 24;
                }
            }
        }, {
            category: 'health',
            title: 'Cholesterol',
            property: 'cholesterol',
            value: {
                number: function () {
                    return this.total;
                },
                units: 'mg/dL'
            },
            chart: function (records) {
                return {
                    series: [{
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.ldl];
                        }),
                        name: 'LDL'
                    }, {
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.hdl];
                        }),
                        name: 'HDL'
                    }, {
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.total];
                        }),
                        name: 'Total'
                    }],
                    options: {
                        chart: {
                            type: 'line'
                        }
                    }
                };
            },
            details: function (records) {
                if (records.length === 0) {
                    return '';
                }
                var valuesLdl = records.map(function (record) {
                    return record.ldl;
                });
                var valuesHdl = records.map(function (record) {
                    return record.hdl;
                });
                var valuesTotal = records.map(function (record) {
                    return record.total;
                });
                return sprintf('<p>Average Total cholesterol last week: <span class="value">%.0f mm/dL</span></p>' +
                    '<p>Average LDL last week: <span class="value">%.0f mm/dL</span></p>' +
                    '<p>Average HDL last week: <span class="value">%.0f mm/dL</span></p>',
                    valuesTotal.average(), valuesLdl.average(), valuesHdl.average());
            },
            warnings: {
                value: function (record) {
                    return record.ldl > 100 ||
                        record.hdl > 50 ||
                        record.total > 200;
                },
                time: function (duration) {
                    return duration.asDays() > 7;
                }
            }
        }, {
            category: 'health',
            title: 'Glucose',
            property: 'bloodGlucose',
            value: {
                number: function () {
                    return this.value;
                },
                units: 'mg/dL'
            },
            chart: function (records) {
                return {
                    series: [{
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.value];
                        }),
                        name: 'Blood glucose'
                    }],
                    options: {
                        chart: {
                            type: 'line'
                        }
                    }
                };
            },
            details: function (records) {
                if (records.length === 0) {
                    return '';
                }
                var values = records.map(function (record) {
                    return record.value;
                });
                return sprintf('<p>Average glucose level last week: <span class="value">%.0f mm/dL</span></p>',
                    values.average());
            },
            warnings: {
                value: function (record) {
                    return false;
                },
                time: function (duration) {
                    return duration.asHours() > 24;
                }
            }
        },
            // Not supported by HealthVault platform at the moment
            //}, {
            //    category: 'health',
            //    title: 'SpO<sub>2</sub>',
            //    property: 'bodyOxygen',
            //    value: {
            //        number: function() {
            //            return this.value * 100;
            //        },
            //        units: '%'
            //    },
            //    chart: function(records) {
            //        return {
            //            series: [{
            //                data: records.map(function (record) {
            //                    return [new Date(record.time).getTime(), record.value];
            //                }),
            //                name: 'SpO2'
            //            }],
            //            options: {
            //                chart: {
            //                    type: 'line'
            //                }
            //            }
            //        };
            //    },
            //    details: function(records) {
            //        if (records.length === 0) {
            //            return '';
            //        }
            //        var values = records.map(function(record) {
            //            return record.value;
            //        });
            //        var average = values.average() * 100,
            //            min = values.min() * 100,
            //            max = values.max() * 100;
            //        return sprintf('<p>Average last week: <span class="value">%.1f%%</span></p>' +
            //            '<p>Lowest last week: <span class="value">%.1f%%</span></p>' +
            //            '<p>Highest last week: <span class="value">%.1f%%</span></p>',
            //            average, min, max);
            //    },
            //    warnings: {
            //        value: function(record) {
            //            return record.value < 0.9;
            //        },
            //        time: function(duration) {
            //            return duration.asDays() > 7;
            //        }
            //    }
            //}, {
            //    category: 'environment',
            //    title: 'Smoke',
            //    property: 'smoke',
            //    value: {
            //        number: function() {
            //            return this.status;
            //        },
            //        units: ''
            //    }
            //}, {
            {
                category: 'environment',
                title: 'Temperature',
                property: 'ambientTemperature',
                value: {
                    number: function() {
                        return this.value;
                    },
                    units: '℃'
                },
                chart: function(records) {
                    return {
                        series: [{
                            data: records.map(function (record) {
                                return [new Date(record.time).getTime(), record.value];
                            }),
                            name: 'Temperature'
                        }],
                        options: {
                            chart: {
                                type: 'line'
                            }
                        }
                    };
                },
                details: function(records) {
                    if (records.length === 0) {
                        return '';
                    }
                    var values = records.map(function(record) {
                        return record.value;
                    });
                    var average = values.average(),
                        max = values.max(),
                        min = values.min();
                    return sprintf('<p>Average temperature last week: <span class="value">%.1f℃</span></p>' +
                        '<p>Lowest temperature last week: <span class="value">%.1f℃</span></p>' +
                        '<p>Highest temperature last week: <span class="value">%.1f℃</span></p>',
                        average, min, max);
                },
                warnings: {
                    value: function(record) {
                        return false;
                    },
                    time: function(duration) {
                        return duration.asHours() > 24;
                    }
                }
            }, {
                category: 'environment',
                title: 'Humidity',
                property: 'humidity',
                value: {
                    number: function() {
                        return this.value;
                    },
                    units: '%'
                },
                chart: function(records) {
                    return {
                        series: [{
                            data: records.map(function (record) {
                                return [new Date(record.time).getTime(), record.value];
                            }),
                            name: 'Humidity'
                        }],
                        options: {
                            chart: {
                                type: 'line'
                            }
                        }
                    };
                },
                details: function(records) {
                    if (records.length === 0) {
                        return '';
                    }
                    var values = records.map(function(record) {
                        return record.value;
                    });
                    var average = values.average(),
                        max = values.max(),
                        min = values.min();
                    return sprintf('<p>Average humidity last week: <span class="value">%.0f%%</span></p>' +
                        '<p>Lowest humidity last week: <span class="value">%.0f%%</span></p>' +
                        '<p>Highest humidity last week: <span class="value">%.0f%%</span></p>',
                        average, min, max);
                },
                warnings: {
                    value: function(record) {
                        return false;
                    },
                    time: function(duration) {
                        return duration.asHours() > 24;
                    }
                }
            }, {
                category: 'environment',
                title: 'CO',
                property: 'carbonMonoxide',
                value: {
                    number: function() {
                        if (this.value === 'ok') {
                            return 'OK';
                        } else if (this.value === 'warning') {
                            return 'WARN';
                        } else if (this.value === 'emergency') {
                            return 'DANGER';
                        }
                        return '--';
                    },
                    units: ''
                },
                chart: function(records) {
                    var recordsForChart = records.map(function(record) {
                        return [
                            new Date(record.time).getTime(),
                            (function() {
                                if (record.value === 'ok') {
                                    return  0;
                                } else if (record.value === 'warning') {
                                    return 1;
                                } else if (record.value === 'emergency') {
                                    return 2;
                                } else {
                                    return 0;
                                }
                            })()
                        ];
                    });
                    return {
                        series: [{
                            data: recordsForChart,
                            name: 'Carbon monoxide status'
                        }],
                        yAxis: {
                            max: 2,
                            labels: {
                                enabled: false
                            }
                        },
                        options: {
                            chart: {
                                type: 'column'
                            }
                        }
                    };
                },
                details: function(records) {
                    var status = (function() {
                        var current = records.last();
                        console.log(current);
                        if (current.value === 'ok') {
                            return {
                                status: 'OK',
                                description: 'No CO detected'
                            };
                        } else if (current.value === 'warning') {
                            return {
                                status: 'WARNING',
                                description: 'CO detected'
                            };
                        } else if (current.value === 'emergency') {
                            return {
                                status: 'EMERGENCY',
                                description: 'CO detected! Move to fresh air!'
                            };
                        }
                    })();
                    return sprintf('<p>The current status is <span class="value">%s</span>%s</p>',
                        status.status, status.description);
                },
                warnings: {
                    value: function(record) {
                        return record.value !== 'ok';
                    },
                    time: function(duration) {
                        return duration.asHours() > 24;
                    }
                }
            }, {
                category: 'environment',
                title: 'Smoke',
                property: 'smoke',
                value: {
                    number: function() {
                        if (this.value === 'ok') {
                            return 'OK';
                        } else if (this.value === 'warning') {
                            return 'WARN';
                        } else if (this.value === 'emergency') {
                            return 'DANGER';
                        }
                        return '--';
                    },
                    units: ''
                },
                chart: function(records) {
                    var recordsForChart = records.map(function(record) {
                        return [
                            new Date(record.time).getTime(),
                            (function() {
                                if (record.value === 'ok') {
                                    return 0.1;
                                } else if (record.value === 'warning') {
                                    return 1;
                                } else if (record.value === 'emergency') {
                                    return 2;
                                } else {
                                    return 0;
                                }
                            })()
                        ];
                    });
                    return {
                        series: [{
                            data: recordsForChart,
                            name: 'Smoke status'
                        }],
                        yAxis: {
                            max: 2,
                            labels: {
                                enabled: false
                            }
                        },
                        options: {
                            chart: {
                                type: 'column'
                            }
                        }
                    };
                },
                details: function(records) {
                    var status = (function() {
                        var current = records.last();
                        console.log(current);
                        if (current.value === 'ok') {
                            return {
                                status: 'OK',
                                description: 'No smoke detected'
                            };
                        } else if (current.value === 'warning') {
                            return {
                                status: 'WARNING',
                                description: 'Smoke detected'
                            };
                        } else if (current.value === 'emergency') {
                            return {
                                status: 'EMERGENCY',
                                description: 'Smoke detected! Move to fresh air!'
                            };
                        }
                    })();
                    return sprintf('<p>The current status is <span class="value">%s</span>%s</p>',
                        status.status, status.description);
                },
                warnings: {
                    value: function(record) {
                        return record.value !== 'ok';
                    },
                    time: function(duration) {
                        return duration.asHours() > 24;
                    }
                }
            }, {
                category: 'background',
                title: 'Conditions',
                property: 'conditions',
                value: {
                    list: function(item) {
                        return item.text;
                    }
                },
                details: function(records) {
                    if (records.length === 0) {
                        return '<p>None reported</p>';
                    }
                    return '<ul>' +
                        records.map(function(record) {
                            return sprintf('<li>%s</li>', record.text);
                        }).join('') +
                        '</ul>';
                }
            }, {
                category: 'background',
                title: 'Allergies',
                property: 'allergies',
                value: {
                    list: function(item) {
                        return item.text;
                    }
                },
                details: function(records) {
                    if (records.length === 0) {
                        return '<p>None reported</p>';
                    }
                    return '<ul>' +
                        records.map(function(record) {
                            return sprintf('<li>%s</li>', record.text);
                        }).join('') +
                        '</ul>';
                }

            }, {
                category: 'background',
                title: 'Medications',
                property: 'medications',
                value: {
                    list: function(item) {
                        return item.text;
                    }
                },
                details: function(records) {
                    if (records.length === 0) {
                        return '<p>None reported</p>';
                    }
                    return '<ul>' +
                        records.map(function(record) {
                            return sprintf('<li>%s</li>', record.text);
                        }).join('') +
                        '</ul>';
                }
            }];
    })

    .factory('aggregateThings', function(thingsConfig, chartConfig, chartConfigTiny) {
        return function(thingsData) {
            var things = {
                health: [],
                environment: [],
                background: []
            };

            thingsConfig.forEach(function(thing) {
                var concreteThing = thingsData[thing.property];
                if (!concreteThing) {
                    return;
                }
                var lastRecord = concreteThing.last();

                var newThing = {
                    title: thing.title
                };
                if (thing.value.number) {
                    newThing.updated = new Date(lastRecord.time);
                    newThing.value = {
                        number: thing.value.number.call(lastRecord),
                        units: thing.value.units
                    };
                    if (thing.chart) {
                        newThing.chart = angular.merge({}, chartConfig, thing.chart(concreteThing));
                        newThing.chartTiny = angular.merge({}, newThing.chart, chartConfigTiny);
                        console.log(newThing.chartTiny);
                    }
                    if (thing.warnings) {
                        var timeDiff = moment().diff(moment(lastRecord.time));
                        newThing.warnings = {
                            value: thing.warnings.value(lastRecord),
                            time: thing.warnings.time(moment.duration(timeDiff))
                        };
                    }
                } else if (thing.value.list) {
                    newThing.list = concreteThing.map(thing.value.list);
                } else {
                    throw new Error('Invalid format of the thing specification: ' + thing);
                }
                if (thing.details) {
                    newThing.details = thing.details(concreteThing);
                    console.warn(newThing.details);
                }
                things[thing.category].push(newThing);
            });

            return things;
        };
    })

    .factory('chartConfig', function() {
        return {
            options: {
                chart: {
                    backgroundColor: 'transparent',
                    spacing: [30, 20, 20, 20]
                },
                tooltip: {
                    style: {
                        padding: 10,
                        fontWeight: 'bold'
                    }
                },
                plotOptions: {
                    series: {
                        animation: {
                            duration: 200
                        }
                    }
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                colors: ['#640024', '#833350']
            },
            title: {
                text: null
            },
            xAxis: {
                title: {text: null},
                type: 'datetime'
            },
            yAxis: {
                title: {text: null}
            },
            size: {
                width: 410,
                height: 200
            }
        };
    })

    .factory('chartConfigTiny', function() {
        return {
            options: {
                chart: {
                    borderWidth: 0,
                    margin: [0, 0, 0, 0],
                    spacing: [10, 10, 10, 10]
                },
                tooltip: {
                    enabled: false
                },
                plotOptions: {
                    series: {
                        marker: {
                            enabled: false,
                            states: {
                                hover: {
                                    enabled: false
                                }
                            }
                        },
                        animation: null
                    }
                }
            },
            xAxis: {
                labels: {
                    enabled: false
                },
                lineWidth: 0
            },
            yAxis: {
                labels: {
                    enabled: false
                },
                gridLineWidth: 0
            },
            size: {
                width: 80,
                height: 30
            }
        };
    })

    .factory('focus', function($timeout) {
        return function(id) {
            // timeout makes sure that it is invoked after any other event has been triggered.
            // e.g. click events that need to run before the focus or
            // inputs elements that are in a disabled state but are enabled when those events
            // are triggered.
            $timeout(function() {
                var element = document.getElementById(id);
                if (element) {
                    element.focus();
                }
            });
        };
    })

;