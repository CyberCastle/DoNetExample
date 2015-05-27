'use strict';

angular.module('donetexampleApp')
    .controller('DeviceDetailController', function ($scope, $stateParams, Device, Customer) {
        $scope.device = {};
        $scope.load = function (id) {
            Device.get({id: id}, function(result) {
                $scope.device = result;
            });
        };
        $scope.load($stateParams.id);
    });
