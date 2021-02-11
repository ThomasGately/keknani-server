using System.ComponentModel.DataAnnotations;


namespace keknani_server.Models.Dogs
{
    public class DogCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Neutered { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string[] ImgPaths { get; set; }

    }
}