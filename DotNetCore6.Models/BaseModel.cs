using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore6.Models
{
    public class BaseModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
   
        [Column(Order = 15)]
        //[DefaultValue("getdate()")]
        //[DefaultValue(typeof(DateTime), "getdate()")]
        //[DefaultValue(DefaultValue = "getutcdate()")]

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(Order = 16)]
        [DefaultValue("0")]
        public int CreatedBy { get; set; } = 1;

        [Column(Order = 17)]
        public DateTime? UpdatedDate { get; set; }

        [Column(Order = 18)]
        public int? UpdatedBy { get; set; }

        [Column(Order = 19)]
        public bool IsDeleted { get; set; } = false;
    }
}