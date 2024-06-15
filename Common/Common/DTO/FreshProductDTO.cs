namespace ProductsManagment.Models.DTO
{
    public class FreshProductDTO : CategoryDto
    {
        public DateTime ExpiryDate { get; set; }
    }
}
