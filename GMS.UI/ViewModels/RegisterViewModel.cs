using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMS.UI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O e-mail inserido é inválido!")]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Usuário ")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha: ")]
        [Compare("Password", ErrorMessage = "As senhas inseridas não coincidem!")]
        public string ConfirmPassword { get; set; }
    }
}