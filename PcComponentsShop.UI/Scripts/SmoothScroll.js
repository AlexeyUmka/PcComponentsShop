$(function () {
    $('a[class*="smooth"]').on('click', function (event) {
        // отменяем стандартное действие
        event.preventDefault();

        var sc = $(this).attr("href"),
            dn = $(sc).offset().top;
        /*
        * sc - в переменную заносим информацию о том, к какому блоку надо перейти
        * dn - определяем положение блока на странице
        */

        $('html, body').animate({ scrollTop: dn }, 500);

        /*
        * 1000 скорость перехода в миллисекундах
        */
    });
    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
    $('button[class*="remPos"]').on('click', function (event) {
        var currScreenPos = $(window).scrollTop();
        document.cookie = "currScreenPos=" + currScreenPos + ";path=/;";
    });
    $(document).ready(function () {
        $(window).scrollTop(readCookie("currScreenPos"));
        document.cookie = "currScreenPos=0;path=/;";
    });
    //document.onload(function () {
    //    $(window).scrollTop(readCookie("currScreenPos"));
    //    console.log(readCookie("currScreenPos"));
    //});
});