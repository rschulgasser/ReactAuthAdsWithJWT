using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactAuthAdWith_JWT.Data;
using ReactAuthAdWith_JWT.Web.Models;
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
        public List<AdViewModel> GetAllAds()
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            return repo.GetAds().Select(a => {
                return new AdViewModel
            {
                Ad = a,
                CanDelete = a.User.Email == email,
                UserName = $"{a.User.FirstName} {a.User.LastName}"
            };
        }).ToList();
    }
        [Authorize]
        [HttpGet]
        [Route("getadsforuser")]
        public List<AdViewModel> GetUsersAds()
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            var user = repo.GetCurrentUser(email);
        
            
            return repo.GetAdsForUser(user.Id).Select(a => {
                return new AdViewModel
                {
                    Ad = a,
                    CanDelete = a.User.Email == email,
                    UserName = $"{a.User.FirstName} {a.User.LastName}"
                };
            }).ToList();
        }



        [Authorize]
        [HttpPost]
        [Route("deletead")]
        public void deletead(Ad ad)
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user")?.Value;
            var user = repo.GetCurrentUser(email);
            var ads = repo.GetAds();
            if (ads.Any(a => a.Id==ad.Id))
            {
                repo.Delete(ad.Id);
            }
            
        }

    }
}
