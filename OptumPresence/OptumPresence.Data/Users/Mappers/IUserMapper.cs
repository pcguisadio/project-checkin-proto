using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptumPresence.Domain.Entities;
using OptumPresence.Data.EntityModels;

namespace OptumPresence.Data.Users.Mappers
{
    /// <summary>
    /// Interface for user data mappers
    /// </summary>
    public interface IUserMapper
    {
        /// <summary>
        /// Convert user data to user entity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userEntity"></param>
        void DataToBusiness(User user, UserEntity userEntity);
    }
}
