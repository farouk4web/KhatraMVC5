$(document).ready(function () {
    //Remove Post

    $(".post_actions").on("click", ".remove_post_btn", function () {

        var removeMsg = $("#removeMsg").text(),
            btn = $(this),
            postId = btn.attr("data-id");

        bootbox.confirm(removeMsg, function (result) {
            if (result) {
                $.ajax({
                    url: "/posts/Remove/" + postId,
                    method: "Post",
                    success: function () {
                        btn.parents(".col-sm-4").remove();
                    }
                });
            }
        });

    });
});