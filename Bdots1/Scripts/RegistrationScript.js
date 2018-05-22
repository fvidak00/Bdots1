var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http,$window) {



	$scope.certuser = {};

	$scope.savedata = function (certuser) {
		
		
		$http.post("/Registration/SaveUser", { newCertUser: certuser })
			.then(function succesCallback(response) {
				debugger;
				$scope.certuser = response.data;
				alert("Uspijesna registracija korisnika");
				$window.location.href = '../NavigationBar/Index';

			}, function errorCallback(response) {
				alert("jebe post");
			});

	}
	
});

myApp.controller('uploadController', function ($scope, $http, $window) {


	$scope.video = {};

	$scope.savevideo = function (video) {

		$http.post("/Upload/SaveVideo", { newVideo: video })
			.then(function succesCallback(response) {
				debugger;
				$scope.video = response.data;
				alert("Uspijesan upload videa");
				$window.location.href = '../.';

			}, function errorCallback(response) {
				alert("jebe post");
			});


	}


});