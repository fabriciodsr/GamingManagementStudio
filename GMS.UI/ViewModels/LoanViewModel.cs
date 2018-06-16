using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GMS.UI.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; set; }

        [Required]
        public int FriendId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Display(Name = "Data do Empréstimo: ")]
        [Required(ErrorMessage = "É obrigatória a escolha de uma data para o empréstimo!")]
        public DateTime LoanDate { get; set; }

        [Display(Name = "Data de Devolução: ")]
        public DateTime? DeliveredDate { get; set; }

        [Required(ErrorMessage = "É obrigatória a escolha de um amigo!")]
        [Display(Name = "Selecione um amigo: ")]
        public IList<SelectListItem> Friends { get; set; }

        [Required(ErrorMessage = "É obrigatória a escolha de um jogo!")]
        [Display(Name = "Selecione um jogo: ")]
        public IList<SelectListItem> Games { get; set; }
    }
}