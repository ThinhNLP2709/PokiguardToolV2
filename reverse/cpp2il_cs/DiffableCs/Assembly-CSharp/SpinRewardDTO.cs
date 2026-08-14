//Type is in global namespace

public class SpinRewardDTO
{
	public int spinIndex; //Field offset: 0x10
	public int prizeIndex; //Field offset: 0x14
	public string prizeType; //Field offset: 0x18
	public int prizeId; //Field offset: 0x20
	public string prizeName; //Field offset: 0x28
	public int amount; //Field offset: 0x30
	public string rarity; //Field offset: 0x38
	public string iconPath; //Field offset: 0x40
	public string elementType; //Field offset: 0x48
	public int stoneLevel; //Field offset: 0x50
	public bool isDuplicate; //Field offset: 0x54
	public int compensationGold; //Field offset: 0x58
	public WeaponDropDTO weaponDrop; //Field offset: 0x60
	public int weaponImageId; //Field offset: 0x68

	public SpinRewardDTO() { }

}

