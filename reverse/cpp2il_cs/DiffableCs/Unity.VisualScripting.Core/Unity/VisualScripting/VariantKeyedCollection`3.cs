namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class VariantKeyedCollection : VariantCollection<TBase, TImplementation>, IKeyedCollection<TKey, TBase>, ICollection<TBase>, IEnumerable<TBase>, IEnumerable
{
	[CompilerGenerated]
	private IKeyedCollection<TKey, TImplementation> <implementation>k__BackingField; //Field offset: 0x0

	public private IKeyedCollection<TKey, TImplementation> implementation
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public override TBase Item
	{
		 get { } //Length: 306
	}

	private override TBase Unity.VisualScripting.IKeyedCollection<TKey,TBase>.Item
	{
		private get { } //Length: 298
	}

	public VariantKeyedCollection`3(IKeyedCollection<TKey, TImplementation> implementation) { }

	public override bool Contains(TKey key) { }

	[CompilerGenerated]
	public IKeyedCollection<TKey, TImplementation> get_implementation() { }

	public override TBase get_Item(TKey key) { }

	public override bool Remove(TKey key) { }

	[CompilerGenerated]
	private void set_implementation(IKeyedCollection<TKey, TImplementation> value) { }

	public override bool TryGetValue(TKey key, out TBase value) { }

	private override TBase Unity.VisualScripting.IKeyedCollection<TKey,TBase>.get_Item(int index) { }

}

