using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LinqExercise

{
    public class FilmOperations
    {
      
        private List<Film> _movies;

        public FilmOperations()
        {
            _movies = GetAllMovies();
        }


        /// <returns>eine Liste aller Filme zurück.</returns>
        public List<Film> GetAllMovies()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Codersbay\aufgabe-7-linq-Snipes09\films.json"))
            {
                string json = reader.ReadToEnd();
                _movies = JsonConvert.DeserializeObject<List<Film>>(json);
            }
            return _movies;
        }

         /// <returns>ein Array von Filmen zurück, die von dem angegebenen Regisseur stammen.</returns>
         public Film[] GetMoviesByDirector(string director)
         {
              // return movies.Where(f => f.Director == director).ToArray();
              var query = 
                  from movie in _movies
                  where movie.Director == director
                  select movie;

              return query.ToArray();
         }

         /// <returns>ein Array von Filmen zurück, die im angegebenen Erscheinungsjahr veröffentlicht wurden.</returns>
         public Film[] GetMoviesByYear(int releaseYear)
         {
            // return movies.Where(f => f.ReleaseYear == releaseYear).ToArray();
            var query = 
                from movie in _movies
                where movie.ReleaseYear == releaseYear
                select movie;

            return query.ToArray();
         }

         /// <returns>ein Array von Filmen zurück, die zwischen der angegebenen Mindest- und Höchstbewertung liegen.</returns>
         public Film[] GetMoviesByRatingRange(double minRating, double maxRating)
         {
           return _movies.Where(f => f.Rating >= minRating && f.Rating <= maxRating).ToArray();
         }


         /// <returns>gibt ein Array mit den best bewerteten Filme zurück, sortiert nach Bewertung. numberOfFilms gibt die
         /// Anzahl der zurückgegeben Filme an.</returns>
         public Film[] GetMoviesByRatingSortedLimited(int numberOfFilms)
         {
             return _movies.OrderByDescending(f => f.Rating).Take(numberOfFilms).ToArray();
         }
   }
}