using ExamApi.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Services.Interfaces
{
    public interface ITokenService
    {
        public bool IsValidToken(ValidateTokenRequest tokenRequest);
    }
}
