$(document).ready(function () {
    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());

    $("#UtmSource").val(params.utm_source);
    $("#UtmCampaign").val(params.utm_campaign);
    $("#UtmContent").val(params.utm_content);
    $("#UtmMedium").val(params.utm_medium);
});