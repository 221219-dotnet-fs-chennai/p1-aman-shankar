async function deleteCompany(){
    const handledelete = document.getElementById("deleteCompany");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let compname = document.getElementById("cname").value;

    await fetch ("https://localhost:7225/api/Company/Delete_Company?" + new URLSearchParams({
        email : email,
        company : compname
    }),{
        method : "DELETE",
        headers :{
            "Content-type": "application/json; charset=UTF-8",
        },
    })
    .then((response) =>{
        if(response.status == 200){
            alert("Deleted Successfully!");
            window.location.href = "Home.html";
        }
        else{
            alert("Please check the credentails");
            window.location.href = "Delete-Company.html";
        }
    })
    .then((response)=> console.log(response))
}