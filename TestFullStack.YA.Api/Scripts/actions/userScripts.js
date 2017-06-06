 
$().ready(function () {

    var urlApi = "api/users/"; 
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
                required: "le login est obligatoire",
                minlength: "Your username must consist of at least 2 characters"
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
        $.getJSON(urlApi+"1")
         .done(function (data) { 
             alert(data);
         }); 
        $("#formSubscribtion").submit(); 
    });

    
});