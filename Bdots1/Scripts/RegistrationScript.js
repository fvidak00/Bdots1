var myApp = angular.module('myApp', []);

myApp.controller('registrationCtrl', function ($scope, $http,$window) {



	$scope.certuser = {};
	var status = {};

	$scope.savedata = function (certuser) {
		
		
		$http.post("/Registration/SaveUser", { newCertUser: certuser })
			.then(function succesCallback(response) {
				debugger;
				status = response.data;
				if (status === 0) {
					alert("Registration successfull");
					$window.location.href = '/NavigationBar/Index';
				}
				else if (status == 1) {
					alert("Username is already in use");
				}
				else if (status == 2) {
					alert("Email is already in use");
				}
				else if (status == 3) {
					alert("Sending mail error");
				}
				
				

			}, function errorCallback(response) {
                alert("POST method error");
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

