document.addEventListener("DOMContentLoaded", missionCaption, false);

function missionCaption() {
    $(".indexImages").each(function(){
        $(this).bind("mouseover",function(){
            $(".mission-caption",this.parentElement).css("visibility","visible").addClass("animated").addClass("slideInUp");
        })
    })
}

