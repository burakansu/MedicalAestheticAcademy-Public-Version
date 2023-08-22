var Lecturer = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Lecturer/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="LecturerFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Lecturer/Form", "Kayıt Form", "LecturerForm", "/Lecturer/Kaydet", ValidationFields.Lecturer(), function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="SaveThisLecturer"]', function (e) {
            e.preventDefault();
            var form = $('#LecturerForm');
            debugger;
            $.ajax({
                url: '/Lecturer/Update',
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