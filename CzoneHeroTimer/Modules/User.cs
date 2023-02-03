using CzoneHeroTimer.Data.RepositoryModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Modules
{
    public class User:UserModel
    {
        

        public Department Department { get; set; }
    }
}
