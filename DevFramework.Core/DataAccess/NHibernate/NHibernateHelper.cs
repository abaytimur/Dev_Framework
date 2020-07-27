using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        // Oracle icin farkli sql server icin farkli vs. session gonderiyor
        private static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }
        }

        // InitializeFactory ile 1 tane Factory uretmem gerekiyor
        protected abstract ISessionFactory InitializeFactory();

        // Bu context'i (session'i) acmaya ihtiyacim var. Kisi nasil bir sessionFactory gonderdiyse onu kullanarak 
        // bana 1 tane session ac diyoruz.
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            // GC = Garbage Collector
            GC.SuppressFinalize(this);
        }
    }
}
