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

let page;
let totalPages;
let url;

function initPagination(p, t, u) {
    page = p;
    totalPages = t;
    url = u;
}

//$('#buttonNext').click(async function () {
//    page++;

//    if (page < totalPages) {
//        ///Home/SearchResult?title=Hulk&page=
//        let response = await fetch(`${url}&page=${page}`);
//        let html = await response.text();
//        console.log(html);
//        $('#movieResults').append(html);
//    } else {
//        $(this).remove();
//    }

//});

let isScroll = true;
$(window).scroll(async function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 150 && isScroll) {
        isScroll = false;
        page++;

        if (page < totalPages) {
            console.log(page);
            ///Home/SearchResult?title=Hulk&page=
            let response = await fetch(`${url}&page=${page}`);
            let html = await response.text();
            $('#movieResults').append(html);
            isScroll = true;
        } else {
            $(this).remove();
        }
    }
})