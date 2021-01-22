//header 菜单
$(function () {
    var banner = new Swiper('.banner',{
        autoplay: 5000,
        pagination : '.swiper-pagination',
        paginationClickable: true,
        lazyLoading : true,
        loop:true
    });

     $('a.slide-menu').on('click', function(e){
		var wh = $('div.wrapper').height();
		$('div.slide-mask').css('height', wh).show();
		$('aside.slide-wrapper').css('height', wh).addClass('moved');
	});
	
	$('div.slide-mask').on('click', function(){
		$('div.slide-mask').hide();
		$('aside.slide-wrapper').removeClass('moved');
	});
    

});

/*(function($, doc) {
	$.init();
	$.ready(function() {
		var UsersPicker = new $.PopPicker();
		UsersPicker.setData([{
			value: '',
			text: '支付宝'
		}, {
			value: '',
			text: '微信'
		}]);
		var showUsersPickerButton = doc.getElementById('showUsersPicker');
		var UsersResult = doc.getElementById('UsersResult');
		showUsersPickerButton.addEventListener('tap', function(event) {
			UsersPicker.show(function(items) {
				UsersResult.innerText = JSON.stringify(items[0]);
			});
		}, false);
	
	
	});
})(mui, document);

(function($, doc) {
	$.init();
	$.ready(function() {
		var UsersPicker = new $.PopPicker();
		UsersPicker.setData([{
			value: '',
			text: '现金'
		}, {
			value: '',
			text: '现金+积分'
		}]);
		var showUsersPickerButton = doc.getElementById('showUsersPickerthree');
		var UsersResult = doc.getElementById('UsersResult');
		showUsersPickerButton.addEventListener('tap', function(event) {
			UsersPicker.show(function(items) {
				UsersResult.innerText = JSON.stringify(items[0]);
			});
		}, false);
	
	
	});
})(mui, document);


(function($, doc) {
	$.init();
	$.ready(function() {
		var UsersPicker = new $.PopPicker();
		UsersPicker.setData([{
			value: '',
			text: '安徽'
		}, {
			value: '',
			text: '湖南'
		}]);
		var showUsersPickerButton = doc.getElementById('showUsersPickertwo');
		var UsersResult = doc.getElementById('UsersResult');
		showUsersPickerButton.addEventListener('tap', function(event) {
			UsersPicker.show(function(items) {
				UsersResult.innerText = JSON.stringify(items[0]);
			});
		}, false);
	
	
	});
})(mui, document);*/