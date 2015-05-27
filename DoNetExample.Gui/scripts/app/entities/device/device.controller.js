'use strict';

angular.module('donetexampleApp')
    .controller('DeviceController', function ($rootScope, $scope, Device, Customer) {
        $scope.devices = [];
        $scope.customers = Customer.query();
        $scope.loadAll = function() {
            Device.query({ id: $rootScope.customerId}, function (result) {
               $scope.devices = result;
            });
        };
        $scope.loadAll();

        $scope.showUpdate = function (id) {
            Device.get({id: id}, function(result) {
                $scope.device = result;
                $('#saveDeviceModal').modal('show');
            });
        };

        $scope.save = function () {
            if ($scope.device.id != null) {
                Device.update($scope.device,
                    function () {
                        $scope.refresh();
                    });
            } else {
                Device.save($scope.device,
                    function () {
                        $scope.refresh();
                    });
            }
        };

        $scope.delete = function (id) {
            Device.get({id: id}, function(result) {
                $scope.device = result;
                $('#deleteDeviceConfirmation').modal('show');
            });
        };

        $scope.confirmDelete = function (id) {
            Device.delete({id: id},
                function () {
                    $scope.loadAll();
                    $('#deleteDeviceConfirmation').modal('hide');
                    $scope.clear();
                });
        };

        $scope.refresh = function () {
            $scope.loadAll();
            $('#saveDeviceModal').modal('hide');
            $scope.clear();
        };

        $scope.clear = function () {
            $scope.device = { type: null, brand: null, model: null, serialNumber: null, id: null, customer_Id:$rootScope.customerId };
            $scope.editForm.$setPristine();
            $scope.editForm.$setUntouched();
        };
    });
