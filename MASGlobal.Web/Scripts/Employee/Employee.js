function GetEmployees() {
    var employee = { id: $('#txtid').val() };
    $.ajax({
        url: "/Employee/GetEmployees",
        type: "GET",
        data: employee,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {           
            html = '';
            if (result != null) {
                $.each(result, function (index, value) {
                    html += '<tr>';
                    html += '<td>' + value.id + '</td>';
                    html += '<td>' + value.name + '</td>';
                    html += '<td>' + value.contractTypeName + '</td>';
                    html += '<td>' + value.roleId + '</td>';
                    html += '<td>' + value.roleName + '</td>';
                    html += '<td>' + value.roleDescription + '</td>';
                    html += '<td>' + value.hourlySalary + '</td>';
                    html += '<td>' + value.monthlySalary + '</td>';
                    html += '<td>' + value.annualSalary + '</td>';
                    html += '<tr>';
                });
                $(".temployees").html(html);
            } 
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}