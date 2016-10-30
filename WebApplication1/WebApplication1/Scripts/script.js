$( document ).ready(function() {
// --------------Общеее-----------------------------
// --------------Адаптивное меню-----------------------------
 $('.toggle-nav').click(function (e) {
        $(this).toggleClass('active');
        $('.navigation ul').toggleClass('active');

        e.preventDefault();
    });
// --------------Для перехода к контактам-----------------------------
    $(".click").on("click","a", function (event) {
        event.preventDefault();
        var id  = $(this).attr('href'),
            top = $(id).offset().top;
        $('body,html').animate({scrollTop: top}, 1500);
    });
 
 // --------------Ссылка на группу в вк-----------------------------
 $('.vk_button').click(function (e) {
        location.href = 'https://vk.com/bigfamilyzp';

    });
// --------------Index Счетчик-----------------------------
var time = 0.5;
var repeat = true;
 $(window).scroll(function() {
    if ($(this).scrollTop() > 400) {
        if(repeat != true) return;
        repeat = false;
$('#counter').each(function(){
  var i = 1,
      num = $(this).data('num'),
      step = 1000 * time / num,
      that = $(this),
      int = setInterval(function(){
        if (i <= num) {
          that.html(i);
        }
        else {
          clearInterval(int);
        }
        i++;
      },step);
});

       
     }
 });

});