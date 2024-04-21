$(document).ready(function () {
    $('.toggle-content').click(function () {
        // Find the parent card body of the clicked button
        var parentCardBody = $(this).closest('.card-body');

        // Check if the parent card body exists
        if (parentCardBody.length > 0) {
            // Toggle the visibility of content-summary and content-full within the same card body
            parentCardBody.find('.content-summary, .content-full').toggle();
        } else {
            // Find the parent container of the clicked button
            var parentContainer = $(this).closest('.row');

            // Toggle the visibility of content-summary and content-full within the same container
            parentContainer.find('.content-summary, .content-full').toggle();
        }

        // Toggle the visibility of the clicked button and its sibling
        $(this).toggle();
        $(this).siblings('.toggle-content').toggle();
    });
});

function confirmRemove(id) {
    var result = confirm("Are you sure you want to remove this classroom?");
    if (result) {
        var form = document.createElement('form');
        form.method = 'post';
        form.action = '/Admin/Classroom/SoftRemove';

        var hiddenField = document.createElement('input');
        hiddenField.type = 'hidden';
        hiddenField.name = 'id';
        hiddenField.value = id;

        form.appendChild(hiddenField);
        document.body.appendChild(form);
        form.submit();
    }
}
$(document).ready(function () {
    // Toggle navigation bar
    $('.navbar-toggler').on('click', function () {
        var target = $(this).data('target');
        $(target).toggleClass('show');
    });

    // Close navigation bar when a nav item is clicked
    $('.navbar-nav .nav-link').on('click', function () {
        var target = $('.navbar-toggler').data('target');
        $(target).removeClass('show');
    });
});