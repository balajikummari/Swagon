    var config = {
        userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
        authority: "https://localhost:44376",
        client_id: "jsclient",
        redirect_uri: "https://localhost:44346/signin",
        post_logout_redirect_uri: "https://localhost:44345/Home/Index",
        response_type: "id_token token",
        scope: "openid SwagonResourceApi"
    };
    var userManager = new Oidc.UserManager(config);

    const signIn = () => {

        userManager.signinRedirect();
    };

    userManager.getUser().then(user => {
        console.log("user:", user);
        if (user) {
            axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
        }
    });

var callApi = function () {

        //fetch('https://localhost:44374/cities/Getall', { 
        //    method: 'get', 
        //    headers: new Headers({
        //        'Authorization': "Bearer " + user.access_token
        //    }), 
        //}).then(res => {
        //    console.log(res);
        //})
        //.catch(err => {
        //    console.log(err);
        //})

        axios.get("https://localhost:44374/cities/Getall")
            .then(
                (response) => {
                console.log(response);
                },
                (error) => {
                    console.log("responce  :" + error.response.data)
                }
            );
    };