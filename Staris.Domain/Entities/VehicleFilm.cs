namespace Staris.Domain.Entities
{
    public class VehicleFilm
    {
        public int VehicleId { get; set; }
        public int FilmId { get; set; }

        //EF Relation
        public Vehicle? Vehicle { get; init; }
        public Film? Film { get; init; }
    }
}