using CRMApp.Application.DTOs;
using CRMApp.Domain.Entities;
using CRMApp.Domain.Interfaces;

namespace CRMApp.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.AccountId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                City = c.City,
                State = c.State,
                Country = c.Country,
                DateCreated = c.DateCreated
            }).ToList();
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) return null;
            return new CustomerDto
            {
                Id = customer.AccountId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                DateCreated = customer.DateCreated
            };
        }

        public async Task AddAsync(CustomerDto dto)
        {
            var customer = new Customer
            {
                AccountId = 0, // Assuming AccountId is auto-generated  
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                DateCreated = DateTime.UtcNow
            };
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(CustomerDto dto)
        {
            var customer = await _repository.GetByIdAsync(dto.Id);
            if (customer == null) return;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.State = dto.State;
            customer.Country = dto.Country;
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}