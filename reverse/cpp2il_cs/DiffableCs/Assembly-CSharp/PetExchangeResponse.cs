//Type is in global namespace

public class PetExchangeResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public string code; //Field offset: 0x20
	public long petId; //Field offset: 0x28
	public string petName; //Field offset: 0x30
	public string elementType; //Field offset: 0x38
	public int shardLeft; //Field offset: 0x40
	public int exchangeCost; //Field offset: 0x44
	public bool owned; //Field offset: 0x48
	public int star; //Field offset: 0x4C
	public int maxStar; //Field offset: 0x50
	public int nextCost; //Field offset: 0x54
	public bool finalForm; //Field offset: 0x58
	public bool canUpgrade; //Field offset: 0x59
	public string blockedReason; //Field offset: 0x60

	public PetExchangeResponse() { }

}

