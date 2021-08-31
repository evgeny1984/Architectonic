using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class ClientApplicationDto : ApplicationDto
    {

        #region Columns

        public string Framework { get; set; }
        public ClientType ClientType { get; set; }

        #endregion

    }
}
