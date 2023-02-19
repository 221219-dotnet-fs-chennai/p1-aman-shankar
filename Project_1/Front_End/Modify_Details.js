function modifyUser(){
    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let flag = false;
    if(email != null){
        flag= true
    }
    if(flag == true){
        handleUpdate();
    }
    }
    function handleUpdate(){
        let email = localStorage.getItem('email')
        email = email.replace(/['‘’"“”]/g, '')
        
        let firstname = document.getElementById("fname").value;
        let lastname = document.getElementById("lname").value;
        let middlename = document.getElementById("mname").value;
        let gender = document.getElementById("gen").value;
        let pincode = document.getElementById("pin").value;
        let website = document.getElementById("web").value;
        let password = document.getElementById("pass").value;
        let about = document.getElementById("me").value;

        fetch("https://localhost:7225/api/User/Update?" + new URLSearchParams({
            E_Mail : email
        }),{
            method : "PUT",
            body : JSON.stringify({
            "user_id": "string",
            "first_name": firstname,
            "middle_name": middlename,
            "last_name": lastname,
            "gender": gender,
            "pincode": pincode,
            "email": "string",
            "website": website,
            "mobile_number": "string",
            "password": password,
            "about_me": about
        }),
        headers:{
            "Content-type": "application/json; charset=UTF-8",
        },
        })
    .then((response) => console.log(response))
    alert("Updated Successfully!");
    window.location.href = "Home.html"
}