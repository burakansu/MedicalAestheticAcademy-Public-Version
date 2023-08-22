var Register = function () {
    var init = function () {

        $(document).on('click', '[event="RegisterFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/RegisterUi/Form", "Kayıt Ol", "RegisterForm", "/Home/Index", null, function () {
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