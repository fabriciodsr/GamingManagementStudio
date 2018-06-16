using System.ComponentModel.DataAnnotations;

namespace GMS.UI.ViewModels
{
    public class FriendViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Display(Name = "Nome completo: *")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório!")]
        [Display(Name = "E-mail: *")]
        [EmailAddress(ErrorMessage ="O E-mail informado é inválido!")]
        public string Email { get; set; }

        [Display(Name = "CEP: *")]
        [StringLength(10)]
        [Required(ErrorMessage = "O campo CEP é obrigatório!")]
        public string ZipCode { get; set; }

        [Display(Name = "Endereço: *")]
        [Required(ErrorMessage = "O campo Endereço é obrigatório!")]
        public string Address { get; set; }

        [Display(Name = "Número: *")]
        [Required(ErrorMessage = "O campo Número é obrigatório!")]
        public int? Number { get; set; }

        [Display(Name = "Complemento:")]
        public string AddressComplement { get; set; }

        [Display(Name = "Bairro: *")]
        [Required(ErrorMessage = "O campo Bairro é obrigatório!")]
        public string Neighborhood { get; set; }

        [Display(Name = "Cidade:*")]
        [Required(ErrorMessage = "O campo Cidade é obrigatório!")]
        public string City { get; set; }

        [Display(Name = "UF: *")]
        [StringLength(2)]
        [Required(ErrorMessage = "O campo UF é obrigatório!")]
        public string State { get; set; }

        [Display(Name = "Celular: *")]
        [StringLength(15)]
        [Required(ErrorMessage = "O campo Celular é obrigatório!")]
        public string Cellphone { get; set; }

        [Display(Name = "Rede Social: ")]
        public string SocialNetwork { get; set; }
    }
}