window.registerToAngular(function (app) {
    app.controller("CandidateController", function ($scope, CandidateService, SocialNetwork, UserNotification) {
        this.candidate = new Candidate();
        var candidateService = CandidateService;
        $scope.Candidates = [];
        //var socialNetwork = SocialNetwork("LinkedIn", "78solhtvuzyg33");
        this.profileFormIsValid = function (frmResume) {
            var fields = ["Name", "BirthDate", "Email", "Country", "State", "City", "PostalCode"]
            if (frmResume.$submitted === false)
                return true;
            for (var i in fields) {
                if (frmResume[fields[i]] && frmResume[fields[i]].$valid === false)
                    return false;
            }
            return true;
        }

        this.saveProfile = function (frmResume) {
            //UserNotification.Instance.Success("teste", "Information");
            frmResume.$setSubmitted();
            if (frmResume.$valid === true) {
                candidateService.on("saved", function (data) {
                    if (data.Id == 0)
                        return;
                    setTimeout(function () {
                        window.location.href = "/";
                    }, 3000);
                });
                candidateService.save(this.candidate);
            }
        }

        this.addPhone = function (phone) {
            if (this.candidate.Phones === undefined)
                this.candidate.Phones = new Array();
            candidateService.addPhone(this.candidate, phone);
        }

        this.removePhone = function (phone) {
            candidateService.removePhone(this.candidate, phone);
        }

        this.addSkill = function (skill) {
            if (this.candidate.Skills === undefined)
                this.candidate.Skills = new Array();
            candidateService.addSkill(this.candidate, skill);
        }

        this.removeSkill = function (skill) {
            candidateService.removeSkill(this.candidate, skill);
        }

        if (window.onCandidateLoad !== undefined) {
            this.candidate = window.onCandidateLoad();
        }
    });
})