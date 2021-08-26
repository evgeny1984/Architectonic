using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class BpmnActivityHandlerDto : BaseEntityDto
    {
        #region FKs

        public int ResponsibleApplicationId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string TransactionEndpoint { get; set; }

        public string CompensatingTransactionEndpoint { get; set; }

        public bool NotifyOnFailure { get; set; }

        #endregion<

    }
}
