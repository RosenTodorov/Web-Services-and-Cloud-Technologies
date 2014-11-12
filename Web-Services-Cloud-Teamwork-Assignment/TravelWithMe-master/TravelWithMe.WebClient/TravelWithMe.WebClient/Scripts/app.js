/// <reference path="C:\Users\Lyubomir\Desktop\Teamwork\TravelWithMe.WebClient\TravelWithMe.WebClient\Pages/indexPageBox.html" />
/// <reference path="libs/jquery-1.9.0.js" />
(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1",
            "sammy": "libs/sammy-0.7.5.min",
        }
    });

    require(["jquery", "sammy"], function ($, Sammy) {
        Sammy('#main', function () {

            this.get('#/index', function () {

                var $textContainer = $('<div/>').attr('id', 'box-index');
                $('#main').append($textContainer);
                $('#box-index').load("Pages/indexPageBox.html");
            });

            this.get('#/register', function () {
                $('#main').empty();

                var $textContainer = $('<div/>').attr('id', 'box-index');
                $('#main').append($textContainer);
                $('#box-index').load("Pages/registerPageForm.html");


                //If Ok Add Green
                $(document).on("click", "input", function (input) {
                    var id = input.currentTarget.id;
                    var element = $("#" + id);

                    if ((element.parent()).parent().hasClass("has-error")) {
                        (element.parent()).parent().removeClass("has-error");
                    }
                    ((element.parent()).parent()).addClass('has-success');
                });

                $(document).on("click", "#btn-register", function () {

                    //Check name
                    var $name = $("#inputName");
                    if ($name.val() == "") {
                        (($name.parent()).parent()).addClass('has-error')
                    }
                    //Check passwords
                    var $password = $("#inputPassword");
                    if ($password.val() == "") {
                        (($password.parent()).parent()).addClass('has-error')
                    }
                    //Check confirm passwords
                    var $confirmPassword = $("#inputConfirmPassword");
                    if ($confirmPassword.val() == "") {
                        (($confirmPassword.parent()).parent()).addClass('has-error')
                    }
                    //Check email
                    var $email = $("#inputEmail");
                    if ($email.val() == "") {
                        (($email.parent()).parent()).addClass('has-error')
                    }
                    //check phone number
                    var $phone = $("#inputPhoneNumber");
                    if ($phone.val() == "") {
                        (($phone.parent()).parent()).addClass('has-error')
                    }


                    var newUser = {
                        "Name": $name.val(),
                        "Email": $email.val(),
                        "PhoneNumber": $phone.val(),
                        "Password": $password.val(),
                        "ConfirmPassword": $confirmPassword.val()
                    }

                    //Send
                    $.ajax({
                        type: "POST",
                        url: "http://localhost:53863/api/Account/Register",
                        data: JSON.stringify({
                            "Name": $name.val(),
                            "Email": $email.val(),
                            "PhoneNumber": $phone.val(),
                            "Password": $password.val(),
                            "ConfirmPassword": $confirmPassword.val()
                        }),
                        contentType: "application/json;",
                        async:true,
                        success: function(data){
                            alert(data);
                        },
                        failure: function(errMsg) {
                            alert(errMsg);
                        }
                    });
                });






            });

            this.get('#/sign-in', function () {
                alert("signInPage")
            });

            this.get('#/about-us', function () {
                alert("aboutusPage")
            });

            this.get('#/trips', function () {
                alert("tripsPage")
            });
        }).run('#/index');
    });
}());
