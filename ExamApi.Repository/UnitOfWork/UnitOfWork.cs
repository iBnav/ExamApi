using ExamApi.Domain.Entities;
using ExamApi.Repository.Repository;
using ExamApi.Repository.Repository.Interface;

namespace ExamApi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.Context _context;
        public UnitOfWork(Context.Context context)
        {
            _context = context;
        }

        private ExamRepository<CardEntity> cardRepository { get; set; }
        private ExamRepository<CustomerCardEntity> customerCardRepository { get; set; }

        
        public IRepository<CardEntity> CardRepositoy 
        {
            get
            {
                if (cardRepository == null)
                    cardRepository = new ExamRepository<CardEntity>(_context);

                return cardRepository;
            }
        }

        public IRepository<CustomerCardEntity> CustomerCardRepository
        {
            get
            {
                if (customerCardRepository == null)
                    customerCardRepository = new ExamRepository<CustomerCardEntity>(_context);

                return customerCardRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
