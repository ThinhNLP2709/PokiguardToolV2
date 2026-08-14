namespace PokiGame.LegendPet;

public class InlayStarResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public int remainingWhiteStars; //Field offset: 0x20
	public int remainingBlueStars; //Field offset: 0x24
	public int remainingRedStars; //Field offset: 0x28
	public bool petUnlocked; //Field offset: 0x2C

	public InlayStarResponse() { }

}

