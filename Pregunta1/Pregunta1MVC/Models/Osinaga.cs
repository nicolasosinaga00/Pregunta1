namespace Pregunta1MVC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum PlaceType
    {
        Centro = 1,
        ZonaNorte = 2,
        Urubo = 3,
        LasPalmas = 4,
        ZonaSur = 5,
    }
    public class Osinaga
    {
        [Key]
        public int OsinagaID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
        public string FriendofOsinaga { get; set; }

        [Required(ErrorMessage = "Debe ingresar el lugar")]
        public PlaceType Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Cumpleanos")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

    }
}