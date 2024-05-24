using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        public String? UserName { get; init; }

        [Required(ErrorMessage ="Şifre Alanı Boş Bırakılamaz.")]
        [DataType(DataType.Password)]
        public String? Password { get; init; }

        [Required(ErrorMessage = "Şifre Onaylama Alanı Boş Bırakılamaz.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler eşleştirilemedi.")]
        public String? ConfirmPassword { get; init; }
    }
}
