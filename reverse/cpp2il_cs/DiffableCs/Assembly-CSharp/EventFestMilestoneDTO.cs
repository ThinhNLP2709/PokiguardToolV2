//Type is in global namespace

public class EventFestMilestoneDTO
{
	public long id; //Field offset: 0x10
	public int milestoneOrder; //Field offset: 0x18
	public int requiredPoints; //Field offset: 0x1C
	public string rewardType; //Field offset: 0x20
	public long rewardId; //Field offset: 0x28
	public int rewardAmount; //Field offset: 0x30
	public bool claimed; //Field offset: 0x34

	public EventFestMilestoneDTO() { }

}

