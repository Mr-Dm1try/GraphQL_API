using System;

namespace GraphQL_API.Server.DataModel
{
    /// <summary>
    /// Приложение абонента
    /// </summary>
    public class SubscriberDevice : Entity
    {
        /// <summary>
        /// Номер
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Тарифный план
        /// </summary>
        public string TariffPlan { get; set; }
        /// <summary>
        /// Международный идентификатор мобильного абонента
        /// </summary>
        public long IMSI { get; set; }
        /// <summary>
        /// Номер ЛС
        /// </summary>
        public long AccountNumber { get; set; }
    }
}