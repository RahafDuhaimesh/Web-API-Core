const url = "https://localhost:7152/api/Categories/Categories/ALL";

function storeCategoryID(CategoryID) {
  localStorage.CategoryIDChoosen = CategoryID;
}

async function GetAllCategories() {
  let request = await fetch(url);
  let response = await request.json();
  var conatiner = document.getElementById("conatiner");

  response.forEach((category) => {
    conatiner.innerHTML += `
    
    <div class="card shadow-sm" style="width: 20rem; border-radius: 15px; overflow: hidden; margin: 20px auto;">
        <img src="${category.categroyImage}" class="card-img-top" alt="${category.categroyImage} this image is not found" style="height: 250px; object-fit: cover;">
        <div class="card-body" style="background-color: #f8f9fa; padding: 20px;">
          <h5 class="card-title" style="font-weight: bold; color: #3C5B6F;">${category.categroyName}</h5>
          <a href="../Products/products.html" class="btn btn-primary" style="background-color: #3C5B6F; border-color: #3C5B6F;" onclick="storeCategoryID(${category.id})">Discover the products!</a>
        </div>
      </div>
    `;
  });
}
GetAllCategories();
