//Type is in global namespace

public class CardData
{
	public long id; //Field offset: 0x10
	public long cardId; //Field offset: 0x18
	public string name; //Field offset: 0x20
	public string description; //Field offset: 0x28
	public string elementTypeCard; //Field offset: 0x30
	public int value; //Field offset: 0x38
	public int maxLevel; //Field offset: 0x3C
	public int count; //Field offset: 0x40
	public int level; //Field offset: 0x44
	public long conditionUse; //Field offset: 0x48
	public long power; //Field offset: 0x50
	public int green; //Field offset: 0x58
	public int blue; //Field offset: 0x5C
	public int red; //Field offset: 0x60
	public int yellow; //Field offset: 0x64
	public int white; //Field offset: 0x68
	public int purple; //Field offset: 0x6C
	public float damageMultiplier; //Field offset: 0x70
	public string skillType; //Field offset: 0x78
	public int manaCost; //Field offset: 0x80
	public int powerCost; //Field offset: 0x84
	public int cooldownTurns; //Field offset: 0x88
	public bool needPerfection; //Field offset: 0x8C
	public int eatPerfect; //Field offset: 0x90
	public int eatGood; //Field offset: 0x94
	public int eatBad; //Field offset: 0x98

	public CardData() { }

	public bool CanUse() { }

	public ElementTypeCard GetElementType() { }

}

