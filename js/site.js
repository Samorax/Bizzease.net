document.addEventListener("DOMContentLoaded", DocumentEvents, false);

function DocumentEvents()
{
    homeSubmit();
    linkScroll("click", "startNew", "firstP");
    linkScroll("click", "alreadyBiz", "secP");
    linkScroll("click", "yDiff", "thirdP");
    linkScroll("click", "oFe", "fourthP");
}

function homeSubmit() {
    $("#homeSubmit").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/HomeContactForm",
            type: "Post",
            beforeSend: function () { $("#sendLoader").css("visibility", "visible"); },
            data: $("#homeContactForm").serialize(),
            success: function (data) {
                $("#sendLoader").css("visibility", "hidden");
                var feedBack = document.getElementById("feedbackMessage");
                    feedBack.innerHTML = data;
            }
        })
    });
};

function linkScroll(event, firstId, secondId) {
    var firstLink = document.getElementById(firstId);
    firstLink.addEventListener(event, function () {
        var documentHeight = document.documentElement.offsetHeight;
        var viewportHeight = document.getElementById(secondId).getBoundingClientRect().y;
        window.scrollTo(0, documentHeight - viewportHeight)
    }, false);
};







