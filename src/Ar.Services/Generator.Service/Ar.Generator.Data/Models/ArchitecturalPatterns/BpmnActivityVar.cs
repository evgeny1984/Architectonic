using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    [Table(nameof(BpmnActivityVar))]
    public class BpmnActivityVar : BaseEntity
    {
        public BpmnActivityVar()
        {
        }

        #region Columns

        public string Name { get; set; }

        public string ValueType { get; set; }

        #endregion

        #region Relationships

        public BpmnActivity BpmnActivity { get; set; }

        #endregion
    }
}
