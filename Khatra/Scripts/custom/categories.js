$(document).ready(function () {

    $(".category_actions").on("click", ".remove_category_btn", function () {
        var removeMsg = $("#removeMsg").text();

        bootbox.confirm(removeMsg, function (result) {
            if (result) {
                $("#remove_category_form").submit();
            }
        });
    });

});
