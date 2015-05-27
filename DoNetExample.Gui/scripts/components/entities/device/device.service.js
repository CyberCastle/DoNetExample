'use strict';

angular.module('donetexampleApp')
    .factory('Device', function ($rootScope, $resource) {

        return $resource('http://localhost:1419/service/device/:id', {}, {
            'query': {
                method: 'GET',
                isArray: true,
            },
            'get': {
                method: 'GET',
                url: 'http://localhost:1419/service/device/info/:id',
                transformResponse: function (data) {
                    data = angular.fromJson(data);
                    return data;
                }
            },
            'update': { method: 'POST' },
            'save': { method: 'PUT' }
        });
    });
