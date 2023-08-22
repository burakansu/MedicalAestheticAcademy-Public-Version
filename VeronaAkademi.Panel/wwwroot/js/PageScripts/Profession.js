var Profession = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Profession/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="ProfessionFormPopup"]', function (e) {
            e.preventDefault();

            var params = jQuery.parseJSON($(this).attr("params"));

            Global.GetFormWithParams(params, "/Profession/Form", "Kayıt Form", "ProfessionForm", "/Profession/Kaydet", ValidationFields.Profession(), function () {

            });
        });

        $(document).on('click', '[event="ProfessionImageFormPopup"]', function (e) {
            e.preventDefault();

            debugger;
            var params = jQuery.parseJSON($(this).attr("params"));

            $("#openPopup").click(function () {
                $.get("/Profession/ImageForm/" + params.ProfessionId, function (data) {
                    $("#partialContent").html(data);
                    $("#popup").show();
                });
            });

            $("#closePopup").click(function () {
                $("#popup").hide();
            });
        });

    }


    return {
        Init: function () {
            init();
        }

    };
}();