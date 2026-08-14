//Type is in global namespace

public class GiftDTO
{
	public int id; //Field offset: 0x10
	public int userId; //Field offset: 0x14
	public string title; //Field offset: 0x18
	public string description; //Field offset: 0x20
	public string giftType; //Field offset: 0x28
	public string status; //Field offset: 0x30
	public int gold; //Field offset: 0x38
	public int energy; //Field offset: 0x3C
	public int exp; //Field offset: 0x40
	public int starWhite; //Field offset: 0x44
	public int starBlue; //Field offset: 0x48
	public int starRed; //Field offset: 0x4C
	public int ruby; //Field offset: 0x50
	public int wheel; //Field offset: 0x54
	public int crystal; //Field offset: 0x58
	public int eItem1; //Field offset: 0x5C
	public int eItem2; //Field offset: 0x60
	public int eItem3; //Field offset: 0x64
	public int eItem4; //Field offset: 0x68
	public int wheelDay; //Field offset: 0x6C
	public int avtId; //Field offset: 0x70
	public int petId; //Field offset: 0x74
	public string petName; //Field offset: 0x78
	public int cardId; //Field offset: 0x80
	public string cardName; //Field offset: 0x88
	public StoneRewardDTO[] stones; //Field offset: 0x90
	public ShardRewardItem[] shards; //Field offset: 0x98
	public WeaponRewardItem[] weapons; //Field offset: 0xA0
	public int weaponPiece; //Field offset: 0xA8
	public WeaponDropDTO[] grantedWeapons; //Field offset: 0xB0
	public string createdAt; //Field offset: 0xB8
	public string expiredAt; //Field offset: 0xC0
	public string claimedAt; //Field offset: 0xC8

	public GiftDTO() { }

}

