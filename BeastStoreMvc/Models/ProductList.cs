
namespace BeastStoreMvc.Models
    

{
//    public class ProductList
//    {
//    }
//}
//{
    public class ProductListsModel
{

        public List<Products> ProductData { get; set; } = new List<Products>();

        public int CurrentPageIndex { get; set; }


    public int PageCount { get; set; }

}
public class Products
{

    public long ProductId { get; set; }

    public string ProductName { get; set; } = " ";

        public long CategoryId { get; set; }

    public string CategoryName { get; set; } = " "; 

}
}