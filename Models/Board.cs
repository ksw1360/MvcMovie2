using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MvcMovie2.Models
{
    [Table("Board")] // ★ 테이블 이름 매칭 (Boards 방지)
    public class Board : DbContext
    {
        [Key] // PK 설정
        public int BoardId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Writer { get; set; }

        public int ViewCount { get; set; }

        public DateTime RegDate { get; set; }

        //public DbSet<Board> board { get; set; }
    }
}