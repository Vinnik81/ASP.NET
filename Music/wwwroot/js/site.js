// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let page;
let totalPages;
let url;

function initPagination(p, t, u) {
    page = p;
    totalPages = t;
    url = u;
}

//let page = @Model.CurrentPage;
let isLoading = true;

$(window).scroll(async function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 150 && isLoading) {
        isLoading = false;
        page++;

        if (page < totalPages) {
            console.log(page);
            let response = await fetch(`${url}&page=${page}`);
            let html = await response.text();
            console.log(html);
            $('#musicResults').append(html);
            isLoading = true;
        }
        else {
            $(this).remove();
        }
    }
});