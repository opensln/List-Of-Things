(function () {
    'use strict';

    angular.module('app').controller("ThingsController", ThingsController)

    function ThingsController($http) {
        var vm = this;
        var dataService = $http;

       

        //Link up public events
        vm.resetSearch = resetSearch;
        vm.searchImmediate = searchImmediate;

        //------------------------------------------Test Object----------------------------
        //vm.things = [1,2,3]; 
        //vm.thing = {
        //    ThingID: 1,
        //    ThingName: "Toothbrush",
        //    ThingImage: "star.jpg"
        //};
        //----------------------------------------------------------------------------------

        vm.searchCategories = ["do", "re", "mi"];

        vm.searchInput = { selectedCategory: { ThingCatID: 0, ThingCatName: '' }, thingCatName: '' };

        thingList();
        GetCategoriesList();


        function resetSearch() {
            vm.searchInput = { selectedCategory: { ThingCatID: 0, ThingCatName: '' }, thingCatName: '' };

            thingList();
        }

        function searchImmediate(item) {
            if ((vm.searchInput.selectedCategory.ThingCatID == 0 ? true : vm.searchInput.selectedCategory.ThingCatID == item.ThingCat.ThingCatID) &&
                (vm.searchInput.thingCatName.length == 0 ? true : (item.ThingName.toLowerCase().indexOf(vm.searchInput.thingCatName.toLowerCase()) >= 0))) {
                return true;
            }

            return false;
        }

        function thingList() {

            dataService.get("/api/MyApi")
                .then(function (result) {
                    //alert(result.data + "resultsdata")
                    vm.things = result.data;
                },
                function (error)
                {
                    handleException(error)
                }
            );
        }

        function GetCategoriesList() {

            dataService.get("/api/Category")
                .then(function (result) {
                    //alert(result.data + "Data as Objects!")

                    vm.searchCategories = result.data;

                },
                    function (error) {
                        handleException(error)
                    }
            );
          
        }

        

    }

})();