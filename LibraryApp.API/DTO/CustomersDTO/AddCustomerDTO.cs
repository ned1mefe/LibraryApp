using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.CustomersDTO
{
    public class AddCustomerDTO: BaseCustomerDTO
    {
        public Customer ToCustomer()
        {
            return new Customer()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
            };
        }
    }
}
