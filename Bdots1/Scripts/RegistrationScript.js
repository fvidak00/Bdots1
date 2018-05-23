var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http,$window) {



	$scope.certuser = {};

	$scope.savedata = function (certuser) {
		
		
		$http.post("/Registration/SaveUser", { newCertUser: certuser })
			.then(function succesCallback(response) {
				debugger;
				$scope.certuser = response.data;
				alert("Registration successfull");
				$window.location.href = '/NavigationBar/Index';

			}, function errorCallback(response) {
                alert("Invalid input!");
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
				alert("Upload successfull");
                $window.location.href = '/NavigationBar/MyVideos';

			}, function errorCallback(response) {
				alert("Invalid input!");
			});


	}


});