window.registerToAngular(function (app) {

    function HttpHandler() {
        var httpHandler = this;
        var errors = new Array();
        var onFail = Function();
        var onComplet = Function();
        var finalized = false;

        this.AddError = function (erro) {
            console.log(erro);
            errors.push(erro);
        }

        this.EnsureSuccessResponse = function(data) {
            if (errors.length > 0)
                throw "Invalid response";
            onComplet.call(window, data);
        }

        this.Fail = function (callback) {
            onFail = callback;
            if (finalized === true)
                onFail.call();
            return this;
        }

        this.FailResponse = function (response) {
            httpHandler.AddError(response.statusText);
            httpHandler.FinalizeRequest({
                request: response.config,
                data: null,
                MessageError: response.data
            });
        }

        this.FinalizeRequest = function (response) {
            try{
                finalized = true;
                httpHandler.EnsureSuccessResponse(response);
            } catch(e) {
                response.errors = errors;
                onFail.call(window, response);
            }
            return this;
        }

        this.Success = function (callback) {
            onComplet = callback
            if (finalized === true)
                onComplet.call();
            return this;
        }

        this.SuccessResponse = function (response) {            
            if (response.data.Success === true) {
                httpHandler.FinalizeRequest({
                    request: response.config,
                    data: response.data
                });
                return;
            } 
            if (response.data.Trace !== undefined)
                httpHandler.AddError(response.data.Trace);
            if (response.data.Erros !== undefined)
                httpHandler.AddError(httpHandler.toMessageError(response.data.Erros));
            httpHandler.FinalizeRequest({
                request: response.config,
                data: response.data,
                MessageError: httpHandler.toMessageError(response.data.Erros)
            });
        }

        this.toMessageError = function (list) {
            var msg = "";
            for (var i in list) {
                msg += (msg.length > 0 ? "\n" : "") + list[i];
            }
            return msg;
        }

        this.GetResponse = function () {
            return {
                Success: httpHandler.Success,
                Fail: httpHandler.Fail
            }
        }

        return this;
    }

    app.service("$httpClient", function ($http) {
        var createHeader = function (options) {
            var object = {
                headers: {
                    'Content-Type': 'application/json'
                }
            };
            if (options !== undefined)
                for (var i in options) {
                    object[i] = options[i];
                }
            return object;
        }
        this.deleteAsync = function (uri, content, options) {
            var httpHandler = new HttpHandler($http);
            $http.delete(uri)
                .then(
                    httpHandler.SuccessResponse,
                    httpHandler.FailResponse
            );
            return httpHandler.GetResponse();
        }
        this.postAsync = function (uri, content, options) {
            var httpHandler = new HttpHandler($http);
            $http.post(uri, JSON.stringify(content), createHeader(options))
                .then(
                    httpHandler.SuccessResponse,
                    httpHandler.FailResponse
                 );
            return httpHandler.GetResponse();
        }
        this.getAsync = function (uri, options) {
            var httpHandler = new HttpHandler($http);
            $http.get(uri, createHeader(options))
                .then(
                    httpHandler.SuccessResponse,
                    httpHandler.FailResponse
                );
            return httpHandler.GetResponse();
        }
    });
});