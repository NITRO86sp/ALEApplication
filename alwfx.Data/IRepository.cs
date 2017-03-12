using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alwfx.Data
{
    /// <summary>
    /// Generic contract for repository implementations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
    }
}
