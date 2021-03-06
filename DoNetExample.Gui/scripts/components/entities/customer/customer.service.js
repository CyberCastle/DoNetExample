'use strict';

angular.module('donetexampleApp')
    .factory('Customer', function ($resource) {
        return $resource('http://localhost:1419/service/customer/:id', {}, {
            'query': { method: 'GET', isArray: true},
            'get': {
                method: 'GET',
                transformResponse: function (data) {
                    data = angular.fromJson(data);
                    if (data.birthDate != null){
                        var birthDateFrom = data.birthDate.split("-");
                        data.birthDate = new Date(new Date(birthDateFrom[0], birthDateFrom[1] - 1, birthDateFrom[2]));
                    }
                    return data;
                }
            },
            'update': { method: 'POST' },
            'save': { method: 'PUT' }
        });
    });
