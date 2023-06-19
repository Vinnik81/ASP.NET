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

function stopAudio(a) {
    audioElement = a;
}

//var audioElements = document.getElementsByTagName('audio');
//for (var i = 0; i < audioElements.length; i++) {
//    audioElements[i].addEventListener("play", function () {
//        // При нажатии на тег audio, останавливаем воспроизведение остальных треков
//        for (var j = 0; j < audioElements.length; j++) {
//            if (audioElements[j] != this) {
//                audioElements[j].pause();
//                audioElements[j].currentTime = 0;
//            }
//        }
//    });
//}

$('audio').on('play', function () {
    // При нажатии на тег audio, останавливаем воспроизведение остальных треков
    $('audio').not(this).each(function () {
        this.pause();
        this.currentTime = 0;
    });
});
