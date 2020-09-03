using AutoMapper;
using AutumnStore.Data.Model;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AutumnStore.Data.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserForRegisterDto> GetBillingUser(int userId)
        {
            User currentUser = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
            return _mapper.Map<UserForRegisterDto>(currentUser);

            //var products = await _context.Products.Where(x => x.category.Id == id).ToListAsync();
            //return _mapper.Map<IEnumerable<ProductDto>>(products); 
        }
    }
}
