async function showAllSkill() {
    const userskill = document.getElementById("showAllSkill");
    
    userskill.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    await fetch("https://localhost:7225/api/Skill/All_Skills?" + new URLSearchParams
    ({
        Email : email,
    }),{
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>response.json())
    .then(i=> {

        i.forEach(element => {
            const parentDiv = document.createElement('div')
            parentDiv.className = "container"

            const div = document.createElement('div')
            div.className = "card"

            const skill_name = document.createElement('p')
            skill_name.textContent = "Skill-Name : " + element.skill_name
            skill_name.className = "card_skills_skill_name"
            
            div.appendChild(skill_name)
            userskill.appendChild(div)
        });  
    })
}
