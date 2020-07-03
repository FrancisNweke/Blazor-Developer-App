function saveMessage(firstname, lastname) {
    //alert(firstname + " " + lastname + " has been saved successfully");

    document.getElementById("divServerValidation").innerText = firstname + " " + lastname + " has been saved successfully.";
}

function setFocusOnElement(element) {
    element.focus();
}

function  getCities() {
    var cities = ["Accra", "Amsterdam", "Berlin", "Boston", "Lagos", "London", "Melbourne", "New York", "Seattle", "San Francisco", "Singapore", "Toronto", "Zurich"];
    return cities;
}

function confirmDelete(firstname, lastname) {
    var result = confirm("Are you sure you want to delete " + firstname + " " + lastname +"?");
    return result;
}