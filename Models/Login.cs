using System;
using System.ComponentModel.DataAnnotations;

public class LogIn
{
    [Key]
    public string Id { get; set; }           // nchar → nvarchar로 바뀜
    public string Password { get; set; }
    public string NickName { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}