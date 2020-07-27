using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess
{
    // Tum veri tipleri icin generic calismasini istedigimiz icin <T> verdik
    // Temel bir kisitlama getirdik. T referans tip olmali (class). Ancak interfacelerde referans tip, interface gonderemesin diye
    // IEntityi yazdik. Bir de newlenebilir olsun
    public interface IEntityRepository<T> where T : class, IEntity, new()

    {
    // İstersem datanın tümünü istersem datanın where koşuluyla belirtilmiş kısmını getirmek istiyorum.
    // Dolayısıyla buraya link expression gönderip bu süreci tamamlamak istiyorum. Bir link exp. yani bir method delegesi göndereceğim
    // Onu da bir expression Func göndererek gerçekleştireceğim. Buna da isim olarak filter diyorum. Filter boş gönderebileceği için
    // herhangi bir filtre gönderilmeyebilir, o yüzden null yazdık. 
    List<T> GetList(Expression<Func<T, bool>> filter = null);

    // Tek bir eleman cekmek istersek
    T Get(Expression<Func<T, bool>> filter = null);
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);
    }
}
