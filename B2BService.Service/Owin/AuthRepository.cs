using B2BService.Repository.SellerRepositories;
using B2BService.Service.Models;
using B2BService.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace B2BService.Service.Owin
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName,
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
         
            return result;
        }

        /// <summary>
        /// This method will add Organization and the user in same time.
        /// Pass the disired view model to get successfull result
        /// </summary>
        /// <param name="userModel">Type of UserOrganisazionVM</param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterSeller(UserOrganisazionVM userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.User.UserName,
            };
            //Saving the user to the ASP.NET user tables
            var result = await _userManager.CreateAsync(user, userModel.User.Password);
            //Set the user id to the ASP.net User id
            userModel.User.UserId = user.Id;
            userModel.Organization.IsSeller = true;
            //If above was successfull then we will add the organization and our detail user accounts
            if (result.Succeeded)
            {
                CoparateReporitory corprepo = new CoparateReporitory();
               // await corprepo.AddOrganization(userModel);
            }
            
            return result;
        }

        /// <summary>
        /// This will create a buyer. so buyer basically does not need an organization so stand alone user may be adiquite
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterBuyer(UserOrganisazionVM userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.User.UserName,
            };
            //Saving the user to the ASP.NET user tables
            var result = await _userManager.CreateAsync(user, userModel.User.Password);
            //Set the user id to the ASP.net User id
            userModel.User.UserId = user.Id;
            userModel.Organization.IsSeller = false;
            //If above was successfull then we will add the organization and our detail user accounts
            if (result.Succeeded)
            {
                CoparateReporitory corprepo = new CoparateReporitory();
               // await corprepo.AddOrganization(userModel);
            }

            return result;
        }


        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}