//function filterNews(type) {
//    //const cards = document.querySelectorAll('.news-card');
//    //cards.forEach(card => {
//    //    if (type === 'all' || card.classList.contains(type)) {
//    //        card.style.display = 'block';
//    //    } else {
//    //        card.style.display = 'none';
//    //    }
//    //});

//    const buttons = document.querySelectorAll('.filter-button');
//    const newsItems = document.querySelectorAll('.news-card');

//    buttons.forEach(button => {
//            const category = this.getAttribute('data-category');

//            newsItems.forEach(item => {
//                if (category === "" || item.getAttribute('data-category') === category) {
//                    item.style.display = ''; // إظهار العنصر
//                } else {
//                    item.style.display = 'none'; // إخفاء العنصر
//                }
//            });
//        });
//}


function filterNews(category, itemCount) {
    const newsItems = document.querySelectorAll('.news-card');
    newsItems.forEach(item => {
        if (category === "" || item.getAttribute('data-category') === category) {
            item.style.display = 'block'; // إظهار العنصر
        } else {
            item.style.display = 'none'; // إخفاء العنصر
        }
    });
}


