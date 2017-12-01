
$(document).ready()
{

    function MakeVisiable() {

        var ThisElement = document.getElementById("NavigationMenu");
        var ThisElementOpacity = document.getElementById("NavigationMenuOpacity");
        var ThisMenuBar = document.getElementById("menuBar");


        if (ThisElement.style.visibility == "visible") {
            ThisElement.style.visibility = "hidden";

        }
        else {
            ThisElement.style.visibility = "visible";
        }

    }

    function MakeHidden() {
        var ThisElement = document.getElementById("NavigationMenu");
        ThisElement.style.visibility = "collapse";
    }


}


$(document).click(
    function (event) {
        if (!$(event.target).closest('#NavigationMenu').length && !$(event.target).closest('#DropDownMenu').length) {
            if ($('#NavigationMenu').is(":visible")) {
                $('#NavigationMenu').css("visibility", "hidden");
            }
        }
    }
        );

