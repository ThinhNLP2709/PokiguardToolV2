namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class VariantList : IList<TBase>, ICollection<TBase>, IEnumerable<TBase>, IEnumerable
{
	[CompilerGenerated]
	private IList<TImplementation> <implementation>k__BackingField; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 105
	}

	public private IList<TImplementation> implementation
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 108
	}

	public override TBase Item
	{
		 get { } //Length: 360
		 set { } //Length: 574
	}

	public VariantList`2(IList<TImplementation> implementation) { }

	public override void Add(TBase item) { }

	public override void Clear() { }

	public override bool Contains(TBase item) { }

	public override void CopyTo(TBase[] array, int arrayIndex) { }

	public override int get_Count() { }

	[CompilerGenerated]
	public IList<TImplementation> get_implementation() { }

	public override bool get_IsReadOnly() { }

	public override TBase get_Item(int index) { }

	public NoAllocEnumerator<TBase> GetEnumerator() { }

	public override int IndexOf(TBase item) { }

	public override void Insert(int index, TBase item) { }

	public override bool Remove(TBase item) { }

	public override void RemoveAt(int index) { }

	[CompilerGenerated]
	private void set_implementation(IList<TImplementation> value) { }

	public override void set_Item(int index, TBase value) { }

	private override IEnumerator<TBase> System.Collections.Generic.IEnumerable<TBase>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

