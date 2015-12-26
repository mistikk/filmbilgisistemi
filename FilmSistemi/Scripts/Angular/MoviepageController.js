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


        $scope.StarClick = function (MovieId) {
            $scope.MovieId = MovieId;
            console.log(MovieId);
        }

        $('.score').raty({
            movieid:$scope.MovieId,
            width: 130,
            score: 4,
            path: '/Content/images/rate/',
            starOff: 'star-off.svg',
            starOn: 'star-on.svg',
            click: function (score, evt) {
                setTimeout(function () {
                    console.info("$scope.MovieId", $scope.MovieId);
                    $http.post("/MoviePage/SaveStar/" + $scope.MovieId, { "score": score }).success(function () {
                        console.log("başarılı");
                        console.info("$scope.MovieIdB", $scope.MovieId);
                    }).error(function (ex) {
                        console.log("Hatalı");
                        console.info("$scope.MovieIdH", $scope.MovieId);
                    });;
                }, 500);
            }
        });

        //After rate callback
        $('.score').click(function (value) {
            $(this).children().hide();

            $(this).html('<span class="rates__done">Thanks for your vote!<span>')
        })
        console.log($scope.Movieid);
        $scope.SaveComment = function (commentContent, Movieid) {
            console.log(commentContent);
            console.log(Movieid);
            $http.post("/MoviePage/SaveComment/" + Movieid, { "Content": commentContent }).success(function () {
                console.log("başarılı");
            }).error(function (ex) {
                console.log("Hatalı");
            });;
        }

        function activate() { }
    }
})();
