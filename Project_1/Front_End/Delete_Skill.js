async function deleteSkil(){
    const handledelete = document.getElementById("deleteSkill");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let skillname = document.getElementById("sname").value;

    await fetch ("https://localhost:7225/api/Skill/Delete_Skill?" + new URLSearchParams({
        email : email,
        skill : skillname
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
            window.location.href = "Delete-Skill.html";
        }
    })
    .then((response)=> console.log(response))
}