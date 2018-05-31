/// <reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.0/angular.min.js" />
// Write your Javascript code.

function Candidate() {
    this.Id = 0;
    this.Name = "";
    this.Email = "";
    this.BirthDate = new Date();
    this.Phones = [];
    this.Skills = [];
    this.Address = new Address();
    this.Account = {};
}

function Phone() {
    this.Id = 0;
    this.Number = "";
    return this;
}

function Skill() {
    this.Id = 0;
    this.Name = "";
    this.Level = 0;
    return this;
}

function Address() {
    this.Id = 0;
    this.Country = "";
    this.State = "";
    this.City = "";
    this.PostalCode = "";
    this.Number = "";
    return this;
}

window.registerToAngular = (function (angular) {
    var app = angular.module("app", []);

    app.provider("UserNotification", function () {
        this.$get = function () {
            return (function () {
                var _componente = null;
                var success = function (message, title) {
                    if (_componente == null)
                        return;
                    _componente.Show("success", message, title);
                }
                var error = function (message, title) {
                    if (_componente == null)
                        return;
                    _componente.Show("danger", message, title);
                }
                return {
                    Instance: {
                        Success: success,
                        Error: error
                    },
                    Config: function ($component) {
                        if (_componente == null)
                            _componente = $component
                    }
                };
            }());
        }
    });
    
    app.component("alert", {
        controller: function AlertController($scope, UserNotification) {
            var context = this;
            var scope = $scope;
            this.CssClass = "alert alert-success hide";
            this.Type = "success";
            this.Title = "Aviso";
            this.Message = "";
            this.Show = function (type, message, title) {
                this.Title = title;
                this.Message = message;
                this.CssClass = this.CssClass.replace("-" + this.Type, "-" + type).replace("hide", "").trimRight();
                this.Type = type;
                setTimeout(function () {
                    scope.$ctrl.CssClass += " hide";
                    scope.$apply();
                }, 10000);
            }
            UserNotification.Config(this);
        },
        template: "<br/>" +
        "<div ng-class='$ctrl.CssClass' role=\"alert\">" +
            "<strong>{{$ctrl.Title}}</strong> {{$ctrl.Message}}." +
        "</div>"
    });

    return function ($function) {
        if ($function === undefined)
            return;
        if (typeof $function !== typeof Function())
            return;
        $function.call(angular, app);
    }
})(angular);



/*
(function (angular) {
    var app = angular.module("app", []);
    app.provider("SocialNetwork", function () {
        this.$get = function () {
            return function (providerName, key) {
                var provider = new LinkedIn(key);
                return provider;
            }
        }
    });

    app.service("CandidateService", function ($http) {
        //$scope.Candadite = new Candidate();

        this.addPhone = function () {


        }

        this.removePhone = function () {


        }

        this.addSkill = function () {


        }

        this.removeSkill = function () {


        }

        this.save = function () {


        }
    });

    app.controller("CandidateController", function ($scope, CandidateService, SocialNetwork) {
        this.candidate = new Candidate();
        var candidateService = CandidateService;
        $scope.Candidates = []
        //var socialNetwork = SocialNetwork("LinkedIn", "78solhtvuzyg33");
        this.index = function () {

        }
    });

    app.component("phone", {
        bindings: {
            phones: "=",
            addPhone: "&"
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
            }
        },
        templateUrl: function () {
            return "/app/phoneControl.html";
        }
    });

    app.service("SkillService", function () {
        this.Levels = [];
        this.getLevels = function () {
            var levels = [];
            function createLevel(name, value, selected) {
                return {
                    name: name,
                    value: value,
                    selected: selected || false
                };
            }
            levels.push(createLevel("CHOICE YOUR LEVEL", 0, true));
            levels.push(createLevel("DONOT KNOW", 1));
            levels.push(createLevel("KNOW", 2));
            levels.push(createLevel("BASIC", 3));
            levels.push(createLevel("INTERMEDIATE", 4));
            levels.push(createLevel("ADVANCED", 5));
            levels.push(createLevel("EXPERT", 6));
            return this.Levels = levels;
        }

        this.getLevelName = function (level) {
            for (var i in this.Levels) {
                if (this.Levels[i].value == level) {
                    return this.Levels[i].name;
                }
            }
            return "LEVEL NOT MATCH";
        }
    });

    app.component("skill", {
        bindings: {
            skills: "=",
            addSkill: "&"
        },
        controller: function ($scope, SkillService) {
            this.levels = SkillService.getLevels();
            this.Skill = new Skill();
            var createSkill = function (context) {
                var skill = new Skill();
                skill.Name = context.Skill.Name;
                skill.Level = context.Skill.Level;
                return skill;
            }

            this.levelName = function (level) {
                var name = SkillService.getLevelName(level);
                console.log(name);
                return name;
            };

            this.add = function () {
                var skill = createSkill(this);
                this.addSkill({ skill: skill });
                this.Skill.Name = "";
                this.Skill.Level = 0;
            }
        },
        templateUrl: function () {
            return "/app/skillControl.html";
        }
    });

    return app;
})(window.angular);
*/