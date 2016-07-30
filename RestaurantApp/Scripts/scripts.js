// Drop down animation for the menu link
$('ul.nav li.dropdown').hover(
	function () { $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeIn(300); }, 
	function () { $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeOut(300); }
);