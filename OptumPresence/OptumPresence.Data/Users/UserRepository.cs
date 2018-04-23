using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OptumPresence.Data.EntityModels;
using OptumPresence.Data.Users.Mappers;
using OptumPresence.Domain.Entities;
using OptumPresence.Domain.Interfaces;

namespace OptumPresence.Data.Users
{
    public class UserRepository : IUserRepository
    {
        #region Constants and Variables

        /// <summary>
        /// The data mapper for user data.
        /// </summary>
        private readonly IUserMapper _userMapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Repository Constructor with mapper setting
        /// </summary>
        /// <param name="userMapper"></param>
        public UserRepository(IUserMapper userMapper)
        {
            this._userMapper = userMapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Looks up database for existing user with specified username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns user info if found, null if not found</returns>
        public UserEntity GetUserByUsername(string username)
        {
            UserEntity result = null;
            using (var dbContext = new HotelingDataContext())
            {
                User user = dbContext.Users.FirstOrDefault(x => x.Username.Equals(username.Trim()));
                if (user != null)
                {
                    result = new UserEntity();
                    //TODO: Get Position and Team info from DB.
                    this._userMapper.DataToBusiness(user, result);
                }
            }
            return result;
        }
        #endregion
    }
}
