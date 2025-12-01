using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Movie")]  // 테이블 이름 명시 (대소문자 구분 방지)
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [StringLength(255)]
        public string Genre { get; set; }

        [StringLength(255)]
        public string Director { get; set; }

        [StringLength(255)]
        public string LeadActor { get; set; }

        public long? Size { get; set; }                 // bigint → long

        public int? Year { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public int? Runtime { get; set; }               // 분 단위

        //[Column(TypeName = "decimal(3,1)")]
        public decimal? Rating { get; set; }            // 9.5, 8.7 등

        [DataType(DataType.MultilineText)]
        public string Plot { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Language { get; set; }

        [StringLength(500)]
        public string PosterURL { get; set; }

        public long? Budget { get; set; }

        public long? Revenue { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}