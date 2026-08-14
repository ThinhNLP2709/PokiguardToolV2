//Type is in global namespace

public class MiniGameInfoResponse
{
	public int challengeLevel; //Field offset: 0x10
	public int goldTowardTarget; //Field offset: 0x14
	public int targetGold; //Field offset: 0x18
	public int totalGoldToday; //Field offset: 0x1C
	public int spinCost; //Field offset: 0x20
	public int userRank; //Field offset: 0x24
	public List<MiniGameRankDTO> top3; //Field offset: 0x28

	public MiniGameInfoResponse() { }

}

