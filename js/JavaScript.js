var Secretnumber = {
    init: function () {
        var guessbox = document.getElementById("GuessBox");
        var guessbutton = document.getElementById("GuessButton");
        var result = document.getElementById("Result");
        var retry = document.getElementById("RetryButton");

        guessbox.focus();
        guessbox.select();

        guessbutton.onclick = function(){
            if (guessbox.value === null || guessbox.value === "") {
                var errortext = document.createTextNode("Fältet får ej vara tomt!");
                result.appendChild(errortext);
                return false;
            }
            else if (parseInt(guessbox.value) > 100 || parseInt(guessbox.value) < 1) {
                var errortext = document.createTextNode("Värdet måste ligga mellan 1 och 100!");
                result.appendChild(errortext);
                return false;
            }
            else
                result.removeChild(errortext);
        }

        retry.onclick = function () {
            location.reload();
        }
    },

};

window.onload = Secretnumber.init;