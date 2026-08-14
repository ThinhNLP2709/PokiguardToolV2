namespace PokiGame.LegendPet;

public class LegendPetListResponseWithSuccess
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public LegendPetBasicInfo[] pets; //Field offset: 0x20

	public LegendPetListResponseWithSuccess() { }

}

