async function showAllEducation() {
    const usereducation = document.getElementById("showAllEducation");
    
    usereducation.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    await fetch("https://localhost:7225/api/Education/All_Education?" + new URLSearchParams
    ({
        Email : email,
    }),{
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>response.json())
    .then(edu => {

        edu.forEach(element => {
            const parentDiv = document.createElement('div')
            parentDiv.className = "container"

            const div = document.createElement('div')
            div.className = "card"

            

            const education_name = document.createElement('p')
            education_name.textContent = "Education-Name : " + element.education_name
            education_name.className = "card_education_education_name"

            const institute_name = document.createElement('p')
            institute_name.textContent = "Education-Name : " + element.institute_name
            institute_name.className = "card_education_institute_name"

            const grade = document.createElement('p')
            grade.textContent = "Grade : " + element.grade
            grade.className = "card_education_grade"

            const duration = document.createElement('p')
            duration.textContent = "Duration : " + element.duration
            duration.className = "card_education_duration"

            div.appendChild(education_name)
            div.appendChild(institute_name)
            div.appendChild(grade)
            div.appendChild(duration)
            usereducation.appendChild(div)
            div.appendChild(document.createElement('hr'))
        });
        
    })
}