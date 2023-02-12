using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvorchestvoProgram.Model;

namespace WebServerTvor.ApiModel
{
    class Response
    {
        public Response(Product product)
        {
            this.ProductArticleNumber = product.ProductArticleNumber;
            this.ProductName = product.ProductName;
            this.ProductDescription = product.ProductDescription;
            this.IDProductCategory = product.IDProductCategory;
            this.Image = product.Image;
            this.ProductCost = product.ProductCost;
            this.ProductDiscountAmount = product.ProductDiscountAmount;
            this.IDProductCategory = product.IDProductCategory;
            this.ProductQuantityInStock = product.ProductQuantityInStock;
            this.ProductUnit = product.ProductUnit;
            this.Supplier = product.Supplier;
        }
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int IDProductCategory { get; set; }
        public string Image { get; set; }
        public string ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<int> ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductUnit { get; set; }
        public string Supplier { get; set; }
    }
}
