using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class RateService:IRateService
    {
        private readonly List<Rate> _rates = new List<Rate>();

        public Rate Add(Rate item)
        {
            var newRate = (Rate)item.Clone();
            newRate.Id = !_rates.Any() ? 1 : _rates.Max(rate => rate.Id) + 1;
            _rates.Add(newRate);
            return (Rate)newRate.Clone();
        }

        public List<Rate> GetByUserID(int id)
        {
            return _rates.Where(item => item.Id == id).ToList();

        }

        public void Delete(int id)
        {
            var existRate = _rates.SingleOrDefault(rate => rate.Id == id);
            if (existRate == null)
            {
                throw new NullReferenceException();
            }
            _rates.Remove(existRate);
        }

        public List<Rate> Get()
        {
            return _rates.
                Select(item => (Rate)item.Clone()).ToList();
        }

        public Rate Get(int id)
        {
            var rate = _rates.SingleOrDefault(item => item.Id == id);
            return rate == null ? null : (Rate)rate.Clone();
        }

        public Rate Update(Rate item)
        {
            var existRate = _rates.SingleOrDefault(rate => rate.Id == item.Id);
            if (existRate == null)
            {
                throw new NullReferenceException();
            }
            existRate.RateInformation = item.RateInformation;
            return (Rate)existRate.Clone();
        }
    }
}
