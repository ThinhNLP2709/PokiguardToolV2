//Type is in global namespace

public class ShopPackageDTO
{
	public long id; //Field offset: 0x10
	public string name; //Field offset: 0x18
	public string description; //Field offset: 0x20
	public string iconUrl; //Field offset: 0x28
	public int price; //Field offset: 0x30
	public string currencyType; //Field offset: 0x38
	public int gold; //Field offset: 0x40
	public int ruby; //Field offset: 0x44
	public int safia; //Field offset: 0x48
	public int energy; //Field offset: 0x4C
	public int exp; //Field offset: 0x50
	public int starWhite; //Field offset: 0x54
	public int starBlue; //Field offset: 0x58
	public int starRed; //Field offset: 0x5C
	public int wheel; //Field offset: 0x60
	public long petId; //Field offset: 0x68
	public string petName; //Field offset: 0x70
	public long avtId; //Field offset: 0x78
	public string avtName; //Field offset: 0x80
	public long stoneId; //Field offset: 0x88
	public string stoneName; //Field offset: 0x90
	public int stoneCount; //Field offset: 0x98
	public string stoneElement; //Field offset: 0xA0
	public int stoneLevel; //Field offset: 0xA8
	public long cardId; //Field offset: 0xB0
	public string cardName; //Field offset: 0xB8
	public int cardCount; //Field offset: 0xC0
	public ShardRewardItem[] shards; //Field offset: 0xC8
	public WeaponRewardItem[] weapons; //Field offset: 0xD0
	public int weaponPiece; //Field offset: 0xD8
	public int maxPurchasePerDay; //Field offset: 0xDC
	public int purchasedToday; //Field offset: 0xE0
	public bool canPurchase; //Field offset: 0xE4

	public ShopPackageDTO() { }

}

