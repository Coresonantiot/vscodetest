function pastDateTime(field, rules, i, options) {

    var max_datetime = rules[i + 2];

    const onlyNumbers = max_datetime.replace(/\D/g, "");
    const year = onlyNumbers.slice(0, 4)
    const month = onlyNumbers.slice(4, 6)
    const day = onlyNumbers.slice(6, 8)
    const hour = onlyNumbers.slice(8, 10)
    const min = onlyNumbers.slice(10, 12)
    const sec = onlyNumbers.slice(12, 14)
    var maxdate = new Date(year, month-1, day, hour, min, sec);

    if (Date.parse(field.val()) > maxdate.getTime()) {
        return "DateTime Should Less Than " + maxdate.toLocaleString();

    }

}


function futureDateTime(field, rules, i, options) {

    var min_datetime = rules[i + 2];

    const onlyNumbers = min_datetime.replace(/\D/g, "");
    const year = onlyNumbers.slice(0, 4)
    const month = onlyNumbers.slice(4, 6)
    const day = onlyNumbers.slice(6, 8)
    const hour = onlyNumbers.slice(8, 10)
    const min = onlyNumbers.slice(10, 12)
    const sec = onlyNumbers.slice(12, 14)
    var mindate = new Date(year, month - 1, day, hour, min, sec);

    if (Date.parse(field.val()) < mindate.getTime()) {
        return "DateTime Should Greater Than " + mindate.toLocaleString();

    }

}


function pastTime(field, rules, i, options) {

    var max_time = rules[i + 2];
    var max_time1 = max_time.split(':');

    var input_val = field.val();
    input_val = input_val.split(':');

    totalSeconds1 = parseInt(max_time1[0] * 3600 + max_time1[1] * 60 + max_time1[0]);
    totalSeconds2 = parseInt(input_val[0] * 3600 + input_val[1] * 60 + input_val[0]);

    if (totalSeconds2 > totalSeconds1) {
        return "Time Should Less Than " + max_time;
    }

}


function futureTime(field, rules, i, options) {

    var min_time = rules[i + 2];
    var min_time1 = min_time.split(':');

    var input_val = field.val();
    input_val = input_val.split(':');

    totalSeconds1 = parseInt(min_time1[0] * 3600 + min_time1[1] * 60 + min_time1[0]);
    totalSeconds2 = parseInt(input_val[0] * 3600 + input_val[1] * 60 + input_val[0]);

    if (totalSeconds2 < totalSeconds1) {
        return "Time Should Greater Than " + min_time;
    }

}


function fileExtensionCheck(field, rules, i, options) {

    var file_extensions = rules[i + 2];
    var file = field.val();
    var extension = file.substr((file.lastIndexOf('.') + 1));
    //var allowed_extensions = '/(' + file_extensions + ')$/ig';
    var allowed_extensions = [...file_extensions.split('|')];
    if (!(allowed_extensions.indexOf(extension) !== -1)) {

        return "Invalid File Extension.Choose " + file_extensions.replaceAll('|',',');
    }
        
}


function fileSizeCheck(field, rules, i, options) {

    var nBytes = 0,
    oFiles = document.getElementById(elementId).files,
    nFiles = oFiles.length;

    for (var nFileId = 0; nFileId < nFiles; nFileId++) {
        nBytes += oFiles[nFileId].size;
    }
    var sOutput = nBytes + " bytes";
    // optional code for multiples approximation
    for (var aMultiples = ["K", "M", "G", "T", "P", "E", "Z", "Y"], nMultiple = 0, nApprox = nBytes / 1024; nApprox > 1; nApprox /= 1024, nMultiple++) {
        sOutput = " (" + nApprox.toFixed(3) + aMultiples[nMultiple] + ")";
    }

}



//function doCheckUnique(url, type, data) {
function doCheckUnique(field, rules, i, options) {

    var url = rules[i + 2];
    var type = rules[i + 3];
    var data = '{"fname":"' + rules[i + 4] + '","fvalue":"' + field.val() + '"}';
    var result;

    $.ajax({
        url: url,
        dataType: 'json',
        type: type,
        async: false,
        contentType: 'application/json',
        data: data,
        processData: false,
        success: function (data, textStatus, jQxhr) {
            result = data.d;

        },
        error: function (jqXhr, textStatus, errorThrown) {
            throw errorThrown;
        }
    });

    if (result > 0) {
        return "Given Value Already Exists";
    }
}

function creditCardCheck(field, rules, i, options) {
    var re16digit = /^\d{16}$/
    if (field.val().search(re16digit) == -1)
        return "Please enter your 16 digit credit card numbers";
    //return false; 
//Checking Sumanth	

}





