var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http) {



	$scope.certuser = {};

    $scope.savedata = function (certuser) {


        $http.post("/Registration/SaveUser", { newCertUser: certuser })
            .then(function succesCallback(response) {
                $scope.certuser = response.data;
                alert("Uspijesna registracija korisnika");
                window.location.reload();
            }, function errorCallback(response) {
                alert("jebe post");
            });

    };

});