async function addEducation(){
    const handleeducation = document.getElementById("addEducation");

    handleeducation.addEventListener("submit" , event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let eduname = document.getElementById("ename").value;
    let eduinstitute = document.getElementById("einstitute").value;
    let edugrade = document.getElementById("egrade").value;
    let eduduration = document.getElementById("eduration").value;

    await fetch("https://localhost:7225/api/Education/Add_Education?" + new URLSearchParams({
        email : email
    }),{
        method: "POST",
        body : JSON.stringify({
            "e_id": 0,
            "education_id": "string",
            "education_name": eduname,
            "institute_name": eduinstitute,
            "grade": edugrade,
            "duration": eduduration
        }),
        headers:{
            "Content-type": "application/json; charset=UTF-8",
        },
    })
    .then((response) => console.log(response))
    alert("Added Successfully!");
    window.location.href = "Home.html"
}