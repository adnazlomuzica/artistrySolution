jQuery.browser = {};

$(document).ready(function () {

    jQuery.browser.msie = false;
    jQuery.browser.version = 0;
    if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
        jQuery.browser.msie = true;
        jQuery.browser.version = RegExp.$1;
    }

    $.ajax({
        url: '/Moderator/Museum/GetName',
        type: 'GET',
        success: function (partialView) {
            $('#user-name').html(partialView);
            $('#user-name').show();
        }
    });

    $.ajax({
        url: '/Moderator/Museum/GetInfo',
        type: 'GET',
        success: function (partialView) {
            $('#user-info').html(partialView);
            $('#user-info').show();
        }
    });

    $.ajax({
        url: '/Moderator/Message/NewMessages',
        type: 'GET',
        success: function (partialView) {
            $('#newmessage-place').html(partialView);
            $('#newmessage-place').show();
        }
    });

    $('.message-save').click(function () {
        var $buttonClicked = $(this);
        $.ajax({
            url: '/Moderator/Message/NewMessages',
            type: 'GET',
            success: function (partialView) {
                $('#newmessage-place').html(partialView);
                $('#newmessage-place').show();
            }
        });
    });

    $('.messages').click(function () {
        var $buttonClicked = $(this);

        $.ajax({
            url: '/Moderator/Message/PartialIndex',
            type: 'GET',
            success: function (partialView) {
                $('#messages-place').html(partialView);
                $('#messages-place').show();
            }
        });
    });

    $('.new-message').click(function () {
        var $buttonClicked = $(this);

        $.ajax({
            url: '/Moderator/Message/Add',
            type: 'GET',
            success: function (partialView) {
                $('#messages-place').html(partialView);
                $('#messages-place').show();
            }
        });
    });

    $('li.dropdown.message a').on('click', function (event) {
        $(this).parent().toggleClass('open');
    });

    $('body').on('click', function (e) {
        if (!$('li.dropdown').is(e.target)
            && $('li.dropdown').has(e.target).length === 0
            && $('.open').has(e.target).length === 0
        ) {
            $('li.dropdown').removeClass('open');
        }
    });

    $('*[data-close="close"]').on('click', function () {
        $('#closePanel1').hide();
    });

    $('*[data-close="close_edit"]').on('click', function () {
        $('#closePanel2').hide();
    });

    $('.delete-link').click(function () {
        var $buttonClicked = $(this);
        selectedid = $(this).attr('data-id');
    });

    $('.delete-tickettype').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Moderator/TicketType/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });
});