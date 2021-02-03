using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public int Id { get; set; }
    }
}
