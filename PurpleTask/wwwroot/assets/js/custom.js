const loadMore = document.querySelector('.loadMore');
loadMore.addEventListener('click', Load);

function Load() {
    let serviceCount = $('.products').children().length
    fetch("/Work/LoadMore?skip=" + serviceCount)

        .then(response => response.text())
        .then(text => {
            $('.products').append(text)
            lastCount = $(".products").children().length
            if (serviceCount + 4 > lastCount) {
                loadMore.remove();
            }
        })
}