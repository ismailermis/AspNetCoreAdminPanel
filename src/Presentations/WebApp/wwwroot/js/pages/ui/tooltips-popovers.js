$(function () {
    //Tooltip
    var userName = new Object();
    userName = "Admin";
    $('[data-toggle="tooltip"]').tooltip({
        title: hoverGetData,

        container: 'body',

    });

    //Popover
    $('[data-toggle="popover"]').popover();

    $('.hoverToolTip').tooltip({
        title: hoverGetData,
        html: true,
        content: 'deneme',
        container: 'body',
    });

    var cachedData = Array();

    function hoverGetData() {

        return "ismailERMİŞ";
    }
    $('[data-toggle="popover"]').on('hidden.bs.popover', function () {
        alert('test');
    })

    //----------------
    var userName = new Object();
    // userName = "Admin";
    $('[data-toggle="popover-click1"]').popover({
        html: true,
        trigger: 'click',
        placement: 'bottom',
        title: 'Deneme',
        content: function () {
            var div_id = "tmp-id-" + $.now();
            return details_in_popup(div_id);
        }
    });

    //-------------------------------------------------------------------------------------
    $('[data-toggle="popover-click"]').popover({
        html: true,
        trigger: 'manual',
        content: function () {
            userName = $(this)[0].innerText;
            var roller = $.ajax({
                url: '/Account/GetUserRoleAsync/',
                data: JSON.stringify(userName),
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                async: false
            }).responseText;
            var retVal ="";

            $.each($.parseJSON(roller), function (key, value) {
                retVal+= "<div><b>"+key +"."+ value+"</b></div>";
            });
            if (retVal=="") {
                retVal="Rol ataması yapılmamış.";
            }
            return retVal;
        }
    }).click(function (e) {
        $(this).popover('toggle');
    });
    //-------------------------------------------------------------------------------------
})