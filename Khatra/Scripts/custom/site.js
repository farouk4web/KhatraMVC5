$(document).ready(function () {

    // set nav bar as fixed top when scroll to down
    var windowWidth = $(window).width(),
        navgationHeight = $(".navgation").outerHeight(true),
        footerHeight = $("footer").outerHeight(true);

    $(window).on("scroll", function () {
        if ($(window).scrollTop() > navgationHeight) {
            $('#mainNav .navbar').addClass('navbar-fixed-top scrolled');
        } else {
            $('#mainNav .navbar').removeClass('navbar-fixed-top scrolled');
        }
    });

    // set default height for bodyContent
    var height = $(window).height() - (navgationHeight + footerHeight);
    $('.bodyContent').css("minHeight", height);

    // fix forms height wheen change screen size because 
    // above code not working in good way when the page contain "FORM"
    var forms = $(".register, .login, .contact, .forgotPassword, .changePassword");
    var formHeight = $(window).height() - (navgationHeight + footerHeight);
    $(forms).css("minHeight", formHeight);

    // remove "input-lg, btn-lg" Class from any input on all site on ExstraSmall screen
    if (windowWidth <= 767) {
        $(".form-control").removeClass("input-lg");
        $(".btn").removeClass("btn-lg");
    }

    // change personal image form
    $("#imageButton").on("click", function () {
        $("#ImageInput").click();
    });
    $("#ImageInput").on("change", function () {
        $("#formImage").submit();
    });

    // add to first slide active Class
    $(".slider .item").first().addClass("active");

    // set follow buttons colors
    $(".follow h3 a i").each(function () {
        var siteColor = $(this).attr("data-color");
        $(this).css("background-color", siteColor);
    });

    // set follow buttons colors
    $(".post_title").each(function () {
        var title = $(this).text();
        if (title.length > 25) {
            $(this).text(title.substring(0, 25) + "...");
        }

    });
});