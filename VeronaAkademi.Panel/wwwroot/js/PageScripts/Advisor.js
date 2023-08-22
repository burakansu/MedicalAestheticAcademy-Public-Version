var Advisor = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Advisor/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="AdvisorFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            var url = "/Advisor/Form/" + params.PackageId;

            Global.GetFormWithParams(params, url, "Kayıt Form", "AdvisorForm", "/Advisor/Kaydet", ValidationFields.Advisor_Package_PracticeLesson(), function () {

            });
        });
    }


    return {
        Init: function () {
            init();
        }

    };
}();