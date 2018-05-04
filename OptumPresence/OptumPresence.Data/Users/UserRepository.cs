using OptumPresence.Data.Encryption;
using OptumPresence.Data.EntityModels;
using OptumPresence.Data.Users.Mappers;
using OptumPresence.Domain.Entities;
using OptumPresence.Domain.Interfaces;
using System;
using System.Linq;

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
                    this._userMapper.DataToBusiness(user, result);
                }
            }
            return result;
        }

        /// <summary>
        /// Updates existing User's Password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ChangePassword(UserEntity user)
        {
            bool result = false;
            using(var dbContext = new HotelingDataContext())
            {
                User userResult = dbContext.Users.FirstOrDefault(x => x.Username.Equals(user.Username.Trim()));
                if (userResult != null)
                {
                    userResult.Password = HashingUtility.GetMd5Hash(user.Password);
                    userResult.RecordUpdateDate = DateTime.Today;
                    userResult.RecordUpdateUserID = user.Username;
                    dbContext.SubmitChanges();
                    result = true;
                }
            }
            return result;
        }
        #endregion
    }
}
