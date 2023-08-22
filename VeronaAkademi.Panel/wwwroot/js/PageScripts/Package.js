var Package = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Package/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="PackageFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Package/Form", "Kayıt Form", "PackageForm", "/Package/Kaydet", ValidationFields.Advisor_Package_PracticeLesson(), function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="SaveThisPackage"]', function (e) {
            e.preventDefault();
            var form = $('#PackageForm');
            debugger;
            $.ajax({
                url: '/Package/Update',
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