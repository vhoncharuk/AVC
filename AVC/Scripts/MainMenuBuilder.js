$(document).ready(function () {

	$.ajax({
		url: '/MenuHandler.ashx',
		method: 'get',
		dataType: 'json',
		success: function (data) {
			buildMenu($('#menu'), data);
			$('#menu').menu();
		}
	});

	function buildMenu(parent, items) {
		$.each(items, function () {
			var li = $('<li id=' + this.CategoryId + ' >' + this.CategoryName + '</li>');
			li.appendTo(parent);

			if (this.List && this.List.length > 0) {
				var ul = $('<ul id=' + this.CategoryId + '></ul>');
				ul.appendTo(li);
				buildMenu(ul, this.List);
			}
		});
	}
});