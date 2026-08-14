//Type is in global namespace

public class SpinResultDTO
{
	public List<SpinRewardDTO> rewards; //Field offset: 0x10
	public int totalGoldSpent; //Field offset: 0x18
	public int remainingGold; //Field offset: 0x1C
	public int remainingWheel; //Field offset: 0x20
	public bool isDuplicate; //Field offset: 0x24
	public int compensationGold; //Field offset: 0x28
	public bool success; //Field offset: 0x2C
	public string message; //Field offset: 0x30
	public int prizeIndex; //Field offset: 0x38
	public string prizeType; //Field offset: 0x40
	public long prizeId; //Field offset: 0x48
	public string prizeName; //Field offset: 0x50
	public int amount; //Field offset: 0x58
	public string rarity; //Field offset: 0x60
	public string elementType; //Field offset: 0x68
	public int stoneLevel; //Field offset: 0x70
	public WeaponDropDTO weaponDrop; //Field offset: 0x78

	public SpinResultDTO() { }

}

