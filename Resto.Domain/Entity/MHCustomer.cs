using Resto.Domain.DTO;

namespace Resto.Domain.Entity
{
    public class MHCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public MHCustomerDto ToDto()
        {
            return new MHCustomerDto()
            {
                Id = Id,
                CustomerName = CustomerName,
                CustomerPhone = CustomerPhone
            };
        }
    }
}
