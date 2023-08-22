var Basket = function () {
    var init = function () {

        $(document).on('click', '[event="SaveItem"]', function (e) {
            e.preventDefault();
            debugger;
            console.log(this);
            var params = jQuery.parseJSON($(this).attr("params"));

            var CustomerId = 1;
            var LessonId = 1;
            var url = '/Basket/Save/' + CustomerId + '/' + LessonId ;

            var xhr = new XMLHttpRequest();
            xhr.open('GET', Basket/Save, true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);

                    console.log(response);
                }
            };
            xhr.send();
            //$('.rbt-cart-sidenav-activation').on('click', function (e) {
            //    debugger;
            //    var tip = $(this).attr("tip");
            //    if (tip == "sepet") {
            //        $.ajax({
            //            url: "/basket/SideBarBasket",
            //            type: "POST",
            //            data: {},
            //            dataType: 'html',
            //            contentType: 'application/json;charset=utf-8',
            //            success: function (result) {
            //                $(".rbt-cart-side-menu").html(result);
            //            },
            //            error: function (r) {

            //            },
            //            complete: function () {
            //                $('.rbt-cart-side-menu').addClass('side-menu-active');
            //                $('body').addClass('cart-sidenav-menu-active');
            //            }
            //        });
            //    }
            //})





        });
    }


    return {
        Init: function () {
            init();
        }

    };
}();