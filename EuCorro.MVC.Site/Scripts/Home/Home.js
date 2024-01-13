// This code use https://github.com/whizzzkid/instagram-reverse-proxy api to access instagram public photos without userid

// Loading page
var loaderPage = function () {
	$(".preloader").fadeOut("slow");
};

$(function () {
	userName = "eucorromais",
	num_photos = 12;

	loaderPage();

	$.ajax({
		url: 'https://igapi.ga/' + userName + '/media/?count=' + num_photos,
		dataType: 'jsonp',
		type: 'GET',
		success: function (data) {
			for (x in data.items) {
				$('ul.organizer-instagram-preview').append('<li><img src="' + data.items[x].images.standard_resolution.url + '"></li>');
			}
		},
		error: function (data) {
			console.log(data);
		}
	});

});

$(function (d, s, id) {
	var js, fjs = d.getElementsByTagName(s)[0];
	if (d.getElementById(id)) return;
	js = d.createElement(s); js.id = id;
	js.src = "//connect.facebook.net/pt_BR/sdk.js#xfbml=1&version=v2.4&appId=1417158085183612";
	fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));