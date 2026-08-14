namespace Poki.Assets.Script.Boss.xephang;

public class BossRankingPlayerDTO
{
	public long userId; //Field offset: 0x10
	public string userName; //Field offset: 0x18
	public long userPetId; //Field offset: 0x20
	public long petId; //Field offset: 0x28
	public long bossId; //Field offset: 0x30
	public int totalDamage; //Field offset: 0x38
	public int rank; //Field offset: 0x3C
	public bool canClaimReward; //Field offset: 0x40
	public bool rewardClaimed; //Field offset: 0x41

	public BossRankingPlayerDTO() { }

}

