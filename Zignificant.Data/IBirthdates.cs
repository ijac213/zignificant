using System.Collections.Generic;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Data
{
    public interface IBirthdates
    {
        int Create(BirthdateCreateRequest req);
        void Delete(int recordId);
        List<BirthdateResponse> GetAll();
        BirthdateResponse GetRecordById(int recordId);
        void Update(BirthdateUpdateRequest req);
    }
}