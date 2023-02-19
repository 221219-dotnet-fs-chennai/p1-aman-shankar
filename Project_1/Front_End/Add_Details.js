async function addUser() {
    const handleuser = document.getElementById("addUser");

    handleuser.addEventListener("submit", event => {
        event.preventDefault();
    });

    let userid = document.getElementById("id").value;
    let firstname = document.getElementById("fname").value;
    let lastname = document.getElementById("lname").value;
    let middlename = document.getElementById("mname").value;
    let gender = document.getElementById("gen").value;
    let pincode = document.getElementById("pin").value;
    let Email = document.getElementById("mail").value;
    let website = document.getElementById("web").value;
    let mobile = document.getElementById("mob").value;
    let password = document.getElementById("pass").value;
    let about = document.getElementById("me").value;

    await fetch("https://localhost:7225/api/User/Add_User" , {
        method: "POST",
        body: JSON.stringify({
            "user_id": userid,
            "first_name": firstname,
            "middle_name": middlename,
            "last_name": lastname,
            "gender": gender,
            "pincode": pincode,
            "email": Email,
            "website": website,
            "mobile_number": mobile,
            "password": password,
            "about_me": about
        }),
        headers: {
            "Content-type": "application/json; charset=UTF-8",
        },
    })
        .then((response) => console.log(response))
        alert("User Added Successfully!");
        window.location.href = "Login_Page.html"
}