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