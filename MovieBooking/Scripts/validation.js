function validateEmail(email) {
    var pattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return pattern.test(String(email).toLowerCase());
}

function validateName(name) {
    var pattern = /^[a-zA-Z'.\s]{1,50}/;
    return pattern.test(String(name).toLowerCase());
}

function validateMobile(mobileNo) {
    var pattern = /^[0-9]{10}/;
    return pattern.test(String(mobileNo).toLowerCase());
}
