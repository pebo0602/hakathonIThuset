



function formatResultDiv(resultObj) {
       
       var result = "<div class='search-result'>" + 
                "<h3> Title: " + resultObj.title + "</h3>" +
                "<h5> Creator: " + resultObj.creator + "</h5>" +
                "<br>" + 
                "<strong> Date: </strong>" + resultObj.date +
                "<br>" + 
                "<strong> Language: " + resultObj.language + 
                "<br>";

        if(resultObj.isbn != "undefined") {
            result += "<a href='/Home/Book/" + resultObj.isbn + "'>View related books</a>"
            }
                     
        result += "</div>"

        return result;
}