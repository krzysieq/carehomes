angular.module('telecareAdminServices', [])

    .constant('API_BASE', 'https://hams.azurewebsites.net/admin/')

    .factory('participantsResource', function($resource, API_BASE) {
        return $resource(API_BASE + 'participants');
    })

    .factory('participantResource', function($resource, API_BASE) {
        return $resource(API_BASE + 'participants/:participantId', null, {
            update: {method: 'PUT'},
            deleteParticipant: {method: 'DELETE'}
        });
    })

    .factory('deviceResource', function($resource, API_BASE) {
        return $resource(API_BASE + 'participants/:participantId/devices/:deviceId', {
            participantId: '@participantId',
            deviceId: '@deviceId'
        }, {
            activate: {method: 'PUT'},
            deactivate: {method: 'DELETE'}
        });
    })

    .factory('activationResource', function($resource, API_BASE) {
        return $resource(API_BASE + 'activations', null, {
            update: {method: 'POST'}
        });
    })

;