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

        /// <summary>
        /// Convert position data to position entity
        /// </summary>
        /// <param name="position"></param>
        /// <param name="positionEntity"></param>
        void DataToBusiness(Position position, PositionEntity positionEntity);

        /// <summary>
        /// Convert team data to team entity
        /// </summary>
        /// <param name="team"></param>
        /// <param name="teamEntity"></param>
        void DataToBusiness(Team team, TeamEntity teamEntity);
    }
}
