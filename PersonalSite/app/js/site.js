$(function() {
    $('[data-toggle="tooltip"]').tooltip();

    $('#footerYear').text(new Date().getFullYear());

    $(window).on("load resize", function() {
        $(".fill-screen").css("height", window.innerHeight);
        //$(".row-bottom").css("min-height", window.outerHeight/2 -110);
    });
});