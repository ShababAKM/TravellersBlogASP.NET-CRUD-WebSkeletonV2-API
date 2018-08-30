var app = angular.module('loginModule', []);

app.controller('LoginController',function($scope, $http){
	$scope.loginVisible = true;
	$scope.homeVisible = true;
	$scope.updateVisible = true;

	$scope.login = function(){
		/*$http.get('http://localhost:5578/*1/api/users')
		.then(function(response){
			//console.log(response);
			if(response.status == 401)
			{
				alert('Invalid username or password');
			}
			else
			{
				$scope.user = response.data;
				$scope.loginVisible = false;
				$scope.categoryVisible = true;
			}*/
			$http.post("http://localhost:56376/api/users/getUser",{UserName: $scope.username,
			Password: $scope.password}).then(function (response) {
      		if(response.status == 401)
			{
				alert('Invalid username or password');
			}
			else
			{
				$scope.user = response.data;
				alert('Logged in');
				//$window.location.href = '/userPage.html';
				//window.location = "apiClient/userPage.html";
			}
  		});	
	};
	$scope.register = function(){
		alert('working');
var model = {                    
                    UserName: $scope.username2,
                    Password: $scope.password2,
                    Email: $scope.email,
                    Phone: $scope.phone
                }
			$http.post("http://localhost:56376/api/users",model).then(function (response) {
			alert('Succecssfully Regestered');
  		});	
		
};
});

