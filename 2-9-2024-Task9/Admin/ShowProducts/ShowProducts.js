var url = "https://localhost:7152/api/Products";

function storeProductID(ProductID) {
  localStorage.ProductIDChoosen = ProductID;
}

async function GetAllProducts() {
  let request = await fetch(url);
  let response = await request.json();
  var conatiner = document.getElementById("ShowProducts");

  response.forEach((product) => {
    conatiner.innerHTML += `
    <tr>
        <td style="padding: 10px; border-bottom: 1px solid #ddd;">
          <img src="${product.productImage}" alt="image is not found" style="width: 100px; height: auto; border-radius: 10px; object-fit: cover;">
        </td>
        <td style="padding: 10px; border-bottom: 1px solid #ddd; color: #3C5B6F; font-weight: bold;">
          ${product.productName}
        </td>
         <td style="padding: 10px; border-bottom: 1px solid #ddd; color: #3C5B6F; font-weight: bold;">
          ${product.description}
        </td>
         <td style="padding: 10px; border-bottom: 1px solid #ddd; color: #3C5B6F; font-weight: bold;">
          ${product.price}
        </td>
         <td style="padding: 10px; border-bottom: 1px solid #ddd; color: #3C5B6F; font-weight: bold;">
          ${product.categoryId}
        </td>
        <td style="padding: 10px; border-bottom: 1px solid #ddd;">
          <a href="../ShowProducts/EditProduct.html" class="btn btn-primary" style="background-color: #3C5B6F; border-color: #3C5B6F;" onclick="storeProductID(${product.id})">edit</a>
        </td>
      </tr>
    `;
  });
}
GetAllProducts();
