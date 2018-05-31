window.registerToAngular(function (app) {
    app.component("skill", {
        bindings: {
            skills: "=",
            addSkill: "&",
            removeSkill: "&"
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
                return name;
            };

            this.add = function () {
                var skill = createSkill(this);
                this.addSkill({ skill: skill });
                this.Skill.Name = "";
                this.Skill.Level = 0;
            },
            this.remove = function (skill) {
                this.removeSkill({ skill: skill });
            },
            this.disableAdd = function () {
                return this.Skill.Name === "" || (this.Skill.Level === "" || this.Skill.Level === 0);
            }
        },
        templateUrl: function () {
            return "/app/skillControl.html";
        }
    });
});