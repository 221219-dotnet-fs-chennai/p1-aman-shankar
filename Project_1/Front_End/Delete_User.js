async function deleteUser(){
        if (confirm("Press Ok For Deleting You Account !")) {
          window.location.herf = "Login_Page.html"
        } else {
          window.location.href = "Delete-Details.html"
        }
    //confirm("Press Ok For Deleting You Account !")
    const handledelete = document.getElementById("deleteUser");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    await fetch ("https://localhost:7225/api/User/Delete?" + new URLSearchParams({
        Email : email,
    }),{
        method : "DELETE",
        headers:{
            "Content-type": "application/json; charset=UTF-8",
        },
    })
    window.location.href = "Login_Page.html" ;
}