

function createAlert(message, type) {
    var alertElement = document.createElement('div');
    alertElement.classList.add('alert', 'alert-' + type);
    alertElement.innerText = message;

    var container = document.getElementById('alert-container');
    container.appendChild(alertElement);

    setTimeout(function () {
        alertElement.classList.add('hide');
        setTimeout(function () {
            container.removeChild(alertElement);
        }, 10);
    }, 5000);
}


function handleSearchFormSubmit() {
    var form = document.getElementById("search-form");
    var input = document.getElementById("search-input");

    input.addEventListener("keypress", function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            form.submit();
        }
    });
}


