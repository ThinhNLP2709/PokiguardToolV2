namespace UnityEngine.UIElements;

internal class TimerEventScheduler : IScheduler
{
	private readonly List<ScheduledItem> m_ScheduledItems; //Field offset: 0x10
	private bool m_TransactionMode; //Field offset: 0x18
	private readonly List<ScheduledItem> m_ScheduleTransactions; //Field offset: 0x20
	private readonly HashSet<ScheduledItem> m_UnscheduleTransactions; //Field offset: 0x28
	internal bool disableThrottling; //Field offset: 0x30
	private int m_LastUpdatedIndex; //Field offset: 0x34
	private long frameCount; //Field offset: 0x38

	public override long FrameCount
	{
		 get { } //Length: 7
		 set { } //Length: 5
	}

	public TimerEventScheduler() { }

	public override long get_FrameCount() { }

	private bool PrivateUnSchedule(ScheduledItem sItem) { }

	private bool RemovedScheduledItemAt(int index) { }

	public override void Schedule(ScheduledItem item) { }

	public void set_FrameCount(long value) { }

	public override void Unschedule(ScheduledItem item) { }

	public override void UpdateScheduledEvents() { }

}

