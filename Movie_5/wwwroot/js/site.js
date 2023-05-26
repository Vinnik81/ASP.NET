// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('[data-open-modal]').click(async function () {
    $('.modal-body').html("<div class='spinner-border text-primary' role='status'><span class='visually-hidden'> Loading...</span></div>");
    $("#exampleModal").modal('show');
    event.preventDefault();
    let url = $(this).attr('href');
    let response = await fetch(url);
    let result = await response.text();

    $('.modal-body').html(result);
    console.log(url);
});

