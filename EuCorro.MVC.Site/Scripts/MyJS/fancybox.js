$(document).ready(function () {
    $(".ShowImage").fancybox({
        helpers:
        {
            title:
            {
                type: 'float'
            }
        }
    });

    $('.imageGallery').fancybox({
        fitToView: false,
        width: '600px',
        height: '400px',
        autoSize: false,
        closeClick: false,
        openEffect: 'none',
        closeEffect: 'none',
        padding: 0,
        closeBtn: false,
        'afterClose': function () {
            window.location.reload();
        },
    });
});