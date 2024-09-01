let n = Number(localStorage.getItem("ProductIDChoosen"));
var url = `https://localhost:7152/api/Products/${n}`;
var form = document.getElementById("form");

async function updateProduct() {
  event.preventDefault();
  debugger;
  var formData = new FormData(form);

  let response = await fetch(url, {
    method: "PUT",
    body: formData,
  });
  var data = response;
}
