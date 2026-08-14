namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class VariableDeclarationCollection : KeyedCollection<String, VariableDeclaration>, IKeyedCollection<String, VariableDeclaration>, ICollection<VariableDeclaration>, IEnumerable<VariableDeclaration>, IEnumerable
{

	public VariableDeclarationCollection() { }

	public void EditorRename(VariableDeclaration item, string newName) { }

	protected virtual string GetKeyForItem(VariableDeclaration item) { }

	public override bool TryGetValue(string key, out VariableDeclaration value) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.VariableDeclaration>.Contains(string key) { }

	private override VariableDeclaration Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.VariableDeclaration>.get_Item(string key) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.VariableDeclaration>.Remove(string key) { }

}

