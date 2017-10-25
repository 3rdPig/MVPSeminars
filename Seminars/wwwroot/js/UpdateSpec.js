$('.topic-check').click(function () {
    var sid = $('.sid').val();
    var tid = $(this).val();
    var name = $(this).parent().siblings('span').html();
    var $this = $(this);

    var dataType = 'application/json; charset=utf-8';

    if ($(this).is(':checked'))
    {
        $.ajax({
            type: 'POST',
            url: '/Manage/SpecializationAdd',
            data: JSON.stringify({
                name: name,
                topicId: tid,
                speakerId: sid
            }),
            dataType: 'json',
            contentType: dataType,
            beforeSend: function () {
                // this is where we append a loading image
                //$('#ajax-panel').html('<div class="loading"><img src="/images/loading.gif" alt="Loading..." /></div>');
            },
            success: function (result) {
                //Update the spec count html
                var specCount = parseInt($('.spec-count').html()) + 1;
                $('.spec-count').html(specCount);

                /* Move the topic from Available to Selected */
                //Create the hidden input to hold the specId
                var $specIdInput = $('<input type="hidden" class="specid" />');
                $specIdInput.val(result.id);

                //Put the input into the excluded-spec class
                $this.parent().parent().append($specIdInput);

                //Change the class from excluded-spec to included-spec
                $this.parent().parent().removeClass('excluded-spec').addClass('included-spec');

                //Add the control group to included-inputs
                $('.included-inputs').append($this.parent().parent());                
            },
            error: function () {
                // failed request; give feedback to user
                //$('#ajax-panel').html('<p class="error"><strong>Oops!</strong> Try that again in a few moments.</p>');
            }
        });
    }
    else
    {
        var specid = $(this).parent().siblings('.specid').val();
        data = JSON.stringify({
            name: name,
            topicId: tid,
            speakerId: sid,
            id: specid
        });

        $.ajax({
            type: 'POST',
            url: '/Manage/SpecializationDrop',
            data: JSON.stringify({
                name: name,
                topicId: tid,
                speakerId: sid,
                id: specid
            }),
            dataType: 'json',
            contentType: dataType,
            beforeSend: function () {
                // this is where we append a loading image
                //$('#ajax-panel').html('<div class="loading"><img src="/images/loading.gif" alt="Loading..." /></div>');
            },
            success: function (data) {
                //Update the spec count html
                var specCount = parseInt($('.spec-count').html()) - 1;
                $('.spec-count').html(specCount);

                /* Move the topic from Selected to Available */
                $this.parent().parent().find('specid').remove();
                //Change the class from included-spec to excluded-spec
                $this.parent().parent().removeClass('included-spec').addClass('excluded-spec');

                //Add the control group to included-inputs
                $('.excluded-inputs').append($this.parent().parent());
            },
            error: function () {
                // failed request; give feedback to user
                //$('#ajax-panel').html('<p class="error"><strong>Oops!</strong> Try that again in a few moments.</p>');
            }
        });
    }
});

$('.include-tab').click(function () {
    
    //Refresh the included specs tab
    var firstCharInclude = '';
    var uniqueItemsInclude;
    var lettersInclude = [];
    $('.included-spec span').each(function () {
        var name = $(this).html();

        if (firstCharInclude == '')
            firstCharInclude = name.charAt(0);

        if (name.charAt(0) != firstCharInclude)
            $(this).parent().hide();

        lettersInclude.push(name.charAt(0));
    });

    uniquelettersInclude = Array.from(new Set(lettersInclude));

    $('.include-pages a').each(function () {
        var page = $(this).attr('href').charAt(1).toUpperCase();
        var match = false;

        $(uniquelettersInclude).each(function () {
            if (page == this[0])
                match = true;
        });

        if (!match)
            $(this).parent().addClass('disabled');
        else
            $(this).parent().removeClass('disabled');
    })
});

$('.exclude-tab').click(function () {

    //Refresh the included specs tab
    var firstCharExclude = '';
    var uniqueItemsExclude;
    var lettersExclude = [];
    $('.excluded-spec span').each(function () {
        var name = $(this).html();

        if (firstCharExclude == '')
            firstCharExclude = name.charAt(0);

        if (name.charAt(0) != firstCharExclude)
            $(this).parent().hide();

        lettersExclude.push(name.charAt(0));
    });

    uniquelettersExclude = Array.from(new Set(lettersExclude));

    $('.exclude-pages a').each(function () {
        var page = $(this).attr('href').charAt(1).toUpperCase();
        var match = false;

        $(uniquelettersExclude).each(function () {
            if (page == this[0])
                match = true;
        });

        if (!match)
            $(this).parent().addClass('disabled');
        else
            $(this).parent().removeClass('disabled');
    })
});

var firstCharInclude = '';
var uniqueItemsInclude;
var lettersInclude = [];
$('.included-spec span').each(function () {
    var name = $(this).html();

    if (firstCharInclude == '')
        firstCharInclude = name.charAt(0);

    if (name.charAt(0) != firstCharInclude)
        $(this).parent().hide();

    lettersInclude.push(name.charAt(0));
});

uniquelettersInclude = Array.from(new Set(lettersInclude));

var activeInclude = false;
$('.include-pages a').each(function () {
    var page = $(this).attr('href').charAt(1).toUpperCase();
    var match = false;
    var active = false;

    $(uniquelettersInclude).each(function () {
        if (page == this[0])
            match = true;
    });

    if (!match)
        $(this).parent().addClass('disabled');
    else if (!activeInclude && match) {
        $(this).parent().addClass('active');
        activeInclude = true;
    }
})

$('.include-pages a').click(function () {
    var page = $(this).attr('href').charAt(1).toUpperCase();
    $('.included-spec span').each(function () {
        var name = $(this).html().charAt(0).toUpperCase();
        if (name != page)
            $(this).parent().hide();
        else
            $(this).parent().show();
    });

    $('.include-pages li').each(function () {
        $(this).removeClass('active');
    });

    $(this).parent().addClass('active');
});

var firstCharExclude = '';
var uniquelettersExclude;
var lettersExclude = [];
$('.excluded-spec span').each(function () {
    var name = $(this).html();

    if (firstCharExclude == '')
        firstCharExclude = name.charAt(0);

    if (name.charAt(0) != firstCharExclude)
        $(this).parent().hide();

    lettersExclude.push(name.charAt(0));
});

uniquelettersExclude = Array.from(new Set(lettersExclude));

var activeExclude = false;
$('.exclude-pages a').each(function () {
    var page = $(this).attr('href').charAt(1).toUpperCase();
    var match = false;


    $(uniquelettersExclude).each(function () {
        if (page == this[0])
            match = true;
    });

    if (!match)
        $(this).parent().addClass('disabled');
    else if (!activeExclude && match) {
        $(this).parent().addClass('active');
        activeExclude = true;
    }
})

$('.exclude-pages a').click(function () {
    var page = $(this).attr('href').charAt(1).toUpperCase();
    $('.excluded-spec span').each(function () {
        var name = $(this).html().charAt(0).toUpperCase();
        if (name != page)
            $(this).parent().hide();
        else
            $(this).parent().show();
    });

    $('.exclude-pages li').each(function () {
        $(this).removeClass('active');
    });

    $(this).parent().addClass('active');
});