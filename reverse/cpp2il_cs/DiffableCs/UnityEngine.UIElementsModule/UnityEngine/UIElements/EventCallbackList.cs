namespace UnityEngine.UIElements;

[DefaultMember("Item")]
internal class EventCallbackList
{
	public static readonly EventCallbackList EmptyList; //Field offset: 0x0
	private static readonly EventCallbackFunctorBase[] EmptyArray; //Field offset: 0x8
	private EventCallbackFunctorBase[] m_Array; //Field offset: 0x10
	private int m_Count; //Field offset: 0x18

	public Span<EventCallbackFunctorBase> Span
	{
		 get { } //Length: 259
	}

	private static EventCallbackList() { }

	public EventCallbackList() { }

	public EventCallbackList(EventCallbackList source) { }

	public void Add(EventCallbackFunctorBase item) { }

	public void AddRange(EventCallbackList list) { }

	public void Clear() { }

	public EventCallbackFunctorBase Find(long eventTypeId, Delegate callback) { }

	public Span<EventCallbackFunctorBase> get_Span() { }

	public bool Remove(long eventTypeId, Delegate callback, out EventCallbackFunctorBase removedFunctor) { }

}

