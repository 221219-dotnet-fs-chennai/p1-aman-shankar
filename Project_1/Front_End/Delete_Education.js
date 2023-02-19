async function deleteEducation(){
    const handledelete = document.getElementById("deleteEducation");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let eduname = document.getElementById("ename").value;

    await fetch ("https://localhost:7225/api/Education/Delete_Education?" + new URLSearchParams({
        email : email,
        education : eduname
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
            window.location.href = "Delete-Education.html";
        }
    })
    .then((response)=> console.log(response))
}