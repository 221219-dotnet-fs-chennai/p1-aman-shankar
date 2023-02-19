async function modifySkill(){
    const handleUpdate = document.getElementById("modifySkill");

    handleUpdate.addEventListener("submit" , event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let oldskill = document.getElementById("osname").value;
    let newskill = document.getElementById("nsname").value;

    await fetch("https://localhost:7225/api/Skill/Update_Skill?" + new URLSearchParams
    ({
        email : email,
        skill : oldskill,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "s_id": 0,
            "skill_id": "string",
            "skill_name": newskill
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    .then((response)=> console.log(response))
    alert("Updated Successfully!");
    window.location.href = "Home.html";
}