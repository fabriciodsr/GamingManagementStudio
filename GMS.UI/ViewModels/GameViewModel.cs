using GMS.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace GMS.UI.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set;  }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Display(Name = "Nome: *")]
        public string Name { get; set; }

        [Display(Name = "Genero: ")]
        public Genre? Genre { get; set; }

        [Display(Name = "Plataforma: ")]
        public Platform? Platform { get; set; }

        [Display(Name = "Imagem: ")]
        public string Image { get; set; }

        [Display(Name = "Desenvolvedor: ")]
        public string Developer { get; set; }

        public HttpPostedFileBase File { get; set; }
        public IList<SelectListItem> Genres { get; set; }
        public IList<SelectListItem> Platforms { get; set; }
    }
}