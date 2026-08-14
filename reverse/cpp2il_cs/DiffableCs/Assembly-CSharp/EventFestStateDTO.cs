//Type is in global namespace

public class EventFestStateDTO
{
	public bool eventActive; //Field offset: 0x10
	public string eventName; //Field offset: 0x18
	public string eventDescription; //Field offset: 0x20
	public int daysLeft; //Field offset: 0x28
	public int totalPoints; //Field offset: 0x2C
	public int dailyPoints; //Field offset: 0x30
	public int dailyMax; //Field offset: 0x34
	public int dailyPveCount; //Field offset: 0x38
	public int pveLimit; //Field offset: 0x3C
	public int ptsPveWin; //Field offset: 0x40
	public int dailyPvpCount; //Field offset: 0x44
	public int pvpLimit; //Field offset: 0x48
	public int ptsPvpWin; //Field offset: 0x4C
	public int dailyBossCount; //Field offset: 0x50
	public int bossLimit; //Field offset: 0x54
	public int ptsBoss; //Field offset: 0x58
	public bool dailyLoginTaken; //Field offset: 0x5C
	public int ptsLogin; //Field offset: 0x60
	public int dailyRechargeCount; //Field offset: 0x64
	public int rechargeLimit; //Field offset: 0x68
	public int ptsRecharge; //Field offset: 0x6C
	public List<EventFestMilestoneDTO> milestones; //Field offset: 0x70
	public int pointsAdded; //Field offset: 0x78
	public string actionMessage; //Field offset: 0x80
	public string lastRewardType; //Field offset: 0x88
	public long lastRewardId; //Field offset: 0x90
	public int lastRewardAmount; //Field offset: 0x98
	public int flipsLeft; //Field offset: 0x9C
	public int flipUnlockPoints; //Field offset: 0xA0

	public EventFestStateDTO() { }

}

