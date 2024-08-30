const CreateCatURL = "https://localhost:7152/api/Categories";
var form = document.getElementById("form");

async function addCategory() {
  event.preventDefault();

  debugger;
  var formData = new FormData(form);

  let response = await fetch("https://localhost:7152/api/Categories", {
    method: "POST",
    body: formData,
  });
  var data = response;
  alert("Category Added Succesfully!");
}
