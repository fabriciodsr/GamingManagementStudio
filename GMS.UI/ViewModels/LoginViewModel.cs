using System.ComponentModel.DataAnnotations;

namespace GMS.UI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório!")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim?")]
        public bool RememberMe { get; set; }
    }
}