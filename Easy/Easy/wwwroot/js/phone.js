window.registerToAngular(function (app) {
    app.component("phone", {
        bindings: {
            phones: "=",
            addPhone: "&",
            removePhone: "&"
        },
        controller: function ($scope) {
            this.Phone = new Phone();
            var createPhone = function (context) {
                var phone = new Phone();
                phone.Number = context.Phone.Number;
                return phone;
            }
            this.add = function () {
                var phone = createPhone(this);
                this.addPhone({ phone: phone });
                this.Phone.Number = "";
            },
            this.remove = function (phone) {
                this.removePhone({ phone: phone });
                //this.phones.splice(this.phones.indexOf(phone), 1);
            },
            this.disableAdd = function () {
                return this.Phone.Number === "";
            }
        },
        templateUrl: function () {
            return "/app/phoneControl.html";
        }
    });
});