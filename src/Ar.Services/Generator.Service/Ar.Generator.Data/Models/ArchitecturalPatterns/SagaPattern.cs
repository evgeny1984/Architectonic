using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.ArchitecturalPatterns
{
    public class SagaPattern : DesignPattern
    {
        public SagaPattern()
        {

        }

        #region Relationships

        public WorkflowEngine WorkflowEngine { get; set; }

        #endregion
    }
}
