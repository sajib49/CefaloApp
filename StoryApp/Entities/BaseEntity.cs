using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StoryApp.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("Id")]
        public long Id { get; set; }

        [DefaultValue(false)]
        [Column("_isDeleted")]
        public bool IsDeleted { get; set; }
        [Column("_createdAt")]
        public DateTime CreatedAt { get; set; }
        [Column("_lastModifiedAt")]
        public DateTime? LastModifiedAt { get; set; }
        [Column("_createdBy")]
        public long? CreatedBy { get; set; }
        [Column("_lastModifiedBy")]
        public long? LastModifiedBy { get; set; }

    }
}
