//Type is in global namespace

public class MonthlyMilestoneData
{
	public long totalRechargeAllTime; //Field offset: 0x10
	public long totalRechargeThisMonth; //Field offset: 0x18
	public int currentYear; //Field offset: 0x20
	public int currentMonth; //Field offset: 0x24
	public List<MilestoneStatusData> milestones; //Field offset: 0x28

	public MonthlyMilestoneData() { }

}

