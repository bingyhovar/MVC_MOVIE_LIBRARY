﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Controllers;
using WpfApp1.Models;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MovieController controller;


        public MainWindow()
        {
            InitializeComponent();

            controller = new MovieController();
            LoadMovies();
        }

        public void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string director = DirectorTextBox.Text;
            if(int.TryParse(YearTextBox.Text, out int year))
            {
                string genre = GenreTextBox.Text;
                Movie movie = new Movie { Title = title, Director = director, Year = year, Genre = genre };

                controller.AddMovie(movie);
                LoadMovies();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please enter a valid year.");
            }

          
        }
        public void DeleteMovieButton_Click(Object sender, RoutedEventArgs e)
        {
            if((sender as Button)?.Tag is Movie movie)
            {
                controller.RemoveMovie(movie);
                LoadMovies();
            }
        }

        private void LoadMovies()
        {
            MoviesListBox.ItemsSource = null;
            MoviesListBox.ItemsSource = controller.GetMovies();

        }

        private void ClearFields()
        {
            TitleTextBox.Text = "";
            DirectorTextBox.Text = "";
            YearTextBox.Text = "";
            GenreTextBox.Text = "";
        }
    }
}
