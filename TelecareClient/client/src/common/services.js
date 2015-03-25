angular.module('telecareDashboardServices', [])

    .factory('participantsData', function($filter) {
        var data = [{
            "id": "d3c9bb26-5073-4000-a9c6-63b028ea2fe7",
            "firstName": "Dorothy",
            "lastName": "Drake",
            name: "Dorothy Drake",
            "dob": "1945/08/30",
            gender: "female"
        }, {
            "id": "d3c9bb26-5073-4000-a9c6-63b0usfdyf",
            "firstName": "Adam",
            "lastName": "Thomson",
            name: "Adam Thomson",
            "dob": "1943/08/30",
            gender: "male"
        }, {
            id: "847t93rg9728379r2",
            firstName: "Samantha",
            lastName: "Smith",
            name: "Samantha Smith",
            dob: "1964/03/14",
            gender: "female"
        }];

        // calculate age
        data.forEach(function(participant) {
            participant.age = moment().diff(moment(participant.dob, 'YYYY/MM/DD'), 'years');
        });

        // sort alphabetically
        data = $filter('orderBy')(data, 'lastName');

        return data;
    })

    .factory('thingsData', function() {
        return function(participant) {
            var data = {

                // Health tracking types

                "weight": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "value": 67
                }, {
                    "time": "2015-03-06T01:08:29.546Z",
                    "value": 67.4
                }, {
                    "time": "2015-03-12T14:54:42.612Z",
                    "value": 65
                }],

                "steps": [{
                    "time": "2015-03-03T00:00:00.000Z",
                    "count": 9875
                }],

                "bodyTemperature": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "value": 36.5
                }],

                "bodyOxygen": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "value": 0.97
                }],

                "bloodPressure": [{
                    "time": "2015-03-02T07:14:25.854Z",
                    "systolic": 123,
                    "diastolic": 68
                }, {
                    "time": "2015-03-03T01:08:29.546Z",
                    "systolic": 134,
                    "diastolic": 90
                }],

                // Environment-related types

                "ambientTemperature": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "value": 22.4
                }],

                "humidity": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "value": 40
                }],

                "carbonMonoxide": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "status": "ok"
                }],

                "smoke": [{
                    "time": "2015-03-03T01:08:29.546Z",
                    "status": "ok"
                }],

                // Background information types

                "conditions": [],

                "allergies": [{
                    "text": "Animal"
                }, {
                    "text": "Soy"
                }],

                "medications": [{
                    "text": "Ibuprofen"
                }]
            };

            return data;
        };
    })

    .factory('thingsConfig', function() {
        return [{
            category: 'health',
            title: 'Weight',
            property: 'weight',
            value: {
                number: function() {
                    return this.value;
                },
                units: 'kg'
            },
            chart: function(records) {
                return {
                    series: [{
                        data: records.map(function (record) {
                            return [new Date(record.time).getTime(), record.value];
                        })
                    }],
                    options: {
                        chart: {
                            type: 'line'
                        }
                    }
                };
            },
            details: function(records) {
                var average =  records.map(function(record) {
                    return record.value;
                }).average();
                return sprintf('Average weight last week: %.1f kg', average);
            }
        }, {
            category: 'health',
            title: 'Blood pressure',
            property: 'bloodPressure',
            value: {
                number: function() {
                    return this.systolic + '/' + this.diastolic;
                },
                units: 'mm Hg'
            }
        }, {
            category: 'health',
            title: 'Steps',
            property: 'steps',
            value: {
                number: function() {
                    return this.count;
                },
                units: ''
            }
        }, {
            category: 'health',
            title: 'Body temperature',
            property: 'bodyTemperature',
            value: {
                number: function() {
                    return this.value;
                },
                units: '℃'
            }
        }, {
            category: 'health',
            title: 'SpO<sub>2</sub>',
            property: 'bodyOxygen',
            value: {
                number: function() {
                    return this.value * 100;
                },
                units: '%'
            }
        }, {
            category: 'environment',
            title: 'Smoke',
            property: 'smoke',
            value: {
                number: function() {
                    return this.status;
                },
                units: ''
            }
        }, {
            category: 'environment',
            title: 'Temperature',
            property: 'ambientTemperature',
            value: {
                number: function() {
                    return this.value;
                },
                units: '℃'
            }
        }, {
            category: 'background',
            title: 'Conditions',
            property: 'conditions',
            value: {
                list: function(item) {
                    return item.text;
                }
            }
        }, {
            category: 'background',
            title: 'Allergies',
            property: 'allergies',
            value: {
                list: function(item) {
                    return item.text;
                }
            }

        }, {
            category: 'background',
            title: 'Medications',
            property: 'medications',
            value: {
                list: function(item) {
                    return item.text;
                }
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
                    if (thing.details) {
                        newThing.details = thing.details(concreteThing);
                    }
                } else if (thing.value.list) {
                    newThing.list = concreteThing.map(thing.value.list);
                } else {
                    throw new Error('Invalid format of the thing specification: ' + thing);
                }
                things[thing.category].push(newThing);
            });

            console.log(things);
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
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                }
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
                        }
                    }
                }
            },
            xAxis: {
                labels: {
                    enabled: false
                }
            },
            yAxis: {
                labels: {
                    enabled: false
                }
            },
            size: {
                width: 100,
                height: 50
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