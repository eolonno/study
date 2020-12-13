$(function(){
$('.menu-item').mouseover(function() {
    $(this).children().css("display", "block");
});

$('.menu-item').mouseout(function() {
    $(this).children().css("display", "none");
});
});