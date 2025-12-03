using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "아이디를 입력하세요")]
        [Display(Name = "아이디")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        [DataType(DataType.Password)]
        [Display(Name = "비밀번호")]
        public string Password { get; set; }

        [Display(Name = "로그인 상태 유지")]
        public bool RememberMe { get; set; }
    }
}