var CategoryGroup = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/CategoryGroup/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="CategoryGroupFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/CategoryGroup/Form", "Kayıt Form", "CategoryGroupForm", "/CategoryGroup/Kaydet", ValidationFields.CategoryGroup(), function () {
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