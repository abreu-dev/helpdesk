using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Infra.Globalization
{
    public enum Language
    {
        [Display(Description = "en")]
        EN = 0,

        [Display(Description = "pt-BR")]
        PT_BR = 1
    }
}