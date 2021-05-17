using System;
using System.Collections.Generic;
using Zignificant.Data;
using Zignificant.Models.Requests;
using Zignificant.Models.Responses;

namespace Zignificant.Repository
{
    public class BirthdateRepository : IBirthdateRepository
    {
        private IBirthdates _birthdates;

        public void Delete(int id)
        {
            _birthdates.Delete(id);
        }

        public void Update(BirthdateUpdateRequest req)
        {
            _birthdates.Update(req);
        }

        public BirthdateResponse Create(BirthdateCreateRequest req)
        {
            int id = _birthdates.Create(req);
            BirthdateResponse resp = new BirthdateResponse();
            resp.Id = id;
            resp.FullName = req.FullName;
            resp.Dob = req.Dob;
            resp.Dod = req.Dod;
            resp.Notoriety = req.Notoriety;
            resp.CreatedAt = DateTime.Now;
            resp.UpdatedAt = DateTime.Now;
            return resp;
        }

        public BirthdateResponse GetRecordById(int id)
        {
            BirthdateResponse res = _birthdates.GetRecordById(id);
            return res;
        }

        public List<BirthdateResponse> GetAll()
        {
            List<BirthdateResponse> res = _birthdates.GetAll();
            return res;
        }

        public BirthdateRepository(IBirthdates birthdates)
        {
            _birthdates = birthdates;
        }
    }
}
