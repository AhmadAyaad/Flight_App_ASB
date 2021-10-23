using Flight.Core.Dtos;
using Flight.Core.Interfaces;
using Flight.Entities.Entities;
using Flight.Entities.Interfaces;

using Microsoft.Extensions.Configuration;

using System.Linq;
using System.Threading.Tasks;

namespace Flight.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Customer> Login(string customerName, string password)
        {
            var customer = _unitOfWork.CustomerRepository.Find(c => c.Name == customerName).FirstOrDefault();

            if (customer == null)
                return null;

            if (!VerifyPassHash(password, customer.PasswordHash, customer.PasswordSalt))
                return null;

            return Task.FromResult(customer);
        }
        private bool VerifyPassHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA1(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }
            return true;
        }

        public async Task<Customer> Register(Customer customer, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            await _unitOfWork.CustomerRepository.Create(customer);
            await _unitOfWork.SaveChangesAsync();
            return customer;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA1())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> CustomerExists(string customerName)
        {
            var isExist = await _unitOfWork.SpecficCustomerRepository.CustomerExists(customerName);
            if (isExist)
                return true;
            return false;
        }

        public void GenerateToken(IConfiguration configuration, CustomerLoginDto customerLoginDto)
        {
            //var claims = new[]
            //{
            //        new Claim(ClaimTypes.NameIdentifier ,  customerLoginDto.CustomerId.ToString()) ,
            //        new Claim(ClaimTypes.Name , customerLoginDto.Name)
            //};
            //var key = new SymmetricSecurityKey(Encoding.UTF8
            //.GetBytes(configuration.GetSection("AppSettings:Token").Value));


            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    SigningCredentials = creds,
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.Now.AddDays(1)
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();

            //var token = tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}
