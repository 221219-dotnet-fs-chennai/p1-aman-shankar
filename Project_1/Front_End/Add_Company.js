async function addCompany(){
    const handlecompany = document.getElementById("addCompany");

    handlecompany.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let compname = document.getElementById("cname").value;
    let domain = document.getElementById("cindustry").value;
    let time = document.getElementById("cduration").value;

    await fetch("https://localhost:7225/api/Company/Add_Company?" + new URLSearchParams
    ({
        email : email
    }),{
        method : "POST",
        body : JSON.stringify({
            "c_id": 0,
            "company_id": "string",
            "company_name": compname,
            "industry": domain,
            "duration": time
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    .then((response) => console.log(response))
    alert("Added Sucessfully!");
    window.location.href = "Home.html"
}