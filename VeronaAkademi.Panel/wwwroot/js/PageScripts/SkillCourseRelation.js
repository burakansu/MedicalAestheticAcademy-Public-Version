var SkillCourseRelation = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/SkillCourseRelation/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="SkillCourseRelationFormPopup"]', function (e) {
            e.preventDefault();
            debugger;
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/SkillCourseRelation/Form1", "Kayıt Form", "SkillsForm", "/Course/Kaydet", null, function () {
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