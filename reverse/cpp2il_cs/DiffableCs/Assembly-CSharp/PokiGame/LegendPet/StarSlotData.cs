namespace PokiGame.LegendPet;

public class StarSlotData
{
	public long slotId; //Field offset: 0x10
	public int starType; //Field offset: 0x18
	public int slotPosition; //Field offset: 0x1C
	public int requiredStarCount; //Field offset: 0x20
	public bool inlaid; //Field offset: 0x24
	public bool canInlay; //Field offset: 0x25

	public StarSlotData() { }

}

