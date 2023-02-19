async function modifyEducation(){
    const handleUpdate = document.getElementById("modifyEducation");

    handleUpdate.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let oldedu = document.getElementById("oename").value;
    let newedu = document.getElementById("nename").value;
    let inst = document.getElementById("iname").value;
    let edugrade = document.getElementById("grade").value;
    let eduduration = document.getElementById("duration").value;

    await fetch("https://localhost:7225/api/Education/Update_Education?" + new URLSearchParams({
        email : email,
        education : oldedu,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "e_id": 0,
            "education_id": "string",
            "education_name": newedu,
            "institute_name": inst,
            "grade": edugrade,
            "duration": eduduration
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    .then((response)=> console.log(response))
    alert("Updated Successfully!");
    window.location.href = "Home.html";
}