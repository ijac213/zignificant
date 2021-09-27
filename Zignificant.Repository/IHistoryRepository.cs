using System.Collections.Generic;
using Zignificant.Models.Responses;
using Zignificant.Models.Requests;

namespace Zignificant.Repository
{
    public interface IHistoryRepository
    {
        HistoryResponse Create(HistoryCreateRequest req);
        void Delete(int Id);
        List<HistoryResponse> GetAll();
        HistoryResponse GetRecordById(int recordId);
        void Update(HistoryUpdateRequest req);
    }
}
