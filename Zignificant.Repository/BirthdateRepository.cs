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

        public void Create(BirthdateCreateRequest req)
        {
            _birthdates.Create(req);
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
