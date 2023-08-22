var Category = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Category/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="CategoryFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Category/Form", "Kayıt Form", "CategoryForm", "/Category/Kaydet", ValidationFields.Category(), function () {
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