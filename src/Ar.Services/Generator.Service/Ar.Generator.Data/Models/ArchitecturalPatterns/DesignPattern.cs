using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(DesignPattern))]
    public class DesignPattern : BaseEntity
    {
        public DesignPattern()
        {

        }

        #region Columns

        public string Name { get; set; }

        public string Problem { get; set; }

        #endregion

        #region Relationships

        #endregion
    }
}
