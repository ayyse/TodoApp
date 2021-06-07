using System.ComponentModel.DataAnnotations;

namespace TodoApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}