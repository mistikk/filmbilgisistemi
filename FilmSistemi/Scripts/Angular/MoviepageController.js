(function () {
    'use strict';

    angular
        .module('app')
        .controller('MoviepageController', MoviepageController);

    MoviepageController.$inject = ['$scope', '$http']; 

    function MoviepageController($scope,$http) {
        $scope.title = 'MoviepageController';
        console.clear();
        
        activate();
        $scope.starClick = function () {
            console.info("Star", $scope.star);
        }

        $('.score').raty({
            width: 130,
            score: 4,
            path: '/Content/images/rate/',
            starOff: 'star-off.svg',
            starOn: 'star-on.svg',
            click: function (score, evt) {
                alert('ID: ' + $(this).attr('id') + '\nscore: ' + score + '\nevent: ' + evt);
                $http.post("/MoviePage/SaveStar/136", { "score": score }).success(function () {
                    console.log("başarılı");
                }).error(function (ex) {
                    console.log("Hatalı");
                });;
            }
        });

        //After rate callback
        $('.score').click(function (value) {
            $(this).children().hide();

            $(this).html('<span class="rates__done">Thanks for your vote!<span>')
            console.log($('.score').score);
        })



        function activate() { }
    }
})();
