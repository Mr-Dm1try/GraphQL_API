using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Абонент
    /// </summary>
    public interface Subscriber
    {
        /// <summary>
        /// Словарь контактных данных (тип, значение)
        /// </summary>
        public IDictionary<string, string> ContactDetails { get; set; }
        /// <summary>
        /// Заключенные контракты абонента
        /// </summary>
        public IEnumerable<Contract> Contracts { get; set; }
    }
}
