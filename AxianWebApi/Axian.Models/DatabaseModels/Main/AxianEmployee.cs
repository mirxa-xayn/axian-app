using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Axian.Models.DatabaseModels.Main
{
    public class AxianEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

    }
}
