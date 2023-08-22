var Skill = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Skill/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="SkillFormPopup"]', function (e) {
            e.preventDefault();
            debugger;
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            Global.GetFormWithParams(params, "/Skill/Form", "Kayıt Form", "SkillForm", "/Skill/Kaydet", ValidationFields.Skill(), function () {
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