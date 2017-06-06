 
$(document).ready(function () { 
    if (readCookie("login")!= null) {
        alert("Connected");
        $("#formConnexion").hide();
        $("#formSubscribtion").show();
    } else {
       // createCookie("koko", "testing", 1);
        $("#formConnexion").show();
        $("#formSubscribtion").hide(); 
    }

    var urlApi = "/api/users/"; 
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

    $("#formConnexion").validate({
        rules: {
            name: "required",
            login: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            name: "le nom est obligatoire !!",
            login: {
                required: "le login est obligatoire" 
            },
            password: {
                required: "Obligatoire !!"
            }
        }
    });

    $("#btnSubscribe").click(function () { 
        var form=$("#formSubscribtion");
        if ($(form.checkValidity)) {
            var nom = $("#name").val();
            var email = $("#email").val();
            var login = $("#login").val();
            var password = $("#password").val();
            $.ajax({
                url: urlApi,
                type: "GET",
                dataType: "JSON",
                data: { nom: nom, mail: email, login: login, pass: password },
                success: function (result) {
                    alert(result);
                }
            }); 
        } else {
           form.find(':submit').click();
        }       
    });

    $("#btnLogin").click(function () {
        var form = $("#formConnexion");
        if ($(form.checkValidity))
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
                    }
                    else
                    {
                        $("#MsgLogin").html("invalide Login/password");
                        $("#MsgLogin").addClass("error");
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