using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableReporsitory<T> : IQueryableRepository<T> where T:class , IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        // Dependancy injection
        public NhQueryableReporsitory(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => this.Entities; // return this.Entities

        //set; 'i silerek readonly yaptik
        public virtual IQueryable<T> Entities
        {
            // Eger _entities null'sa yeni bir tane aciyor. Degilse olani donduruyor
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
        }
    }
}
