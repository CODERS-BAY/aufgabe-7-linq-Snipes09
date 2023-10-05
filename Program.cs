using System;

namespace LinqExercise
{
    public class Program
    {
        public static void Main()
        {
            FilmOperations filmOperations = new FilmOperations();

            var allMovies = filmOperations.GetAllMovies();
            Console.WriteLine("All Movies:");
            foreach (Film film in allMovies)
            {
                Console.WriteLine(
                    $"{film.Title} | Regisseur: {film.Director} | Release Year: {film.ReleaseYear} | Rating: {film.Rating}");
            }

            Console.WriteLine("\nMovies from Francis Ford Coppola:");
            var moviesByFrancisFordCoppola = filmOperations.GetMoviesByDirector("Francis Ford Coppola");
            foreach (Film film in moviesByFrancisFordCoppola)
            {
                Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
            }

            Console.WriteLine("\nMovies from 1994:");
            var filmsFrom1994 = filmOperations.GetMoviesByYear(1994);
            foreach (Film film in filmsFrom1994)
            {
                Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
            }

            Console.WriteLine("\nMovies with rating between 8 and 10:");
            var filmsByRating = filmOperations.GetMoviesByRatingRange(8.0, 10.0);
            foreach (Film film in filmsByRating)
            {
                Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");

            }

            Console.WriteLine("\nThe 5 best rating movies:");
            var top5RatedFilms = filmOperations.GetMoviesByRatingSortedLimited(5);
            foreach (Film film in top5RatedFilms)
            {
                Console.WriteLine($"{film.Title} {film.Director} {film.ReleaseYear} {film.Rating}");
            }

        }
    }
}   