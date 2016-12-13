//At a time, bounce a certain element.
//At a certain time interval switch from the bounced element to the to-be bounced element.
document.addEventListener("DOMContentLoaded", bouncingEvents, false);
function bouncingEvents() {
   // bounceElement();
}

function bounceElement(className) {
    setInterval(function () {$(checkCurrentElement(className)).fadeOut().fadeIn() },5);
}
var bouncedElements = [];
var nextToBounce = null;
var k = null;
function checkCurrentElement(className) {

    var toBounceElements = document.getElementsByClassName(className);
    if (bouncedElements.length === toBounceElements.length) {
        k = -1;
        bouncedElements = [];
    }else
        k = bouncedElements.lastIndexOf(bouncedElements[bouncedElements.length - 1]);

    for (var i = k + 1; i < toBounceElements.length; i++) {
        if (bouncedElements.indexOf(toBounceElements[i]) === -1){
            nextToBounce = toBounceElements[i];
            bouncedElements.push(toBounceElements[i]);
            break;
        }  
        else
            continue;

    }
    return nextToBounce;
    
}