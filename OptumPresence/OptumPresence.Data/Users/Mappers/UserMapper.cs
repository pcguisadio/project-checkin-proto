using OptumPresence.Data.EntityModels;
using OptumPresence.Domain.Entities;

namespace OptumPresence.Data.Users.Mappers
{
    /// <summary>
    /// Mapper class for user data
    /// </summary>
    public class UserMapper : IUserMapper
    {
        public void DataToBusiness(tbl4User user, UserEntity userEntity)
        {
            if (userEntity != null && user != null)
            {
                userEntity.UserUID = user.UserUID;
                userEntity.Username = user.Username;
                userEntity.Password = user.Password;
                userEntity.LastName = user.LastName;
                userEntity.FirstName = user.FirstName;
                this.DataToBusiness(user.tbl4Position, userEntity.Position);
                this.DataToBusiness(user.tbl4Team, userEntity.Team);
            }
        }

        public void DataToBusiness(tbl4Position position, PositionEntity positionEntity)
        {
            if (positionEntity != null && position != null)
            {
                positionEntity.PositionUID = position.PositionUID;
                positionEntity.PositionName = position.PositionName;
            }
        }

        public void DataToBusiness(tbl4Team team, TeamEntity teamEntity)
        {
            if (teamEntity != null && team != null)
            {
                teamEntity.TeamUID = team.TeamUID;
                teamEntity.TeamName = team.TeamName;
            }
        }
    }
}
