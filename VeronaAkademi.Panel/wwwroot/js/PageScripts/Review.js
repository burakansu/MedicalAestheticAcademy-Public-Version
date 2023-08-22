var Review = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Reviews/GetList", "PagerListe", "PagerAdetSelect");
        });
    }

    return {
        Init: function () {
            init();
        }

    };
}();