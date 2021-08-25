using Ar.Generator.Data.Models.SolutionAppConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(ClientApplication))]
    public class ClientApplication : Application
    {

        #region Columns

        public string Framework { get; set; }
        public ClientType ClientType { get; set; }

        #endregion

    }
}
