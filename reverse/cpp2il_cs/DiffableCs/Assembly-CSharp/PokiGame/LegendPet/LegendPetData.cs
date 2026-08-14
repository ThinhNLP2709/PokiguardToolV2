namespace PokiGame.LegendPet;

public class LegendPetData
{
	public long petId; //Field offset: 0x10
	public string name; //Field offset: 0x18
	public string description; //Field offset: 0x20
	public int totalStars; //Field offset: 0x28
	public int inlaidStars; //Field offset: 0x2C
	public bool unlocked; //Field offset: 0x30
	public List<ImageHTData> images; //Field offset: 0x38

	public LegendPetData() { }

}

