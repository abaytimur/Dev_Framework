using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess
{
    interface IQueryableRepository<T> where T:class, IEntity, new()
    {
        // IQueryable operasyonlar tamamen select operasyonu icin oldugundan tek bir implementasyon yapacagim.
        // Yani imza olusturacagim. O da genellikle Table ismiyle adlandirilir. Readonly bir operasyon olacak
        IQueryable<T> Table { get; }
    }
}
