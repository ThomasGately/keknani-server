using System;
using System.Collections.Generic;

namespace keknani_server.Models.Dogs
{
    public class DogResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Neutered { get; set; }
        public string Sex { get; set; }
        public string[] ImgPaths { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}