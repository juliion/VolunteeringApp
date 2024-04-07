$(document).ready(() => {

    $('.aproveBtn').click((event) => {
        const opportunityId = $(event.target).data('id');
        $.ajax({
            type: 'POST',
            url: '/api/Admin/ChangeOpportunityStatus?opportunityId=' + opportunityId + '&status=Accepted',
            success: function () {
                location.reload();
            }
        });
    });
    $('.rejectedBtn').click((event) => {
        const opportunityId = $(event.target).data('id');
        $.ajax({
            type: 'POST',
            url: '/api/Admin/ChangeOpportunityStatus?opportunityId=' + opportunityId + '&status=Rejected',
            success: function () {
                location.reload();
            }
        });
    });
});