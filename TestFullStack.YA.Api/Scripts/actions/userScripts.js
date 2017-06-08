 
$(document).ready(function () {
    var urlApi = "/api/users/";

    if (readCookie("LoggedName") != null) { 
        $("#loggedIn").show();
        $("#spNameLogged").html("Salut : " + readCookie("LoggedName"));
        $("#formConnexion").hide();
        $("#formSubscribtion").hide();
    } else {
        $("#formConnexion").show();
        $("#formSubscribtion").hide();
        $("#loggedIn").hide();
    }

    $("#btnConnexion").click(function () {
        $("#formConnexion").show();
        $("#formSubscribtion").hide();
    });

    $("#btnInsription").click(function () {
        $("#formConnexion").hide();
        $("#formSubscribtion").show();
    });

    $("#btnDeconnexion").click(function () { 
        eraseCookie("LoggedName");
        $("#loginCnx").val("");
        $("#passwordCnx").val("");
        $("#formConnexion").show();
        $("#formSubscribtion").hide();
        $("#loggedIn").hide();
    });
     
    $("#formSubscribtion").validate({
        rules: {
            name: "required", 
            login: {
                required: true
            },
            password: {
                required: true 
            },
            confirm_password: {
                required: true,
                equalTo: "#password"
            },
            email: {
                required: true,
                email: true
            }
        },
        messages: {
            name: "le nom est obligatoire !!",
            login: {
                required: "le login est obligatoire" 
            },
            password: {
                required: "Obligatoire !!"
            },
            confirm_password: {
                required: "Obligatoire !!",
                equalTo: "les mots de passe ne sont pas identiques"
            },
            email: {
                required: "l'email est obligatoire",
                email:"Invalide email !!"
            }
                
        }
    });

     $("#btnSubscribe").click(function () { 
        var form=$("#formSubscribtion");
        if (form.valid()) {
            var nom = $("#name").val();
            var email = $("#email").val();
            var login = $("#login").val();
            var password = $("#password").val();
            $.ajax({
                url: urlApi,
                type: "POST",
                dataType: "JSON",
                data: { Name: nom, email: email, login: login, password: password },
                success: function (result) {
                    if (JSON.stringify(result)=="true") {
                        $("#name").val("");
                        $("#email").val("");
                        $("#login").val("");
                        $("#password").val("");
                        $("#confirm_password").val("");
                        $("#MsgSubscribe").val("Inscription réussite");
                        $("#MsgSubscribe").css("color","green");
                    } else {
                        ("#MsgSubscribe").val("Veuillez changer le login !! ");
                        $("#MsgSubscribe").css("color", "red");
                    }
                   
                }
            }); 
        } else {
           form.find(':submit').click();
        }       
    });

    $("#btnLogin").click(function () {
        var form = $("#formConnexion");
        
        if (form.valid())
        {
            var login = $("#loginCnx").val();
            var pass = $("#passwordCnx").val();
            $.ajax({
                url: urlApi,
                type: "GET",
                dataType: "JSON",
                data: { login: login, password: pass },
                success: function (result) {
                    if (result != null)
                    {
                        eraseCookie("LoggedName");
                        createCookie("LoggedName", result.Name, 1);
                        $("#loggedIn").show();
                        $("#spNameLogged").html("Salut : " + result.Name);
                        $("#formConnexion").hide();
                        $("#formSubscribtion").hide();
                        $("#loginCnx").val("");
                        $("#passwordCnx").val("");
                    }
                    else
                    {
                        $("#MsgLogin").html("invalide Login/password");
                        $("#MsgLogin").addClass("error"); 
                         $("#passwordCnx").val("");
                    }
                }
            });

        }
        else
        {
            form.find(':submit').click();
        }
    });
         

    
});