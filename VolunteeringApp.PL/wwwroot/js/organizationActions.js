$(document).ready(() => {

    $('.aproveBtn').click((event) => {
        const organizationId = $(event.target).data('id');
        $.ajax({
            type: 'POST',
            url: '/api/Admin/ChangeOrganizationStatus?organizationId=' + organizationId + '&status=Accepted',
            success: function () {
                location.reload();
            }
        });
    });
    $('.rejectedBtn').click((event) => {
        const organizationId = $(event.target).data('id');
        $.ajax({
            type: 'POST',
            url: '/api/Admin/ChangeOrganizationStatus?organizationId=' + organizationId + '&status=Rejected',
            success: function () {
                location.reload();
            }
        });
    });
});