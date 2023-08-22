var Course = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Course/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="CourseFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            
            Global.GetFormWithParams(params, "/Course/Form", "Kayıt Form", "CourseForm", "/Course/Kaydet", ValidationFields.Course(), function () {
                //complete callback
            });
        });


        $(document).on('click', '[event="LecturerCourseFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            
            Global.GetFormWithParams(params, "/Lecturer/Form", "Kayıt Form", "LecturerForm", "/Lecturer/Kaydet", null, function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="ProfessionCourseFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            
            Global.GetFormWithParams(params, "/Profession/Form", "Kayıt Form", "ProfessionForm", "/Profession/Kaydet", null, function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="SkillCourseFormPopup"]', function (e) {
            e.preventDefault();

            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            
            Global.GetFormWithParams(params, "/Skill/Form", "Kayıt Form", "SkillForm", "/Skill/Kaydet", ValidationFields.Skill(), function () {
                //complete callback
            });
        });


        $(document).on('click', '[event="SaveThisCourse"]', function (e) {
            e.preventDefault();
            var form = $('#CourseForm');
            debugger;
            $.ajax({
                url: '/Course/Update',
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



        $('#saveImageBtn').on('click', function (e) {
            e.preventDefault();

            var formData = new FormData();
            var courseId = $('[name="CourseId"]').val();

            formData.append('CourseId', courseId);

            // Dosya elemanını doğru şekilde seçin
            var fileInput = $('[name="fileInput"]');
            if (fileInput.length > 0 && fileInput[0].files.length > 0) {
                var file = fileInput[0].files[0];
                formData.append('file', file);
            }

            $.ajax({
                url: '/Course/Upload',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    console.log(response);
                    $('#courseImage').attr('src', '/assets/Images/' + response);
                },
                error: function (xhr, status, error) {
                    console.log(error);
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