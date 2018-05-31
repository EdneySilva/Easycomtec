window.registerToAngular(function (app) {
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
});