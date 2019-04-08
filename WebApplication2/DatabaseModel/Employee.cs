using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

#pragma warning disable
namespace WebApplication2
{

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public int Age { get; set; }

        [Required]
        public byte Gender { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal Salary { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public int WorkContact { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public int Mobile { get; set; }
    }
}
