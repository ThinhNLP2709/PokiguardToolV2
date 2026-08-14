namespace Poki.Assets.Script.Boss.xephang;

public class BossRankingResponseDTO
{
	public long bossScheduleId; //Field offset: 0x10
	public string bossName; //Field offset: 0x18
	public List<BossRankingPlayerDTO> topPlayers; //Field offset: 0x20
	public BossRankingPlayerDTO currentPlayer; //Field offset: 0x28
	public string status; //Field offset: 0x30
	public string battleDate; //Field offset: 0x38
	public long endTimeMs; //Field offset: 0x40
	public long settleAtMs; //Field offset: 0x48
	public long serverTimeMs; //Field offset: 0x50
	public bool claimOpen; //Field offset: 0x58

	public BossRankingResponseDTO() { }

}

