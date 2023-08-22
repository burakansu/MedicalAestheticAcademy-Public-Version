var ProfessionCourseRelation = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/ProfessionCourseRelation/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="ProfessionCourseRelationFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/ProfessionCourseRelation/Form1", "Kayıt Form", "ProfessionCourseRelationForm", "/ProfessionCourseRelation/Kaydet", ValidationFields.Relation(), function () {
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