var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http,$window) {



	$scope.certuser = {};

    $scope.savedata = function (certuser) {


        $http.post("/Registration/SaveUser", { newCertUser: certuser })
            .then(function succesCallback(response) {
                $scope.certuser = response.data;
                alert("Uspijesna registracija korisnika");
                window.location.href="../Login/Index";
            }, function errorCallback(response) {

                debugger;
                alert("jebe post");
                $window.location.href("/Login/Index");
            });

    };

});