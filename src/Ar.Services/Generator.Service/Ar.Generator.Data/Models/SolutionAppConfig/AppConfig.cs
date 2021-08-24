﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.SolutionAppConfig
{
    [Table(nameof(AppConfig))]
    public class AppConfig : BaseEntity
    {

        #region Columns

        public string BaseName { get; set; }

        public int ServerPort { get; set; }

        public string AppNamespace { get; set; }

        public AppType ApplicationType { get; set; }

        #endregion

    }
}
