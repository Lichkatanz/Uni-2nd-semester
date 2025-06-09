namespace MovieStoreC.Models.Requests
{
    public class AddMovieRequest
    {
        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }
    }
}
