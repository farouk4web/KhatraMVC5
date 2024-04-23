$(document).ready(function () {
    //Remove Post

    $(".post_actions").on("click", ".remove_post_btn", function () {

        var removeMsg = $("#removeMsg").text();

        bootbox.confirm(removeMsg, function (result) {
            if (result) {

                // submit the form
                $("#remove_post_form").submit();

            }
        });

    });
});