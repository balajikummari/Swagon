var createState = function () {
    return "SessionValueMakeItABitLongerasdfhjsadoighasdifjdsalkhrfakwelyrosdpiufghasidkgewr";
};

var createNonce = function () {
    return "NonceValuedsafliudsayatroiewewryie123";
};

var signin = function () {
    var redirectUri = "https://localhost:44346/signin";
    var responseType = "id_token token";
    var scope = "openid SwagonResourceApi";

    var authUrl =
        "/connect/authorize/callback" +
        "?client_id=client_id_js2" +
        "&redirect_uri=" + encodeURIComponent(redirectUri) +
        "&response_type=" + encodeURIComponent(responseType) +
        "&scope=" + encodeURIComponent(scope) +
        "&scope=" + encodeURIComponent(scope) +
        "&nonce=" + createNonce() +
        "&state=" + createState();
    var returnUrl = encodeURIComponent(authUrl);
    console.log(returnUrl);
    window.location.href = "https://localhost:44376/Auth/Login?ReturnUrl=" + returnUrl;
}