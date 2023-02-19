async function login(){
    const signinform = document.getElementById("login");

    signinform.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let id = document.getElementById("id").value;

    await fetch("https://localhost:7225/api/Login/Login?" + new URLSearchParams
    ({
        User_Id : id,
        Email : email,
        Password : password
    }),{
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>{
        if(response.status == 200){
            alert("Login Successfully!");
            window.location.href = "Home.html";
            localStorage.setItem("email" , email);
            localStorage.setItem("password" ,password);
            localStorage.setItem("id", id);
        }
        else{
            alert("Please check the credentails");
        }
    })
    .then((response) => response.json())
    .then(json => console.log(json))
} 