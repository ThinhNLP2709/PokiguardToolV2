//Type is in global namespace

public class AvatarExchangeItemDTO
{
	public long avatarId; //Field offset: 0x10
	public long item1Id; //Field offset: 0x18
	public int item1Required; //Field offset: 0x20
	public int item1Current; //Field offset: 0x24
	public long item2Id; //Field offset: 0x28
	public int item2Required; //Field offset: 0x30
	public int item2Current; //Field offset: 0x34
	public long item3Id; //Field offset: 0x38
	public int item3Required; //Field offset: 0x40
	public int item3Current; //Field offset: 0x44
	public int e3Required; //Field offset: 0x48
	public int e3Current; //Field offset: 0x4C
	public bool canExchange; //Field offset: 0x50
	public bool alreadyExchanged; //Field offset: 0x51
	public int attack; //Field offset: 0x54
	public int hp; //Field offset: 0x58
	public int mana; //Field offset: 0x5C

	public AvatarExchangeItemDTO() { }

}

