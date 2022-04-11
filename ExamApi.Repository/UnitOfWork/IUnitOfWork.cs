using ExamApi.Domain.Entities;
using ExamApi.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<CardEntity> CardRepositoy { get; }
        IRepository<CustomerCardEntity> CustomerCardRepository { get; }
        void Commit();
    }
}
