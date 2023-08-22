var Lesson = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Lesson/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="LessonFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            debugger;
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Lesson/Form", "Kayıt Form", "LessonForm", "/Lesson/Kaydet", ValidationFields.Lesson(), function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="SaveThisLesson"]', function (e) {
            e.preventDefault();
            var form = $('#LessonForm');
            debugger;
            $.ajax({
                url: '/Lesson/Update',
                type: 'POST',
                data: form.serialize(),
                success: function (response) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Başarılı',
                        text: 'Kayıt başarılı bir şekilde yapıldı.'
                    });
                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata',
                        text: 'İşlem sırasında bir hata oluştu.'
                    });
                }
            });
        });
    }


    return {
        Init: function () {
            init();
        }

    };
}();