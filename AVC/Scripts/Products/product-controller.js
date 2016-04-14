productModule.controller("ProductController", function ($scope, $window,bootstrappedProduct) {

	getStudents("7273");
    function getStudents(id) {
        bootstrappedProduct.getStudents(id)
            .success(function (studs) {
            	$scope.products = studs;
		        $scope.category = studs[0].group;
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
            });
    }
    
    $scope.open = function (id) {
    	$window.open('http://brain.com.ua' + this.product.url.substring(23, this.product.url.length), 'Pictures', 'width=1000,height=1000');
    	}

    $scope.menuClick = function (event) {
    	$scope.category = event.target.id;
    	getStudents(event.target.id);
    	}
	
    $scope.getData = function(id) {
        bootstrappedProduct.get().then(function (products) {
            $scope.products = JSON.parse(products);
        });
    }
    
});





