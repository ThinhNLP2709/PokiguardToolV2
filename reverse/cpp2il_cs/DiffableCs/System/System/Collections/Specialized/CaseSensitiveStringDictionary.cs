namespace System.Collections.Specialized;

[DefaultMember("Item")]
internal class CaseSensitiveStringDictionary : StringDictionary
{

	public CaseSensitiveStringDictionary() { }

	public virtual void Add(string key, string value) { }

}

