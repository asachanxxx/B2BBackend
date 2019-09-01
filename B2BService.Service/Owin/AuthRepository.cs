using B2BService.Domain.Coparate;
using B2BService.Repository.BuyerRepositories;
using B2BService.Repository.SellerRepositories;
using B2BService.Service.Models;
using B2BService.ViewModels;
using B2BService.ViewModels.Organisazion;
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
                await corprepo.AddOrganization(userModel);
            }
            
            return result;
        }

        /// <summary>
        /// This will create a buyer and the organisation at the same time.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateBuyerWithOrganisation(OrgUserFullVM userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserDet.UserName,
            };
            //Saving the user to the ASP.NET user tables
            var result = await _userManager.CreateAsync(user, userModel.UserDet.Password);
            //Set the user id to the ASP.net User id
            userModel.UserDet.UserId = user.Id;
            userModel.OrganisazionDet.IsSeller = false;
            //If above was successfull then we will add the organization and our detail user accounts
            if (result.Succeeded)
            {
                //Manually set the org type
                userModel.OrganisazionDet.IsSeller = false;
                CorparateRepository corprepo = new CorparateRepository();
               await corprepo.CreateUserWithOrganisation(userModel);
            }

            return result;
        }

        /// <summary>
        /// This will create a buyer and the organisation at the same time.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserOnly(User userModel)
        {
            CorparateRepository corprepo = new CorparateRepository();
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName,
            };
            //Saving the user to the ASP.NET user tables
            var result = await _userManager.CreateAsync(user, userModel.Password);

            //If above was successfull then we will add the user accounts
            if (result.Succeeded)
            {
                //Set the user id to the ASP.net User id
                userModel.UserId = user.Id;


                //check orgId is a valied one.
                bool orgValied = await corprepo.CheckOrganizationExits(userModel.OrganizationID);
                if (!orgValied)
                {
                    //IdentityUser useride = new IdentityUser(userModel.UserName);
                    var xres = _userManager.Delete(user);
                    throw new Exception("Invalied Organization");
                }
                //set User's active = false
                userModel.Activated = false;
                //Set supperuser false by defualt. becouse system not allowed more than one supper user for organization
                //This controller create users for existing orgs and 100% certenty that the org has supperuser already
                userModel.IsSupperUser = false;

                //- Create Approval Entry for given Org to visible to Supper User

                await corprepo.CreateUserOnly(userModel);

            }

            return result;
        }

        public async Task<IdentityResult> CreateUserOnlyForAdmins(User userModel)
        {
            CorparateRepository corprepo = new CorparateRepository();
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName,
            };
            //Saving the user to the ASP.NET user tables
            var result = await _userManager.CreateAsync(user, userModel.Password);

            //If above was successfull then we will add the user accounts
            if (result.Succeeded)
            {
                //Set the user id to the ASP.net User id
                userModel.UserId = user.Id;

                //set User's active = false
                userModel.Activated = true;

                //- Create Approval Entry for given Org to visible to Supper User

                await corprepo.CreateUserOnly(userModel);

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