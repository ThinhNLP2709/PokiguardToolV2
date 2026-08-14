//Type is in global namespace

public class QuestData
{
	public long questId; //Field offset: 0x10
	public string questName; //Field offset: 0x18
	public string questDescription; //Field offset: 0x20
	public string questType; //Field offset: 0x28
	public int targetValue; //Field offset: 0x30
	public int currentProgress; //Field offset: 0x34
	public bool completed; //Field offset: 0x38
	public bool claimed; //Field offset: 0x39
	public List<QuestRewardData> rewards; //Field offset: 0x40

	public QuestData() { }

}

