using MyEMShop.Data.Entities.Group;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IGroupService
    {
        IList<Group> GetGroups();
    }
}
