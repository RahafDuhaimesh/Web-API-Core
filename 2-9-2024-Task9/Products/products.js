let n = Number(localStorage.getItem("CategoryIDChoosen"));
var url = `https://localhost:7152/api/Products/api/productsCat/${n}`;

function storeProductID(ProductID) {
  localStorage.ProductIDChoosen = ProductID;
}

async function GetProductsByID() {
  let request = await fetch(url);
  let response = await request.json();
  console.log(response);
  var conatiner = document.getElementById("conatiner");

  response.forEach((element) => {
    conatiner.innerHTML += `
        <div class="card shadow-sm" style="width: 20rem; border-radius: 15px; overflow: hidden; margin: 20px auto;">
        <img src="${element.productImage}" class="card-img-top" alt="${element.productImage} this image is not found" style="height: 250px; object-fit: cover;">
        <div class="card-body" style="background-color: #f8f9fa; padding: 20px;">
          <h5 class="card-title" style="font-weight: bold; color: #3C5B6F;">${element.productName}</h5>
          <a href="../ProductDetails/productDetails.html" class="btn btn-primary" style="background-color: #3C5B6F; border-color: #3C5B6F;" onclick="storeProductID(${element.id})">Discover the product details!</a>
        

        </div>
      </div>
    `;
  });
}
GetProductsByID();
