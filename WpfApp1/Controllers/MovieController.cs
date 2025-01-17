﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;



namespace WpfApp1.Controllers
{
    public class MovieController
    {
        private MovieRepository repository;

        public MovieController()
        {
            repository = new MovieRepository();
        }

        public List<Movie> GetMovies()
        {
            return repository.GetAll();
        }

        public void AddMovie(Movie movie)
        {
            repository.Add(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            repository.Remove(movie);
        }
    }
}
