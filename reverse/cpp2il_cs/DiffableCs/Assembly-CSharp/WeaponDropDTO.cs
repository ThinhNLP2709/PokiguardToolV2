//Type is in global namespace

public class WeaponDropDTO
{
	public long userWeaponId; //Field offset: 0x10
	public long weaponId; //Field offset: 0x18
	public int imageId; //Field offset: 0x20
	public string name; //Field offset: 0x28
	public string rarity; //Field offset: 0x30
	public int star; //Field offset: 0x38
	public int atk; //Field offset: 0x3C
	public int hp; //Field offset: 0x40
	public int mana; //Field offset: 0x44
	public int critRate; //Field offset: 0x48
	public int effectResist; //Field offset: 0x4C
	public int effectRate; //Field offset: 0x50
	public string element; //Field offset: 0x58
	public int power; //Field offset: 0x60
	public bool convertedToShards; //Field offset: 0x64
	public int shardAmount; //Field offset: 0x68

	public bool HasDrop
	{
		 get { } //Length: 14
	}

	public WeaponDropDTO() { }

	public bool get_HasDrop() { }

}

