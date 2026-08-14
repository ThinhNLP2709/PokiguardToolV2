//Type is in global namespace

public class DailyCheckInData
{
	public long id; //Field offset: 0x10
	public int dayOfMonth; //Field offset: 0x18
	public string checkInDate; //Field offset: 0x20
	public string rewardType; //Field offset: 0x28
	public int rewardAmount; //Field offset: 0x30
	public bool claimed; //Field offset: 0x34
	public bool canClaim; //Field offset: 0x35
	public string rewardIcon; //Field offset: 0x38

	public DailyCheckInData() { }

}

