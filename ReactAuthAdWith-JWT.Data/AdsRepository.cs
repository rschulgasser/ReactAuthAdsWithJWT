using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactAuthAdWith_JWT.Data
{
    public class AdsRepository
    {
        private readonly string _connectionString;

        public AdsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddAd(Ad ad)
        {
            using var context = new AdsDataContext(_connectionString);
            context.Ads.Add(ad);
            context.SaveChanges();
        }

        public List<Ad> GetAds()
        {
            using var context = new AdsDataContext(_connectionString);
            var w=context.Ads.Include(a=>a.User).OrderByDescending(a => a.Date).ToList();
            return w;
        }

        public List<Ad> GetAdsForUser(int userId)
        {
            using var context = new AdsDataContext(_connectionString);
            return context.Ads.Where(a => a.UserId == userId).Include(a => a.User).OrderByDescending(a => a.Date).ToList();
        }
        public void Delete(int id)
        {
            using var context = new AdsDataContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM Ads WHERE Id = {id}");
        }
        public User GetCurrentUser(string email)
        {
            using var context = new AdsDataContext(_connectionString);
            return context.Users.FirstOrDefault(e => e.Email == email);
        }

    }
}
