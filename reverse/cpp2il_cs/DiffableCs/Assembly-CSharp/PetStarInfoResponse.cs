//Type is in global namespace

public class PetStarInfoResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public long petId; //Field offset: 0x20
	public int star; //Field offset: 0x28
	public int maxStar; //Field offset: 0x2C
	public int shardCount; //Field offset: 0x30
	public int nextCost; //Field offset: 0x34
	public int bonusPercent; //Field offset: 0x38
	public int nextBonusPercent; //Field offset: 0x3C
	public bool owned; //Field offset: 0x40
	public bool finalForm; //Field offset: 0x41
	public bool canUpgrade; //Field offset: 0x42
	public string blockedReason; //Field offset: 0x48
	public int hp; //Field offset: 0x50
	public int attack; //Field offset: 0x54
	public int mana; //Field offset: 0x58
	public int hpNext; //Field offset: 0x5C
	public int attackNext; //Field offset: 0x60
	public int manaNext; //Field offset: 0x64

	public PetStarInfoResponse() { }

}

