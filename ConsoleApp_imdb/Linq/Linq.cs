using ConsoleApp_imdb.Data;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp_imdb.Linq
{
    class Linq
    {
        public async Task<List<object>> GetMovieDetails()
        {
            using (var context = new ImdbContext())
            {
                var movieDetails = await context.Movies
                    .Select(m => new
                    {
                        Movie = m.Title,
                        ReleaseDate = m.ReleaseDate,
                        Genres = string.Join(", ", m.GenreMovies.Select(gm => gm.Genre.Name)),
                        Director = m.Director.Name + " " + m.Director.Surname,
                        Writer = m.Writer.Name + " " + m.Writer.Surname,
                        Rating = m.Rating.Value
                    })
                    .OrderBy(m => m.Movie)
                    .ToListAsync();

                return movieDetails.Cast<object>().ToList();
            }
        }

        public async Task<List<object>> GetActorsWithMovieCount()
        {
            using (var context = new ImdbContext())
            {
                var actorStats = await context.Actors
                    .Select(a => new
                    {
                        Actor = a.Name + " " + a.Surname,
                        MovieCount = a.MovieActors.Count(),
                        Movies = string.Join(", ", a.MovieActors.Select(ma => ma.Movie.Title))
                    })
                    .OrderByDescending(a => a.MovieCount)
                    .ThenBy(a => a.Actor)
                    .ToListAsync();

                return actorStats.Cast<object>().ToList();
            }
        }

        
        public async Task<List<object>> GetDirectorsWithMovieCount()
        {
            using (var context = new ImdbContext())
            {
                var directorStats = await context.Directors
                    .Select(d => new
                    {
                        Director = d.Name + " " + d.Surname,
                        MovieCount = d.Movies.Count(),
                        Movies = string.Join(", ", d.Movies.Select(m => m.Title))
                    })
                    .OrderByDescending(d => d.MovieCount)
                    .ThenBy(d => d.Director)
                    .ToListAsync();

                return directorStats.Cast<object>().ToList();
            }
        }


        public async Task<List<object>> GetMoviesWithRatingAbove8()
        {
            using (var context = new ImdbContext())
            {
                var moviesWithGenres = await context.Movies
                    .Where(m => m.Rating > 8)
                    .Select(m => new
                    {
                        Title = m.Title,
                        ReleaseDate = m.ReleaseDate,
                        Duration = m.Duration,
                        Genres = string.Join(", ", m.GenreMovies
                            .Select(gm => gm.Genre.Name))
                    })
                    .OrderBy(m => m.Title)
                    .ToListAsync();

                return moviesWithGenres.Cast<object>().ToList();
            }
        }
    }
}
