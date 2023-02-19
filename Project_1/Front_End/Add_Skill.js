async function addSkill(){
    const handleskill = document.getElementById("addSkill");

    handleskill.addEventListener("submit" , event => {
        event.preventDefault();
    });
    
    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')
    
    let skill = document.getElementById("skill_name").value;
    

    await fetch("https://localhost:7225/api/Skill/Add_Skill?" + new URLSearchParams
    ({
        email : email
    }),{
        method: "POST",
        body : JSON.stringify({
            "s_id": 0,
            "skill_id": "string",
            "skill_name": skill
        }),
        headers:{
            "Content-type": "application/json; charset=UTF-8",
        },
    })
    
    .then((response) => console.log(response))
    alert("Added Successfully!");
    window.location.href = "Home.html"
}