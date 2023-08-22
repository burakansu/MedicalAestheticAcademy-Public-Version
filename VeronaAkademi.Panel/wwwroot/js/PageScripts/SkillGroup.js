var SkillGroup = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/SkillGroup/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="SkillGroupFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/SkillGroup/Form", "Kayıt Form", "SkillGroupForm", "/SkillGroup/Kaydet", ValidationFields.SkillGroup(), function () {
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