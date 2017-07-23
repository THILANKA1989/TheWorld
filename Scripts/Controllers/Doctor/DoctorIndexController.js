(function () {
    "use strict";
    angular.module("DoctorModule")
        .controller("DoctorIndexController", DoctorIndexController)

    function DoctorIndexController($http)
    {
        var vm = this;
        vm.Doctor = [];
        vm.NewDoctor = {};
        vm.ErrorMessage = "";
        vm.isBusy = true;

        $http.get("../api/DoctorsApi").then(function (response) {
            angular.copy(response.data, vm.Doctor);
        }, function (error) {
                vm.ErrorMessage = "Failed To load data" + response.data;
            }
        ).finally(function(){
            vm.isBusy = false;
        });
        vm.changeClient = function () {
            vm.loadData();
        };


        vm.addDoctor = function () {
            vm.isBusy = true;
            vm.ErrorMessage = "";
            $http.post("../api/DoctorsApi", vm.NewDoctor)
                .then(function (response) {
                    vm.Doctor.push(response.data);
                    vm.newDoctor = {};
                    vm.loadData();
                }, function () {
                    vm.ErrorMessage = "Failed to save!";

                }).finally(function () {
                    vm.isBusy = false;
                    vm.loadData();
                });
        };
    }
})();