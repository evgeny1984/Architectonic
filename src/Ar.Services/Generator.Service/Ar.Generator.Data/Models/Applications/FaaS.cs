using Ar.Generator.Data.Models.SolutionAppConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(FaaS))]
    public class FaaS : Application
    {

        #region Columns

        public string Uri { get; set; }

        #endregion

    }
}
