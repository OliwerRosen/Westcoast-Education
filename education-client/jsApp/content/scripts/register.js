const baseUrl = "https://localhost:7212/api/v1";
const selectUserType = document.querySelector(".select-user-type");
const inputForm = document.querySelector(".input-form");
let userType = "";

const onPageload = async () => {
  const radioButtons = document.querySelectorAll('input[name="userTypeRadio"]');
  for (const radioButton of radioButtons){
    radioButton.checked = false;
    radioButton.addEventListener('change', () => {
      if (radioButton.checked === true && radioButton.value === "teacher"){
          userType = "teacher";
        }
      else if (radioButton.checked === true && radioButton.value === "student"){
          userType = "student";
        }
        inputForm.innerHTML = form;
      })
    }
}

submitForm = async () => {
  let url =`${baseUrl}/${userType}`;
  let submitData = {
    "firstName" : firstName.value, 
    "lastName" : lastName.value,
    "email" : email.value,
    "phoneNr" : phoneNr.value,
    "address" : address.value
  };
  if (userType === "teacher"){
  }
  if (userType === "student"){
  }
  const response = await fetch(url, {
    method: "POST",
    headers: {'Content-Type': 'application/json'}, 
    body: JSON.stringify(submitData)
  })

  if (!response.ok){
    const error = await response.json();
    if(error.statusCode === 400)
    {
      console.log(error.statusText);
    } else {
      console.log(`Det gick inte att lägga till ${firstName.value}.`)
    }
  } else {
    console.log(`${firstName.value} är inlagd i systemet.`)
  }
}


const form = `
<form id="${userType}Form">
  <label for="firstname">Förnamn:</label><br>
  <input type="text" id="firstName" name="firstName"><br>
  <label for="lastname">Efternamn:</label><br>
  <input type="text" id="lastName" name="lastName"><br>
  <label for="email">Email:</label><br>
  <input type="text" id="email" name="email"><br>
  <label for="phonenr">Telefonnummer:</label><br>
  <input type="text" id="phoneNr" name="phoneNr"><br>
  <label for="address">Adress:</label><br>
  <input type="text" id="address" name="address"><br>
  <input type="button" onclick="submitForm()" value="Skicka">
</form>`


onPageload();