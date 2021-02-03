using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Абонент - Физическое лицо
    /// </summary>
    public class PhysicalPerson : Entity, Subscriber
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
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
