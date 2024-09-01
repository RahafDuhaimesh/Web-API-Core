const url = "https://localhost:7152/api/Categories/Categories/ALL";
function storeCategoryID(CategoryID) {
  localStorage.CategoryIDChoosen = CategoryID;
}

async function GetAllCategories() {
  let request = await fetch(url);
  let response = await request.json();
  var conatiner = document.getElementById("showCategories");

  response.forEach((category) => {
    conatiner.innerHTML += `
    <tr>
        <td style="padding: 10px; border-bottom: 1px solid #ddd;">
          <img src="${category.categroyImage}" alt="image is not found" style="width: 100px; height: auto; border-radius: 10px; object-fit: cover;">
        </td>
        <td style="padding: 10px; border-bottom: 1px solid #ddd; color: #3C5B6F; font-weight: bold;">
          ${category.categroyName}
        </td>
        <td style="padding: 10px; border-bottom: 1px solid #ddd;">
          <a href="../ShowCategories/EditCategory.html" class="btn btn-primary" style="background-color: #3C5B6F; border-color: #3C5B6F;" onclick="storeCategoryID(${category.id})">edit</a>
        </td>
      </tr>
    `;
  });
}
GetAllCategories();
