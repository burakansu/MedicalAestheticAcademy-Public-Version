function Post(url, data, fnSuccess,fnError, fnBeforeSend,fnComplete,dataType) {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: fnSuccess,
        error: fnError,
        beforeSend: fnBeforeSend,
        complete: fnComplete,
        dataType: dataType,
         
    });
}

function Post(url, data, fnSuccess, fnError, fnBeforeSend, fnComplete, dataType,traditional) {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: fnSuccess,
        error: fnError,
        beforeSend: fnBeforeSend,
        complete: fnComplete,
        dataType: dataType,
        traditional:traditional
    });
}

//data - contains the resulting data from the request
//status - contains the status of the request ("success", "notmodified", "error", "timeout", or "parsererror")
//xhr - contains the XMLHttpRequest object

//"xml" - An XML document
//"html" - HTML as plain text
//"text" - A plain text string
//"script" - Runs the response as JavaScript, and returns it as plain text
//"json" - Runs the response as JSON, and returns a JavaScript object
//"jsonp" - Loads in a JSON block using JSONP. Will add an "?callback=?" to the URL to specify the callback

//$.post('/location/TownList', { cityId: cityId }, function (data, status, xhr) {
//    console.log(data);
//}, 'json');