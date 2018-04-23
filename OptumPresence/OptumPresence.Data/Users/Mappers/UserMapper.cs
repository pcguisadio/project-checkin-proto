using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Data.Users.Mappers
{
    /// <summary>
    /// Mapper class for user data
    /// </summary>
    public class UserMapper : IUserMapper
    {
        public void DataToBusiness(User user, UserEntity userEntity)
        {
            if (userEntity == null)
            {
                userEntity = new UserEntity();
            }
            if (user != null)
            {
                userEntity.Username = user.Username;
                userEntity.Password = user.Password;
                userEntity.LastName = user.LastName;
                userEntity.FirstName = user.FirstName;
            }
            //TODO: Set Position and Team info
        }
    }
}
