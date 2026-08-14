namespace System.Collections.Specialized;

[DefaultMember("Item")]
public class StringDictionary : IEnumerable
{
	internal Hashtable contents; //Field offset: 0x10

	public StringDictionary() { }

	public override void Add(string key, string value) { }

	public override IEnumerator GetEnumerator() { }

}

