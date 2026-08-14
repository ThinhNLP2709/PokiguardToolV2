//Type is in global namespace

public class GameReward
{
	public List<RewardStone> stones; //Field offset: 0x10
	public bool receivedPet; //Field offset: 0x18
	public bool win; //Field offset: 0x19
	public string petElement; //Field offset: 0x20
	public int petId; //Field offset: 0x28
	public int requestAttack; //Field offset: 0x2C
	public int bonusGold; //Field offset: 0x30
	public int expGain; //Field offset: 0x34

	public GameReward() { }

}

