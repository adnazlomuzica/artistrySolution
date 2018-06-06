var selectedid = 0;
var artistId = 0;
jQuery.browser = {};

    

$(document).ready(function () {

    jQuery.browser.msie = false;
    jQuery.browser.version = 0;
    if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
        jQuery.browser.msie = true;
        jQuery.browser.version = RegExp.$1;
    }

    function loadPartialView() {
        $.ajax({
            url: '/Administrator/AppLog/NewLogs',
            type: 'GET', 
            success: function (result) {
                $('#newlog-place').html(result);
                $('#newlog-place').show();

            }
        });
    }
    loadPartialView(); 
    //window.setInterval(loadPartialView, 10000);


    $.ajax({
        url: '/Administrator/Message/NewMessages',
        type: 'GET',
        success: function (partialView) {
            $('#newmessage-place').html(partialView);
            $('#newmessage-place').show();
        }
    });

    $.ajax({
        url:'/Administrator/User/GetUser',
        type: 'GET',
        success: function (partialView) {
            $('#user-name').html(partialView);
            $('#user-name').show();
        }
    });

    $.ajax({
        url:'/Administrator/User/UserInfo',
        type: 'GET',
        success: function (partialView) {
            $('#user-info').html(partialView);
            $('#user-info').show();
        }
    });

    $('.applog').click(function () {
        var $buttonClicked = $(this);
        f1();
    });

    $('.message-save').click(function () {
        var $buttonClicked = $(this);
        $.ajax({
            url: '/Administrator/Message/NewMessages',
            type: 'GET',
            success: function (partialView) {
                $('#newmessage-place').html(partialView);
                $('#newmessage-place').show();
            }
        });
    });

    function f1() {
        $.ajax({
            url:'/Administrator/AppLog/PartialIndex',
            type: 'GET',
            success: function (partialView) {
                $('#applog-place').html(partialView);
                $('#applog-place').show();
            }
        });
    }

    $('.messages').click(function () {
        var $buttonClicked = $(this);

        $.ajax({
            url:'/Administrator/Message/PartialIndex',
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

    $('.new-message').click(function () {
        var $buttonClicked = $(this);

        $.ajax({
            url:'/Administrator/Message/Add',
            type: 'GET',
            success: function (partialView) {
                $('#messages-place').html(partialView);
                $('#messages-place').show();
            }
        });
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

    $('.delete-type').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/ArtworkType/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });

    $('.delete-material').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/Material/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });

    $('*[data-close="close"]').on('click', function () {
        $('#closePanel').hide();
    });

    $('*[data-close="close_details"]').on('click', function () {
        $('#closePanel3').hide();
    });

    $.ajaxSetup({ cache: false });
    $(".popup").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
        });
        return false;
    });

    $('.details').click(function () {
        var $buttonClicked = $(this);
        var ID = $(this).attr('data-ID');
        var targeturl = '/Administrator/Museum/Details?id='+ID;
        $.ajax({
            type: 'GET',
            url: targeturl,
            success: function (partialView) {
                $('#details').html(partialView);
                $('#details').show();
            }
        });
    });

    $('.deactivate-link').click(function () {
        var $buttonClicked = $(this);
        selectedid = $(this).attr('data-deactivate');
    });

    $('.deactivate-museum').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/Museum/Deactivate?museumId=' + selectedid;
        window.location.href = targeturl;
    });

    $('.activate-link').click(function () {
        var $buttonClicked = $(this);
        selectedid = $(this).attr('data-activate');
        var targeturl = '/Administrator/Museum/Activate?museumId=' + selectedid;
        window.location.href = targeturl;
    });

    $('.delete-mtype').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/MuseumType/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });

    $('.delete-style').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/Style/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });

    $('.delete-artist').click(function () {
        var $buttonClicked = $(this);
        var targeturl = '/Administrator/Artist/Delete?id=' + selectedid;
        window.location.href = targeturl;
    });
    
});