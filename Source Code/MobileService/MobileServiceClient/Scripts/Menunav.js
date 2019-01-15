$(document).ready(function () {
    $('#sdt_menu > li').bind('mouseenter', function () {
        $(this).find('.sdt_wrap')
            .animate({ 'top': '10px' }, 200)
        $(this).find('.sdt_box').fadeIn()
    }).bind('mouseleave', function () {
        if ($(this).find('.sdt_box').length)
            $(this).find('.sdt_box').fadeOut(200)
        $(this).find('.sdt_wrap')
            .stop(true)
            .animate({ 'top': '25px' }, 200);
    });
});