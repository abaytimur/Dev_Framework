using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T:class, IEntity, new()
    {
        // Bir tabloya attach olup, abone olup; o tablo uzerinde query yapmamizi saglayacak. O yuzden hangi
        // T'yi verirsem onunla ilgi tabloyu kendisini attach edecek sekilde implementasyon gerceklestiriyor

        private DbContext _context;

        // 1 tablo entity frameworkte DbSet'e karsilik gelir, yani bu sekilde attach oluruz
        private IDbSet<T> _entities;

        // Eger northwind context degilde baska bir tanesini kullanmak istersek, bunun sayesinde sorunsuz kullanabilecegiz
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities; // Table cagrildiginda this.Entities return edilecek

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
