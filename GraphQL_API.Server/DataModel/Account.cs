using System;
using System.Collections.Generic;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Лицевой счет абонента
    /// </summary>
    public class Account : Entity
    {
        /// <summary>
        /// Номер ЛС
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// Баланс на ЛС
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Дата создания ЛС
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Список приложений абонента
        /// </summary>
        public IEnumerable<SubscriberDevice> Devices { get; set; }
        /// <summary>
        /// Номер контракта
        /// </summary>
        public long ContractNumber { get; set; }
    }
}