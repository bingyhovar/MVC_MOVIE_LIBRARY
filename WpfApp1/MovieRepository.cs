﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp1.Models
{
    public class MovieRepository
    {
        private const string FilePath = "movies.json";
        private List<Movie> movies;

        public MovieRepository()
        {
            //movies = new List<Movie>();
            movies = LoadMovies();

        }

        public List<Movie> GetAll()
        {
            return movies.ToList();
        }

        public void Add(Movie movie)
        {
            movies.Add(movie);
            SaveMovies();
        }

        public void Remove(Movie movie)
        {
            movies.Remove(movie);
            SaveMovies();
        }

        private List<Movie> LoadMovies()
        {
            if (File.Exists(FilePath)) // check if the file movies.json existsm if it does run the below code
            {
                string json = File.ReadAllText(FilePath); // read all the text from the file
                return JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
            }
            return new List<Movie>();
        }

        private void SaveMovies()
        {
            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

    }
}
