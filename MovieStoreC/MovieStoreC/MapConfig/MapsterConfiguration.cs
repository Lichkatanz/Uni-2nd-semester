using Mapster;
using MovieStoreC.Models.DTO;
using MovieStoreC.Models.Requests;

namespace MovieStoreC.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>
                .NewConfig();
        }
    }
}
