﻿$(document).ready(function () {
    GetCountry();
    $('#State').attr('disabled', true);
    $('#City').attr('disabled', true);
    $('#Country').change(function () {
        $('#State').attr('disabled', false);
        var id =$(this).val();
        $('#State').empty();
        $('#State').append('<option>--Select State--</option>');
        $.ajax({
            url: '/Cascade/State?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#State').append('<Option value=' + data.id + '>' + data.name + '</Option>');
                });
            }
        });

    });


    $('#State').change(function () {
        $('#City').attr('disabled', false);
        var id = $(this).val();
        $('#City').empty();
        $('#City').append('<option>--Select City--</option>');
        $.ajax({
            url: '/Cascade/City?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#City').append('<Option value=' + data.id + '>' + data.name + '</Option>');
                });
            }
        });

    });
});

function GetCountry() {
    $.ajax({
        url: '/Cascade/Country',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Country').append('<option value=' + data.id + '>' + data.name + '</option>');
            });
        }
    });
}