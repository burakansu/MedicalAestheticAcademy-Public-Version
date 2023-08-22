var PracticeLesson = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/PracticeLesson/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="PracticeLessonFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            debugger;
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/PracticeLesson/Form", "Kayıt Form", "PracticeLessonForm", "/PracticeLesson/Kaydet", ValidationFields.Advisor_Package_PracticeLesson(), function () {
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