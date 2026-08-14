namespace Unity.VisualScripting;

public sealed class UnitPortCollection : KeyedCollection<String, TPort>, IUnitPortCollection<TPort>, IKeyedCollection<String, TPort>, ICollection<TPort>, IEnumerable<TPort>, IEnumerable
{
	[CompilerGenerated]
	private readonly IUnit <unit>k__BackingField; //Field offset: 0x0

	public IUnit unit
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public UnitPortCollection`1(IUnit unit) { }

	private void AfterAdd(TPort port) { }

	private void AfterRemove(TPort port) { }

	private void BeforeAdd(TPort port) { }

	private void BeforeRemove(TPort port) { }

	protected virtual void ClearItems() { }

	[CompilerGenerated]
	public IUnit get_unit() { }

	protected virtual string GetKeyForItem(TPort item) { }

	protected virtual void InsertItem(int index, TPort item) { }

	protected virtual void RemoveItem(int index) { }

	protected virtual void SetItem(int index, TPort item) { }

	public override TPort Single() { }

	public override bool TryGetValue(string key, out TPort value) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.String,TPort>.Contains(string key) { }

	private override TPort Unity.VisualScripting.IKeyedCollection<System.String,TPort>.get_Item(string key) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.String,TPort>.Remove(string key) { }

}

