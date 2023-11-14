// to get the current year
function getYear() {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    $("#displayYear").text(currentYear);
}

// Call getYear function when the document is ready
$(function () {
    getYear();

    // nice select
    $('select').niceSelect();
});
