namespace Staris.Domain.Entities
{
	public sealed class CharacterPlanet
    {
        public int CharacterId { get; set; }
        public int PlanetId { get; set; }


        //EF Relation
        public Character? Character { get; set; }
        public Planet? Planet { get; set; }
	}
}
