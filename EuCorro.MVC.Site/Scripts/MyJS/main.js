/*
 jQuery;
 */

"use strict";

jQuery(document).ready(function ($) {

    $(window).load(function () {
        $(".loaded").fadeOut();
        $(".preloader").delay(1000).fadeOut("slow");
    });


    jQuery('.scrollup').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 2000);
        return false;
    });

    jQuery('.nav a').bind('click', function () {
        $('html , body').stop().animate({
            scrollTop: $($(this).attr('href')).offset().top - 80
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });

    $(function () {
        if ($(window).scrollTop() > $('#corpo').offset().top) {
            //$('#nav').removeClass('container body-content');
            $('#nav').addClass('navbar-fixed-top');

        } else {
            $('#nav').removeClass('navbar-fixed-top');
            //$('#nav').addClass('container body-content');
        };

        $(window).scroll(function () {
            if ($(this).scrollTop() > $('#corpo').offset().top) {
                //$('#nav').removeClass('container body-content');
                $('#nav').addClass('navbar-fixed-top');
            } else {
                $('#nav').removeClass('navbar-fixed-top');
                //$('#nav').addClass('container body-content');
            };
        });
    })

    // Scroll up 

    //$(window).scroll(function () {
    //    if ($(this).scrollTop() > 600) {
    //        $('.scrollup').fadeIn('slow');
    //    } else {
    //        $('.scrollup').fadeOut('slow');
    //    }
    //});
    //$('.scrollup').click(function () {
    //    $("html, body").animate({ scrollTop: 0 }, 1000);
    //    return false;
    //});

    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

    $('#back-to-top').tooltip('show');

    //Initiat WOW JS
    new WOW().init();
    //smoothScroll
    smoothScroll.init();

});
