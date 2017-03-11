



function formatResultDiv(resultObj) {

    var result = "<div class='search-result'>" +
             "<h3> Title: " + resultObj.title + "</h3>" +
             "<h5> Creator: " + resultObj.creator + "</h5>" +
             "<br>" +
             "<strong> Date: </strong>" + resultObj.date +
             "<br>" +
             "<strong> Language: " + resultObj.language +
             "<br>";

    if (resultObj.isbn) {
        var isbn = resultObj.isbn;
        if (isbn instanceof Array) {
            isbn = isbn[0];
        }
        result += "<a href='/Home/Book/" + isbn + "'>View related books</a>"
    }

    result += "</div>"

    return result;
}

function formatSearchResult(object) {
    var result = "<div class='search-result'>" +
        "<span class='title'>" + object.title + "</span>" +
        "<span class='creator'>" + object.creator + "</span>";

    if (object.isbn) {
        var isbn = object.isbn;
        if (isbn instanceof Array) {
            isbn = isbn[0];
        }
        result += "<a href='/Home/Book/" + isbn + "'><i class='fa fa-external-link fa-1x'></i></a>"
    }

    return result;
}