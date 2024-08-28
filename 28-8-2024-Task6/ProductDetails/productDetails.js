let n = Number(localStorage.getItem("ProductIDChoosen"));
const url = `https://localhost:7152/api/Products/api/products/${n}`;

async function GetProductsDetails() {
  let request = await fetch(url);
  let response = await request.json();

  var conatiner = document.getElementById("conatiner");

  conatiner.innerHTML = `
       <div class="card shadow-sm" style="width: 20rem; border-radius: 15px; overflow: hidden; margin: 20px auto;">
      <img src="${response.productImage}" class="card-img-top" alt="${response.productImage} this image is not found" style="height: 250px; object-fit: cover;">
      <div class="card-body" style="background-color: #f8f9fa; padding: 20px;">
        <h5 class="card-title" style="font-weight: bold; color: #3C5B6F;">${response.productName}</h5>
        <h6 style="color: #DFD0B8; font-size: 1.25rem;">${response.price}$</h6>
        <a href="../editProduct/editproduct.html" > update the product </a>
      </div>
    </div>
      `;
}

GetProductsDetails();
