namespace PokiGame.LegendPet;

public class UnlockPetResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public LegendPetData petData; //Field offset: 0x20
	public UnlockRewards rewards; //Field offset: 0x28

	public UnlockPetResponse() { }

}

