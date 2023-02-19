async function showUserDetail(){
    const signinform = document.getElementById("showUserDetail");

    signinform.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    await fetch("https://localhost:7225/api/User/Email?" + new URLSearchParams
    ({
        Email : email,
    }),{
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>response.json())
    .then(element => {
        const parentDiv = document.createElement('div')
                parentDiv.className = "container"

                const div = document.createElement('div')
                div.className = "card"


                const user_id = document.createElement('p')
                user_id.textContent = "User-Id :- " + element.user_id
                user_id.className = "card_user_user_id"

                const first_name = document.createElement('p')
                first_name.textContent = "First-Name :- "+ element.first_name
                first_name.className = "card_user_first_name"

                const middle_name = document.createElement('p')
                middle_name.textContent = "Middle-Name :- "+ element.middle_name
                middle_name.className = "card_user_middle_name"

                const last_name = document.createElement('p')
                last_name.textContent = "Last-Name :- "+ element.last_name
                last_name.className = "card_user_last_name"

                const gender = document.createElement('p')
                gender.textContent = "Gender :- " + element.gender
                gender.className = "card_user_gender"

                const pincode = document.createElement('p')
                pincode.textContent = "Pincode :- "+ element.pincode
                pincode.className = "card_user_pincode"

                const website = document.createElement('p')
                website.textContent = "Website :- " + element.website
                website.className = "card_user_website"

                const mobile_number = document.createElement('p')
                mobile_number.textContent = "Mobile-Number :- " + element.mobile_number
                mobile_number.className = "card_user_mobile_number"

                const about_me = document.createElement('p')
                about_me.textContent = "About-Me :- " + element.about_me
                about_me.className = "card_user_about_me"

                div.appendChild(user_id)
                div.appendChild(first_name)
                div.appendChild(middle_name)
                div.appendChild(last_name)
                div.appendChild(gender)
                div.appendChild(pincode)
                div.appendChild(website)
                div.appendChild(mobile_number)
                div.appendChild(about_me)

                signinform.appendChild(div)
    })
}