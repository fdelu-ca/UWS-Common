using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DiagnosticProcess
{

    public class StatusType
    {
        public int Id { get; set; }

        [MaxLength(30), Required]
        public string ProcessType { get; set; } //Weighting, Recognition,Documentation

        [MaxLength(30), Required]
        public string Name { get; set; }

        [MaxLength(10), Required]
        public string DataType { get; set; }    //Boolean, Integer, Float, String, DateTime, Binary

        [MaxLength(50), Required]
        public string DisplayTitle { get; set; }
        [MaxLength(100),]
        public string Description { get; set; }

        [Column(TypeName = "datetime"), DefaultValue("(getDate())")]
        public DateTime DateCreated { get; set; }
    }
}