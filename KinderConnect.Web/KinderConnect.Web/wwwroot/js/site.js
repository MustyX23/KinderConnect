$(document).ready(function () {
    $('.toggle-content').click(function () {
        var parent = $(this).closest('.card-body');
        parent.find('.content-summary, .content-full, .toggle-content').toggle();
    });
});
