var Personel = function () {

  
    function YetkiKaydet() {
        
        var personelId = parseInt($("#PersonelId").val());
        var id = document.getElementsByClassName("kid");
        var ids = [];

        $.each(id, function (index, dom) {
            if ($(dom).is(":checked")) {
                ids.push($(dom).val());
            }
        });


        Post('/Personel/YetkiKaydet',
            { id: personelId, ids: ids },
            function (response) {
                if (response.success) {
                    toastr.success(response.description);
                } else {
                    toastr.error(response.description);
                }
            },
            function (x, y, z) {
                //Error
            },
            function () {
                //BeforeSend
            },
            function (response) {
                //Complete
            },
            "json");


            

    }

    var init = function () {
        $(document).ready(function () {
            Pager.init("/Personel/GetList", "PagerListe", "PagerAdetSelect");
        });

        $(document).on('click', '[event="PersonelFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));
            //params, url, title, formId, kayitUrl, validationFields, completeCallBack
            Global.GetFormWithParams(params, "/Personel/form", "Kayıt Form", "PersonelForm", "/Personel/kaydet", ValidationFields.Personel(), function () {
                //complete callback
            });
        });

        $(document).on('click', '[event="YetkiFormPopup"]', function (e) {
            e.preventDefault();
            
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));

            //params, url, title, saveFunction, completeCallBack
            Global.GetFormCustomSave(params, "/Personel/YetkiForm", "Yetkileri Düzenleyin", function () {
                //kayıt fonksiyonu
                YetkiKaydet();
            }, function () {
                //complete callback
            });

        });

        $(document).on('click', "#btnYetkiKaydet", function () {

            var personelId = parseInt($("#PersonelId").val());
            var id = document.getElementsByClassName("kid");
            var ids = [];

            $.each(id, function (index, dom) {
                if ($(dom).is(":checked")) {
                    ids.push($(dom).val());
                }
            });


            Post('/Personel/YetkiKaydet',
                { id: personelId, ids: ids },
                function (response) {
                    if (response.Success) {
                        toastr.success(response.Description);
                    } else {
                        toastr.error(response.Description);
                    }
                },
                function (x, y, z) {
                    //Error
                },
                function () {
                    //BeforeSend
                },
                function (response) {
                    //Complete
                },
                "json");


        });


    }


    return {
        Init: function () {
            init();
        }

    };
}();