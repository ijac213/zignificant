using System.Collections.Generic;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Repository
{
    public interface IBirthdateRepository
    {
        BirthdateResponse Create(BirthdateCreateRequest req);
        void Delete(int id);
        List<BirthdateResponse> GetAll();
        BirthdateResponse GetRecordById(int id);
        void Update(BirthdateUpdateRequest req);
    }
}