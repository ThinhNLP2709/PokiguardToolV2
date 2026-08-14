//Type is in global namespace

public class UserWeaponDTO
{
	public long id; //Field offset: 0x10
	public long weaponId; //Field offset: 0x18
	public int imageId; //Field offset: 0x20
	public string name; //Field offset: 0x28
	public string rarity; //Field offset: 0x30
	public int star; //Field offset: 0x38
	public int maxStar; //Field offset: 0x3C
	public int atk; //Field offset: 0x40
	public int hp; //Field offset: 0x44
	public int mana; //Field offset: 0x48
	public int critRate; //Field offset: 0x4C
	public int effectResist; //Field offset: 0x50
	public int effectRate; //Field offset: 0x54
	public string element; //Field offset: 0x58
	public int power; //Field offset: 0x60
	public string source; //Field offset: 0x68
	public bool equipped; //Field offset: 0x70
	public int shardCostNext; //Field offset: 0x74

	public UserWeaponDTO() { }

}

