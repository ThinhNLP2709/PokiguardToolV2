namespace Unity.Properties;

public interface IDictionaryPropertyBagVisitor
{

	public void Visit(IDictionaryPropertyBag<TDictionary, TKey, TValue> properties, ref TDictionary container) { }

}

