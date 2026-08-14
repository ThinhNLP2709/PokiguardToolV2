//Type is in global namespace

public class MilestoneStatusData
{
	public long milestoneId; //Field offset: 0x10
	public long milestoneAmount; //Field offset: 0x18
	public int milestoneOrder; //Field offset: 0x20
	public bool canClaim; //Field offset: 0x24
	public bool claimed; //Field offset: 0x25
	public MilestoneRewardData rewards; //Field offset: 0x28

	public MilestoneStatusData() { }

}

