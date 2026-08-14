//Type is in global namespace

public class MiniGameSpinResponse
{
	public List<String> topRow; //Field offset: 0x10
	public int goldEarned; //Field offset: 0x18
	public int spinCost; //Field offset: 0x1C
	public int netGold; //Field offset: 0x20
	public int currentGold; //Field offset: 0x24
	public string matchDescription; //Field offset: 0x28
	public int challengeLevel; //Field offset: 0x30
	public int goldTowardTarget; //Field offset: 0x34
	public int targetGold; //Field offset: 0x38
	public bool challengeCompleted; //Field offset: 0x3C
	public MiniGameRewardDTO challengeReward; //Field offset: 0x40
	public int totalGoldToday; //Field offset: 0x48

	public MiniGameSpinResponse() { }

}

