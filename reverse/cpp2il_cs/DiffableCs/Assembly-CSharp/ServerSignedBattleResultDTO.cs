//Type is in global namespace

public class ServerSignedBattleResultDTO
{
	public long userId; //Field offset: 0x10
	public long bossScheduleId; //Field offset: 0x18
	public int damageDealt; //Field offset: 0x20
	public bool victory; //Field offset: 0x24
	public int turnCount; //Field offset: 0x28
	public string signature; //Field offset: 0x30
	public long serverTimestamp; //Field offset: 0x38
	public string sessionToken; //Field offset: 0x40
	public string deviceId; //Field offset: 0x48
	public string nonce; //Field offset: 0x50
	public string gameVersion; //Field offset: 0x58
	public string checksum; //Field offset: 0x60

	public ServerSignedBattleResultDTO() { }

	public static ServerSignedBattleResultDTO CreateFromServerResponse(long userId, long bossScheduleId, int damageDealt, bool victory, int turnCount, SignatureResponse serverResponse, string originalDeviceId, string originalNonce) { }

}

