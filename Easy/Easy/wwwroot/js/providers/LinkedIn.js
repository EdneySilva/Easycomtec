/// <reference path="../site.min.js" />
/// <reference path="../site.js" />

window.registerToAngular(function (app) {
    app.provider("SocialNetwork", function () {
        this.$get = function () {
            return function (providerName, key) {
                var provider = new LinkedIn(key);
                return provider;
            }
        }
    });
});

window.LinkedIn = function (value) {

    var getProfileData = function (data) {
        //IN.API.Raw("/people/~").result(onSuccess).error(onError);
        IN.API.Profile("me").fields("id,firstName,lastName,phone-numbers,email-address,picture-urls::(original),public-profile-url,location:(name),skills:(skill:(name),proficiency:(name))").result(function (me) {
            //IN.API.Profile("me").fields("phone-numbers").result(function (me) {
            var profile = me.values[0];
            var id = profile.id;
            var firstName = profile.firstName;
            var lastName = profile.lastName;
            var emailAddress = profile.emailAddress;
            var pictureUrl = profile.pictureUrls.values[0];
            var profileUrl = profile.publicProfileUrl;
            var country = profile.location.name;
        });
    }

    window.onLinkedInLoaded = function () {
        $("span[id*='-title-text'").html("Use Linkedin profile");
        IN.Event.on(IN, 'auth', getProfileData);
    }

    linkedInKey = value;
    var lIN, d = document, tags = d.getElementsByTagName('body'), ref = tags[0];
    lIN = d.createElement('script');
    lIN.async = false;
    lIN.src = "//platform.linkedin.com/in.js";
    lIN.text = ("api_key: " + linkedInKey).replace("\"", "") + "\n" +
        "authorize: true\n" +
        "onLoad: onLinkedInLoaded";
    ref.parentNode.insertBefore(lIN, ref);

    this.User = function () {


    }
    return this;
};
