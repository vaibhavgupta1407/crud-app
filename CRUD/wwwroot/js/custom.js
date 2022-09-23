$(document).ready(function () {
    ShowEmployeeData();
});

function ShowEmployeeData() {
    $.ajax({
        url: '/Ajax/EmployeeList',
        type: 'Get',
        dataType: 'json',
        contentType: ' application / json; charset=utf - 8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>' + item.n ame + '</td>';
                object += '<td>' + item.state + '</td>';
                object += '<td>' + item.city + '</td>';
                object += '<td>' + item.salary + '</td>';
                object += '<td><a href="#" class="btn btn-primary">Edit</a>||<a href="#" class="btn btn-danger">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't get");
        }
    });
};