﻿using System;
namespace Models.CoreModels
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string RunningTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
    }
}