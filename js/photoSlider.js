document.addEventListener("DOMContentLoaded", DocumentEvents, false);
function DocumentEvents() {
    PhotoSlider("project-photo", 4000, "../images/business_applications.png", "../images/webease-pic(responsive design).png", "../images/software-657188_1280.png");
}

function addPicsToCache(l, j, k) {
    var PicsArray = [];
    for (var i = 0; i < arguments.length; i++) {
        PicsArray.push(arguments[i]);
    }
    return PicsArray;
}

function PhotoSlider(element, duration, l, j, k) {
    setInterval(function () {
        document.getElementById(element).setAttribute("src", checkCurrentPicture(element, l, j, k));
    }, duration);
}

function checkCurrentPicture(idOfImageElement, l, j, k) {
    var nextImgUrl = "";
    var PicsArray = addPicsToCache(l, j, k);
    var currentImgUrl = document.getElementById(idOfImageElement).getAttribute("src");
    var k = PicsArray.indexOf(currentImgUrl) === PicsArray.length - 1 ? -1 : PicsArray.indexOf(currentImgUrl);
    for (var i = k + 1; i < PicsArray.length; i++) {
        if (currentImgUrl !== PicsArray[i]) {
            nextImgUrl = PicsArray[i];
        } else {
            continue;
        }
        return nextImgUrl;
    }
};