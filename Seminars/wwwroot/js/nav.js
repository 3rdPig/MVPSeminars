// Write your Javascript code.
$('.dropdown-button-join').dropdown
(
    {
        inDuration: 300,
        outDuration: 225,
        constrain_width: false, // Does not change width of dropdown to that of the activator
        hover: true, // Activate on hover
        gutter: ($('.dropdown-content').width()) / 2, // Spacing from edge
        belowOrigin: false, // Displays dropdown below the button
        alignment: 'left' // Displays dropdown with edge aligned to the left of button
    }
);
$('.dropdown-button-harassment').dropdown
(
    {
        inDuration: 300,
        outDuration: 225,
        constrain_width: false, // Does not change width of dropdown to that of the activator
        hover: true, // Activate on hover
        gutter: ($('.dropdown-content').width()) /2, // Spacing from edge
        belowOrigin: false, // Displays dropdown below the button
        alignment: 'left' // Displays dropdown with edge aligned to the left of button
    }
);
$('.dropdown-button-certs').dropdown
(
    {
        inDuration: 300,
        outDuration: 225,
        constrain_width: false, // Does not change width of dropdown to that of the activator
        hover: true, // Activate on hover
        gutter: ($('.dropdown-content').width()) / 2, // Spacing from edge
        belowOrigin: false, // Displays dropdown below the button
        alignment: 'left' // Displays dropdown with edge aligned to the left of button
    }
);

/* Social Link Bar */
var docked = true;
$('.dock').click(function () {
    console.log("begin");
    if (docked) {
        docked = false;
        $('.landing').show();
        console.log("click");
    } else {
        docked = true;
        $('.landing').hide();
        console.log("clicky");
    }
});