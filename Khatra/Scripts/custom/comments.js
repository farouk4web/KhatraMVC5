$(document).ready(function () {

    //Remove Comment
    $(".comment").on("click", ".js_remove_comment", function () {

        var removeMsg = $("#removeMsg").text(),
            btn = $(this),
            commentId = btn.attr("data-id");

        bootbox.confirm(removeMsg, function (result) {
            if (result) {
                $.ajax({
                    url: "/Comments/Remove/" + commentId,
                    method: "Post",
                    success: function () {
                        btn.parents(".comment").remove();
                    }
                });
            }
        });
    });

});