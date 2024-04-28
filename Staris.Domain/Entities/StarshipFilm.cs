namespace Staris.Domain.Entities
{
    public class StarshipFilm
	{
        public int StartshipId { get; set; }
        public int FilmId { get; set; }

        //EF Relation
        public Starship? Startship { get; init; }
        public Film? Film { get; init; }
    }
}