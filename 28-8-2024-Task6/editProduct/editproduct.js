debugger;

let n = Number(localStorage.getItem("ProductIDChoosen"));
let url = `https://localhost:7152/api/Products/${n}`;

async function editProduct() {
  var form = document.getElementsByClassName("form")[0];

  var formdata = new FormData(form);
  event.preventDefault();
  debugger;
  let response = await fetch(url, {
    method: "PUT",
    body: formdata,
  });
  var data = response;
  alert("Product  edited successfuly");
}
