//Type is in global namespace

public class PvpMatchHistoryDTO
{
	public string matchId; //Field offset: 0x10
	public int enemyUserId; //Field offset: 0x18
	public string enemyName; //Field offset: 0x20
	public bool victory; //Field offset: 0x28
	public int rankChange; //Field offset: 0x2C
	public int rankAfter; //Field offset: 0x30
	public int turnCount; //Field offset: 0x34
	public string battleDate; //Field offset: 0x38

	public PvpMatchHistoryDTO() { }

}

