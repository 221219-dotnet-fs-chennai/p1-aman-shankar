async function modifyCompany(){
    const handleUpdate = document.getElementById("modifyCompany");

    handleUpdate.addEventListener("submit" , event=>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let oldcomp = document.getElementById("ocname").value;
    let newcomp = document.getElementById("ncname").value;
    let cindustry = document.getElementById("iname").value;
    let cduration = document.getElementById("duration").value;

    await fetch("https://localhost:7225/api/Company/Update_Company?" + new URLSearchParams({
        email : email,
        company : oldcomp,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "c_id": 0,
            "company_id": "string",
            "company_name": newcomp,
            "industry": cindustry,
            "duration": cduration
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    .then((response)=> console.log(response))
    alert("Updated Successfully!");
    window.location.href = "Home.html";
}