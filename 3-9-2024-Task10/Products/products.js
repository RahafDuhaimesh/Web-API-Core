// products.js

let n = localStorage.getItem("CategoryIDChoosen");

let url;
if (n === null) {
  url = "https://localhost:7152/api/Products";
} else {
  url = `https://localhost:7152/api/Products/api/productsCat/${n}`;
}

function storeProductID(ProductID) {
  localStorage.setItem("ProductIDChoosen", ProductID);
}

async function GetProductsByID() {
  try {
    const token = localStorage.getItem("jwtToken");
    if (token == null) {
      alert("Please login first!!");
      window.location.href = "../login/login.html";
    }
    const response1 = await fetch(
      "https://localhost:7152/api/Categories/Categories/ALL",
      {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );
    let request = await fetch(url);
    let response = await request.json();
    console.log(response);

    let container = document.getElementById("container"); // Fixed the ID spelling

    response.forEach((element) => {
      container.innerHTML += `
        <div class="card shadow-sm" style="width: 20rem; border-radius: 15px; overflow: hidden; margin: 20px auto;">
          <img src="${element.productImage}" class="card-img-top" alt="${element.productImage} this image is not found" style="height: 250px; object-fit: cover;">
          <div class="card-body" style="background-color: #f8f9fa; padding: 20px;">
            <h5 class="card-title" style="font-weight: bold; color: #3C5B6F;">${element.productName}</h5>
            <a href="../ProductDetails/productDetails.html" class="btn btn-primary" style="background-color: #3C5B6F; border-color: #3C5B6F;" onclick="storeProductID(${element.id})">Discover the product details!</a>
          </div>
        </div>
      `;
    });
  } catch (error) {
    console.error("Failed to fetch products: ", error);
  }
}

GetProductsByID();
