var LecturerCourseRelation = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/LecturerCourseRelation/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="LecturerCourseRelationFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/LecturerCourseRelation/Form1", "Kayıt Form", "LecturerCourseRelationForm", "/LecturerCourseRelation/Kaydet", ValidationFields.Relation(), function () {
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