using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Абонент - Юридическое лицо
    /// </summary>
    public class LegalPerson : Entity, Subscriber
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Форма организации
        /// </summary>
        public string OrganizationForm { get; set; }
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
