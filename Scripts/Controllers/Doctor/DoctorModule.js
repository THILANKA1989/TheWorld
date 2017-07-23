(function () {
    angular.module("DoctorModule", ["ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "DoctorIndexController",
                controllerAs: "vm",
                templateUrl: "/SPAViews/Doctors/DoctorIndexView.html"
            });

            //$routeProvider.when("/edit", {
            //    controller: "UserIndexEditorController",
            //    controllerAs: "vm",
            //    templateUrl: "/Views/User/UserIndexEditorView.html"
            //});

            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();