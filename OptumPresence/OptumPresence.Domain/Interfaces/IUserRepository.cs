using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Looks up database for existing user with specified username.
        /// </summary>
        /// <param name="username"></param>
        UserEntity GetUserByUsername(string username);
    }
}
