using System;
using System.Collections.Generic;
using System.Text;
using Zignificant.Data;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private IHistory _history;

        public void Delete(int id)
        {
            _history.Delete(id);
        }

        public void Update(HistoryUpdateRequest req)
        {
            _history.Update(req);
        }

        public HistoryResponse Create(HistoryCreateRequest req)
        {
            int id = _history.Create(req);
            HistoryResponse resp = new HistoryResponse();
            resp.Id = id;
            resp.Date = req.Date;
            resp.Title = req.Title;
            resp.Description = req.Description;
            resp.CreatedAt = DateTime.Now;
            resp.UpdatedAt = DateTime.Now;
            return resp;
        }

        public HistoryResponse GetRecordById(int id)
        {
            HistoryResponse res = _history.GetRecordById(id);
            return res;
        }

        public List<HistoryResponse> GetAll()
        {
            List<HistoryResponse> res = _history.GetAll();
            return res;
        }

        public HistoryRepository(IHistory history)
        {
            _history = history;
        }

    }
}
