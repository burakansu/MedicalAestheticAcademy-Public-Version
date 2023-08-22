var Trailer = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Trailer/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="TrailerFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Trailer/Form", "Kayıt Form", "TrailerForm", "/Trailer/Kaydet", ValidationFields.Trailer(), function () {
                //complete callback
            });
        });
    }


    return {
        Init: function () {
            init();
        }

    };
}();