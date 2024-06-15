

namespace ProductsManagment.Models.DTO
{
    public class ElectricProductDTO : CategoryDto
    {
        public SocketTypeDTO SocketType { get; set; }

        public VoltageDTO Voltage { get; set; }
    }
}
