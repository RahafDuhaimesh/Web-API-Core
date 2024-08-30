let n = Number(localStorage.getItem("CategoryIDChoosen"));
let url = `https://localhost:7152/api/Categories/${n}`;

async function EditCategory() {
  var form = document.getElementsByClassName("form")[0];

  var formdata = new FormData(form);
  event.preventDefault();
  debugger;
  let response = await fetch(url, {
    method: "PUT",
    body: formdata,
  });
  var data = response;
  alert("Category  edited successfuly");
}
