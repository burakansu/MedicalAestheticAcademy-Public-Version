var Test = function () {

    function testPartial() {
        
        Post("/test/TestPartial",
            { },
            function (response) {
                $("#TestPartialYetkiDivId").html(response);
            },
            function (x, y, z) {
                //Error
            },
            function () {
                //BeforeSend
            },
            function (r) {
            },
            "html");

    }
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Test/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="TestFormPopup"]', function (e) {
            e.preventDefault();
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/test/form", "Kayıt Form", "TestForm", "/test/kaydet", ValidationFields.Test(), function () {
                //complete callback
            });
        });
    }


    return {
        Init: function () {
            init();
        },
        TestPartial: function () {
            testPartial();
        }

    };
}();