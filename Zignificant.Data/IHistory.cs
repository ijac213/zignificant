using System.Collections.Generic;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Data
{
    public interface IHistory
    {
        int Create(HistoryCreateRequest req);
        void Delete(int recordId);
        List<HistoryResponse> GetAll();
        HistoryResponse GetRecordById(int recordId);
        void Update(HistoryUpdateRequest req);
    }
}
