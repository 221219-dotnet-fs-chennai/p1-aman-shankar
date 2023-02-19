async function showAllCompany() {
    const usercompany = document.getElementById("showAllCompany");
    
    usercompany.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    await fetch("https://localhost:7225/api/Company/All_Companies?" + new URLSearchParams
    ({
        Email : email,
    }),{
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>response.json())
    .then(i => {

        i.forEach(element => {
            const parentDiv = document.createElement('div')
            parentDiv.className = "container"

            const div = document.createElement('div')
            div.className = "card"

            const company_name = document.createElement('p')
            company_name.textContent = "Company-Name : " + element.company_name
            company_name.className = "card_company_company_name"

            const industry = document.createElement('p')
            industry.textContent = "Education-Name : " + element.industry
            industry.className = "card_company_industry"

            const duration = document.createElement('p')
            duration.textContent = "Duration : " + element.duration
            duration.className = "card_education_duration"

            div.appendChild(company_name)
            div.appendChild(industry)
            div.appendChild(duration)

            usercompany.appendChild(div) 
            div.appendChild(document.createElement('hr'))
        });
    })
}