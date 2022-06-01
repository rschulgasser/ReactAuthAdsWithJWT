using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactAuthAdWith_JWT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAuthAdWith_JWT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ads : ControllerBase
    {
        private string _connectionString;

        public Ads(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

      

        [Authorize]
        [HttpPost]
        [Route("addad")]
        public void AddAd(Ad ad)
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            ad.UserId = repo.GetCurrentUser(email).Id;
            ad.Date = DateTime.Now;
            repo.AddAd(ad);
        }
        
        [HttpGet]
        [Route("getallads")]
        public List<Ad> GetAllAds()
        {
            var repo = new AdsRepository(_connectionString);
            var r=repo.GetAds();
            return r;
        }
        [Authorize]
        [HttpGet]
        [Route("getadsforuser")]
        public List<Ad> GetUsersAds()
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            var user = repo.GetCurrentUser(email);
        
            return repo.GetAdsForUser(user.Id);
        }



        [Authorize]
        [HttpPost]
        [Route("deletead")]
        public void deletead(Ad ad)
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            var user = repo.GetCurrentUser(email);

            if (user.Ads.Any(a => ad.Id == a.Id))
            {
                repo.Delete(ad.Id);
            }
            
        }

    }
}
