


function GetAutoCompleteData(id, relationshipname, tablename, fieldname, condition, fields_to_update) {
    $(function () {

        $('#' + id).autocomplete({
            minLength: 1,
            source: function (request, response) {
                var inputJson = "{";
                inputJson += "\"inputText\":\"" + request.term + "\",";
                inputJson += "\"tablename\":\"" + tablename + "\",";
                inputJson += "\"fieldname\":\"" + fieldname + "\",";
                inputJson += "}";
                $.ajax({
                    url: 'Index?handler=AutoCompleteData&input=' + inputJson + '&condition=' + condition,
                    success: function (data) {
                        
                        var fields_data = JSON.parse(data);
                        response($.map(fields_data, function (item) {
                            return { value: item[fieldname], fields_data: item }
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            },
            select: function (e, selected) {
                OnSelectItem(selected, relationshipname, tablename, fieldname, fields_to_update);
            }

        });
    });
}



function OnSelectItem(selected, relationshipname, tablename, fieldname, fields_to_update) {
    if (fields_to_update != "") {
        //console.log(fields_to_update);
        var input = JSON.parse(fields_to_update);
        for (var i = 0; i < input.length; i++) {
            var autofill_fields = input[i].fields;
            if (tablename == input[i].entity_name) {
                $.map(selected.item.fields_data, function (val, i) {
                    if (autofill_fields.includes(i)) {
                        if ($("#" + relationshipname + tablename + "_" + i).prop('tagName') == "IMG") {
                            var newJ = $.parseJSON(val);
                            $("#" + relationshipname + tablename + "_" + i).attr("src", "Uploads/" + newJ["ref_file_name"]);
                        }
                        else {
                            $("#" + relationshipname + tablename + "_" + i).val(val);
                        }
                    }
                    
                });
            }
            else {
                //console.log("----Not Same Entity----");
                var inputJson = "{";
                inputJson += "\"inputText\":\"" + selected.item.value + "\",";
                inputJson += "\"tablename\":\"" + tablename + "\",";
                inputJson += "\"fieldname\":\"" + fieldname + "\",";
                inputJson += "\"output_tablename\":\"" + input[i].entity_name + "\",";
                inputJson += "\"relationship_name\":\"" + input[i].relationship_name + "\",";
                inputJson += "}";

                var fields_count = input[i].fields.length;
                var output_tablename = input[i].entity_name;
                var fields_type = $('#' + relationshipname + output_tablename + "_" + input[i].fields[0]).prop('tagName');
                var field_name = input[i].fields[0];
                

                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/GetAutoFillData",
                    data: "{'json':'" + inputJson + "'}",
                    dataType: "json",
                    contentType: "application/json; charset = utf-8",

                    success: function (data) {

                        if (fields_count == 1 && fields_type == "SELECT") {
                            let select = document.querySelector("#" + relationshipname + output_tablename + "_" + field_name);                           
                            var data = JSON.parse(data.d);
                            if (!select.hasAttribute('multiple')) {
                                var s = '<option value="-1">Please Select</option>';
                                for (var i = 0; i < data.length; i++) {
                                    s += '<option value="' + data[i]["PKID" + output_tablename] + '">' + data[i][field_name] + '</option>';
                                }
                                $("#" + relationshipname + output_tablename + "_" + field_name).html(s);
                            }
                            else {
                                $("#" + output_tablename + "_" + field_name).multiselect('clearSelection');
                                for (var i = 0; i < data.length; i++) {
                                    $("#" + relationshipname + output_tablename + "_" + field_name).multiselect('select', JSON.stringify(data[i]).replaceAll(" ", "\T"));
                                }
                            }
                        }

                        else {
                            var fields_data = JSON.parse(data.d);
                            console.log(fields_data);
                            $.map(fields_data[0], function (val, i) {
                                console.log(tablename);
                                if (autofill_fields.includes(i))
                                    $("#" + relationshipname + output_tablename + "_" + i).val(val);
                            });
                        }
                    }
                });
            }
        }
    }

}


function OnDDSelectItem(selected,relationshipname, tablename, fieldname, fields_to_update) {
    let select = document.querySelector("#" + relationshipname + tablename + "_" + fieldname);
    if (select.hasAttribute('multiple')) {
        var obj = $("#" + relationshipname + tablename + "_" + fieldname).val();
        var a = obj.toString().replaceAll("\T", " ");
        $("#text_" + relationshipname + tablename + "_" + fieldname).val(a);
    }
    else
        $("#text_" + relationshipname + tablename + "_" + fieldname).val(selected);

    if (fields_to_update != "") {
        var input = JSON.parse(fields_to_update);
        for (var i = 0; i < input.length; i++) {
            var autofill_fields = input[i].fields;
            if (tablename == input[i].entity_name) {
                var inputJson = "{";
                inputJson += "\"inputText\":\"" + selected + "\",";
                inputJson += "\"tablename\":\"" + tablename + "\",";
                inputJson += "\"fieldname\":\"" + fieldname + "\",";
                inputJson += "\"columns\":\"" + input[i].fields.join(",") + "\",";
                inputJson += "}";

                $.ajax({
                    url: 'Index?handler=AutoFillEntityData&input=' + inputJson,
                    success: function (data) {
                        var fields_data = JSON.parse(data);
                        $.map(fields_data[0], function (val, i) {
                            if ($("#" + relationshipname + tablename + "_" + i).prop('tagName') == "IMG") {
                                var newJ = $.parseJSON(val);
                                $("#" + relationshipname + tablename + "_" + i).attr("src", "Uploads/" + newJ["ref_file_name"]);
                            }
                            else {
                                //console.log(autofill_fields);
                                if (i != fieldname) {
                                    console.log(i);
                                    $("#" + relationshipname + tablename + "_" + i).val(val);
                                }
                            }
                        });

                    }


                });


            }
            else {
                console.log("Not Same Entity");
                var inputJson = "{";
                inputJson += "\"inputText\":\"" + selected + "\",";
                inputJson += "\"tablename\":\"" + tablename + "\",";
                inputJson += "\"fieldname\":\"" + fieldname + "\",";
                inputJson += "\"output_tablename\":\"" + input[i].entity_name + "\",";
                inputJson += "\"relationship_name\":\"" + input[i].relationship_name + "\",";
                inputJson += "}";

                var fields_count = input[i].fields.length;
                var output_tablename = input[i].entity_name;
                var fields_type = $('#' + output_tablename + "_" + input[i].fields[0]).prop('tagName');
                var field_name = input[i].fields[0];

                $.ajax({
                    type: "POST",
                    url: "/Default.aspx/GetAutoFillData",
                    data: "{'json':'" + inputJson + "'}",
                    dataType: "json",
                    contentType: "application/json; charset = utf-8",

                    success: function (data) {

                       

                        if (fields_count == 1 && fields_type == "SELECT") {
                            let select = document.querySelector("#" + relationshipname + output_tablename + "_" + field_name);
                            var data = JSON.parse(data.d);
                            if (!select.hasAttribute('multiple')) {
                                var s = '<option value="-1">Please Select</option>';
                                for (var i = 0; i < data.length; i++) {
                                    s += '<option value="' + data[i]["PKID" + output_tablename] + '">' + data[i][field_name] + '</option>';
                                }
                                $("#" + relationshipname + output_tablename + "_" + field_name).html(s);
                            }
                            else {
                                $("#" + output_tablename + "_" + field_name).multiselect('clearSelection');
                                for (var i = 0; i < data.length; i++) {
                                    $("#" + relationshipname + output_tablename + "_" + field_name).multiselect('select', JSON.stringify(data[i]).replaceAll(" ", "\T"));
                                }
                            }
                        }

                        else {
                            var fields_data = JSON.parse(data.d);
                            $.map(fields_data[0], function (val, i) {
                                if (autofill_fields.includes(i))
                                    if ($("#" + tablename + "_" + i).prop('tagName') == "IMG") {
                                        var newJ = $.parseJSON(val);
                                        $("#" + output_tablename + "_" + i).attr("src", "Uploads/" + newJ["ref_file_name"]);
                                    }
                                    else {
                                        $("#" + output_tablename + "_" + i).val(val);
                                    }
                            });
                        }
                    }
                });
            }
        }
    }

}


function loadDropDown(inputdata) {
    var input = JSON.parse(inputdata);
    for (var i = 0; i < input.length; i++) {
        var id = input[i].id;
        var inputJson = "{";
        inputJson += "\"tablename\":\"" + input[i].tablename + "\",";
        inputJson += "\"fieldname\":\"" + input[i].fieldname + "\",";
        inputJson += "}";
        var fieldname = input[i].fieldname;
        var tablename = input[i].tablename;
        $.ajax({
            url: 'Index?handler=AutoFillEntityData&input=' + inputJson,          
            success: function (data) {
                let btn = document.querySelector("#" + id);
                if (btn.hasAttribute('multiple'))
                    var s = '';              
                else
                    var s = '<option value="-1">Please Select</option>';
                var data = JSON.parse(data);               
                for (var i = 0; i < data.length; i++) {
                    s += '<option value=' + JSON.stringify(data[i]).replaceAll(" ", "\T") + '>' + data[i][fieldname] + '</option>';
                }
                $("#" + id).html(s);
            }
        });
    }
}


function GetAutoCompleteDataMultiple(id, relationshipname, tablename, fieldname, condition, fields_to_update) {
    console.log(id);
    const arr = [];
    $('#' + id).tokenfield({

        autocomplete: {
            source: function (request, response) {
                var inputJson = "{";
                inputJson += "\"inputText\":\"" + request.term + "\",";
                inputJson += "\"tablename\":\"" + tablename + "\",";
                inputJson += "\"fieldname\":\"" + fieldname + "\",";
                inputJson += "}";
                $.ajax({
                    url: "/Default.aspx/GetAutoCompleteData",
                    data: "{'input':'" + inputJson + "','condition':'" + condition + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset = utf-8",
                    success: function (data) {
                        var fields_data = JSON.parse(data.d);
                        response($.map(fields_data, function (item) {
                            return { value: item[fieldname], fields_data: JSON.stringify(item).replaceAll(" ", "\T") }
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });

                delay: 100
            },


            select: function (e, selected) {
                var a = selected.item.fields_data.toString().replaceAll("\T", " ");
                if (!arr.includes(selected.item.value)) {
                    $("#text_" + id).val($("#text_" + id).val() + a + ",");
                    console.log($("#text_" + id).val());
                    arr.push(selected.item.value);
                }

            }
        }
    })
}