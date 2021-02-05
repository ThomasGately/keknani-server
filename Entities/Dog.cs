using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace keknani_server.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Neutered { get; set; }
        public string Sex { get; set; }
        public string Description { get; set; }
        public List<string> ImgPaths { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}