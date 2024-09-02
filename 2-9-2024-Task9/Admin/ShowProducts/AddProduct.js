const CreateCatURL = "https://localhost:7152/api/Categories/Categories/ALL";
var form = document.getElementById("form");
var options = document.getElementById("options");

async function categoriesID() {
  let carOptions = await fetch(CreateCatURL);
  let CatID = await carOptions.json();

  CatID.forEach((element) => {
    options.innerHTML += `<option value="${element.id}">${element.categroyName}</option>`;
  });
}

categoriesID();

async function addProduct() {
  event.preventDefault();

  var formData = new FormData(form);
  let response = await fetch("https://localhost:7152/api/Products", {
    method: "POST",
    body: formData,
  });
  alert("Product Added Succssefuly!");
}
