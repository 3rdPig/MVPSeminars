$(document).ready(function () {
    $('.carousel').carousel();
    var myVar = setInterval(carouselTimer, 2000);

    function carouselTimer() {
        $('.carousel').carousel('next');
    }

    
});