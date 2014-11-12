define(['Q','jQuery'], function (Q,$) {
    var TravelPersister = (function () {
        function TravelPersister() {
        }

        TravelPersister.prototype.GetAllTravels = function () {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Travels',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };


        TravelPersister.prototype.GetTravelById = function (id) {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Travels/'+ id,
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        TravelPersister.prototype.PutTravel = function (id, travel) {
            var deferred = Q.defer();

            $.ajax({
                type: "PUT",
                url: '/api/Travels/' + id,
                data: {
                    Travel: travel
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });


            return deferred.promise;
        };

        
        TravelPersister.prototype.PostTravel = function (travel) {
            var deferred = Q.defer();

            $.ajax({
                type: "POST",
                url: '/api/Travels/',
                data: {
                    Travel:travel
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });
            
            return deferred.promise;
        };

        TravelPersister.prototype.DeleteTravelById = function (id) {
            var deferred = Q.defer();

            $.ajax({
                type: "DELETE",
                url: '/api/Travels/' + id,
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

            return TravelPersister;
    }());


    var AccountPersister = (function () {
        function AccountPersister() {
        };

        AccountPersister.prototype.Register = function (email, password, confirmPassword) {
            var deferred = Q.defer();

            $.ajax({
                type: "POST",
                url: '/api/Account/Register',
                data: {
                    Email: email,
                    Password: password,
                    ConfirmPassword: confirm
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        AccountPersister.prototype.Logout = function () {
            var deferred = Q.defer();

            $.ajax({
                type: "POST",
                url: '/api/Account/Logout',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        AccountPersister.prototype.AddExternalLogin = function (accessToken) {
            var deferred = Q.defer();

            $.ajax({
                type: "POST",
                url: '/api/Account/AddExternalLogin',
                data: {
                    ExternalAccessToken:accessToken
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        AccountPersister.prototype.UserInfo = function () {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Account/UserInfo',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        return AccountPersister;
    });


    var CitiesPersister = (function () {
        function CitiesPersister() {
        }

        CitiesPersister.prototype.GetAllCities = function () {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Cities',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };


        CitiesPersister.prototype.GetCityById = function (id) {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Cities/' + id,
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        CitiesPersister.prototype.PutCity = function (id, city) {
            var deferred = Q.defer();

            $.ajax({
                type: "PUT",
                url: '/api/Cities/' + id,
                data: {
                    City: city
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });


            return deferred.promise;
        };


        CitiesPersister.prototype.PostCity = function (city) {
            var deferred = Q.defer();

            $.ajax({
                type: "POST",
                url: '/api/Cities/',
                data: {
                    City: city
                },
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        CitiesPersister.prototype.DeleteCityById = function (id) {
            var deferred = Q.defer();

            $.ajax({
                url: '/api/Cities/' + id,
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        return CitiesPersister;
    }());


        return {
            TravelPersister: TravelPersister,
            AccountPersister: AccountPersister,
            CitiesPersister: CitiesPersister
        }
    });