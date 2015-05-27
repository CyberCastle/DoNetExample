'use strict';

angular.module('donetexampleApp')
    .controller('CustomerController', function ($location, $rootScope, $scope, Customer) {
        $scope.isUpdate = false;
        $scope.customers = [];
        $scope.loadAll = function () {
            $rootScope.customerId = null;
            Customer.query(function(result) {
               $scope.customers = result;
            });
        };
        $scope.loadAll();

        $scope.showUpdate = function (id) {
            $scope.isUpdate = true;
            Customer.get({id: id}, function(result) {
                $scope.customer = result;
                $('#saveCustomerModal').modal('show');
            });
        };

        $scope.save = function () {
            if ($scope.isUpdate === true) {
                $scope.isUpdate = false;
                Customer.update($scope.customer,
                    function () {
                        $scope.refresh();
                    });
            } else {
                Customer.save($scope.customer,
                    function () {
                        $scope.refresh();
                    });
            }
        };

        $scope.delete = function (id) {
            Customer.get({id: id}, function(result) {
                $scope.customer = result;
                $('#deleteCustomerConfirmation').modal('show');
            });
        };

        $scope.confirmDelete = function (id) {
            Customer.delete({id: id},
                function () {
                    $scope.loadAll();
                    $('#deleteCustomerConfirmation').modal('hide');
                    $scope.clear();
                });
        };

        $scope.refresh = function () {
            $scope.loadAll();
            $('#saveCustomerModal').modal('hide');
            $scope.clear();
        };

        $scope.clear = function () {
            $scope.customer = {name: null, email: null, phone: null, movil: null, birthDate: null, address: null, id: null};
            $scope.editForm.$setPristine();
            $scope.editForm.$setUntouched();
        };

        $scope.addDevice = function (id) {
            $rootScope.customerId = id;
            $location.path("/device");
        };
    });
