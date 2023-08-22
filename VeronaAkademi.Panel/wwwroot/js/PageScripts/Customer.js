var Customer = function () {
    var init = function () {
        $(document).ready(function () {
            Pager.init("/Customer/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="CustomerFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Customer/Form", "Kayıt Form", "CustomerForm", "/Customer/Kaydet", ValidationFields.Customer(), function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="SaveThisCustomer"]', function (e) {
            e.preventDefault();
            var form = $('#CustomerForm');
            debugger;
            $.ajax({
                url: '/Customer/Update',
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