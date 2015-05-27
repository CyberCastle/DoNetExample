'use strict';

angular.module('donetexampleApp')
    .controller('NavbarController', function ($scope, $location, $state) {
        $scope.isAuthenticated = true;
        $scope.$state = $state;
    });
