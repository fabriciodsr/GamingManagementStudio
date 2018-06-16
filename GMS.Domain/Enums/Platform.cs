using System.ComponentModel.DataAnnotations;

namespace GMS.Domain.Enums
{
    public enum Platform
    {
        [Display(Name = "PlayStation 1")]
        PlayStation1,
        [Display(Name = "PlayStation 2")]
        PlayStation2,
        [Display(Name = "PlayStation 3")]
        PlayStation3,
        [Display(Name = "PlayStation 4")]
        PlayStation4,
        [Display(Name = "X Box 360")]
        Xbox360,
        [Display(Name = "X Box One")]
        XboxOne,
        [Display(Name = "X Box One S")]
        XboxOneS,
        [Display(Name = "X Box One X")]
        XboxOneX,
        [Display(Name = "Nintendo 64")]
        Nintendo64,
        [Display(Name = "Nintendo Wii")]
        NintendoWii,
        [Display(Name = "Nintendo Wii U")]
        NintendoWiiU,
        [Display(Name = "Nintendo Switch")]
        NintendoSwitch,
        [Display(Name = "Computador")]
        Computador,
    }
}
