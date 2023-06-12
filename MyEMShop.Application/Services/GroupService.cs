using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Application.Services
{
    public class GroupService :IGroupService
    {
        #region Inject Context
        private readonly DatabaseContext _db;
        public GroupService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public IList<Group> GetGroups()
        {
           return _db.Groups.ToList();
        }

    }
}
