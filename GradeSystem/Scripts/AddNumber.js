$(document).ready(function () {

    //post data using ajax:
    $('#add').click(function () {
        var first_num = $('#firstNum').val();
        var second_num = $('#secondNum').val();

        $.ajax({
            type: "post",
            url: "Home/Add",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ x: first_num, y: second_num })
        }).done(function (r) {
            $('#message').html("Success!");
            $('#result').val(JSON.parse(r));
        }).fail(function (result) {
            $('#message').html("Sorry! Something went wrong!");
        })

    })


})