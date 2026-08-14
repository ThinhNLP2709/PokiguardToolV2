namespace Unity.VisualScripting;

[Extension]
public static class XGettable
{

	[Extension]
	public static object GetValue(IGettable gettable, Type type) { }

	[Extension]
	public static T GetValue(IGettable gettable) { }

}

