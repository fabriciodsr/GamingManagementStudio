using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GMS.Domain.Enums
{
    public enum Genre
    {
        [Display(Name = "Ação")]
        Action,
        [Display(Name = "Aventura")]
        Adventure,
        [Display(Name = "Corrida")]
        Racing,
        [Display(Name = "Estratégia")]
        Strategy,
        [Display(Name = "Esporte")]
        Sport,
        [Display(Name = "Luta")]
        Fighting,
        [Display(Name = "RPG")]
        RPG,
        [Description("Simulador")]
        Simulation,
        [Display(Name = "FPS")]
        FPS,
        [Display(Name = "Fantasia")]
        Fantasy,
        [Description("Outros Gêneros")]
        Others
    }
}
