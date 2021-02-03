using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Заключенный с абонентом контракт
    /// </summary>
    public class Contract : Entity
    {
        /// <summary>
        /// Номер контракта
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// Дата создания контракта
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Лицевые счета на контракте
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }
        /// <summary>
        /// Идентификатор абонента
        /// </summary>
        public int SubscriberId { get; set; }
    }
}
