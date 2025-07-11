﻿using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [JsonIgnore]
        public AutorModel Autor { get; set; }
    }
}
