Array.prototype.remove = function (item) {
    return this.splice(this.indexOf(item), 1);
}

window.Guid = (function Guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }

    return {
        New: function () {
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
              s4() + '-' + s4() + s4() + s4();
        }
    }
}());

window.registerToAngular(function (app) {
    app.service("CandidateService", function ($httpClient, UserNotification) {
        var setItemToCandidate = function (candidate, item) {
            item.CandidateId = candidate.Id;
        }

        var events = {};

        var dispatch = function (event, data) {
            if (events[event] === undefined)
                return;
            for (var i in events[event].queue) {
                events[event].queue[i].$function(data);
            } 
        }

        this.on = function (event, callback) {
            if (events[event] === undefined)
                events[event] = {
                    container: {},
                    queue: new Array()
                }
            var id = window.Guid.New();
            var item = {
                id: id,
                $function: callback
            };
            events[event].container[id] = item;
            events[event].queue.push(item);
            return id;
        }

        this.off = function (event, id) {
            if (id === undefined)
                delete events[event];
            else {
                var item = events[event].container[id];
                if (item === undefined)
                    return;
                events[event].queue.remove(item);
                delete events[event].container[id];
            }
        }

        this.addPhone = function (candidate, phone) {
            setItemToCandidate(candidate, phone);
            if (candidate.Id == 0)
                candidate.Phones.push(phone);
            else
                $httpClient
                    .postAsync("/Home/addphone", phone)
                    .Success(function (response) {
                        candidate.Phones.push(response.data.Model)
                        console.log("sucesso");
                    }).Fail(function (response) {
                        console.log("falha");
                    });
        }

        this.removePhone = function (candidate, phone) {
            if (phone.Id == 0)
                candidate.Phones.remove(phone);
            else
                $httpClient
                    .postAsync("/Home/removephone", phone)
                    .Success(function (response) {
                        candidate.Phones.remove(phone);
                        console.log("sucesso");
                    }).Fail(function (response) {
                        console.log("falha");
                    });
        }

        this.addSkill = function (candidate, skill) {
            setItemToCandidate(candidate, skill);
            if (candidate.Id == 0)
                candidate.Skills.push(skill);
            else
                $httpClient
                    .postAsync("/Home/addskill", skill)
                    .Success(function (response) {
                        candidate.Skills.push(response.data.Model)
                        console.log("sucesso");
                    }).Fail(function (response) {
                        console.log("falha");
                    });
        }

        this.removeSkill = function (candidate, skill) {
            if (skill.Id == 0)
                candidate.Skills.remove(skill);
            else
                $httpClient
                    .postAsync("/Home/removeskill", skill)
                    .Success(function (response) {
                        candidate.Skills.remove(skill);
                        console.log("sucesso");
                    }).Fail(function (response) {
                        console.log("falha");
                    });
        }

        this.save = function (profile) {
            var notificator = UserNotification.Instance;
            $httpClient
                .postAsync("/api/candidate", profile)
                .Success(function (response) {
                    notificator.Success(response.data.Message, "Information");
                    dispatch("saved", response.data);
                    console.log("sucesso");
                }).Fail(function (response) {
                    notificator.Fail(response.data.Message, "Ops!");
                    console.log("falha");
                });
        }
    });
});