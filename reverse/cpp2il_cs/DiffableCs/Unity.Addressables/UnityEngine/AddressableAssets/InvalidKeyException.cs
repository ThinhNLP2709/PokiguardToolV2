namespace UnityEngine.AddressableAssets;

public class InvalidKeyException : Exception
{
	public enum Format
	{
		StandardMessage = 0,
		NoMergeMode = 1,
		MultipleTypesRequested = 2,
		NoLocation = 3,
		TypeMismatch = 4,
		MultipleTypeMismatch = 5,
		MergeModeBase = 6,
		UnionAvailableForKeys = 7,
		UnionAvailableForKeysWithoutOther = 8,
		IntersectionAvailable = 9,
		KeyAvailableAsType = 10,
	}

	internal const string BaseInvalidKeyMessageFormat = "{0}, Key={1}, Type={2}"; //Field offset: 0x0
	internal const string NoLocationMessageFormat = "{0} No Location found for Key={1}"; //Field offset: 0x0
	internal const string MultipleTypeMismatchMessageFormat = "{0} No Asset found for Key={1} with Type={2}. Key exists as multiple Types={3}, which is not assignable from the requested Type={2}"; //Field offset: 0x0
	internal const string TypeMismatchMessageFormat = "{0} No Asset found for Key={1} with Type={2}. Key exists as Type={3}, which is not assignable from the requested Type={2}"; //Field offset: 0x0
	internal const string MultipleTypesMessageFormat = "{0} Enumerable key contains multiple Types. {1}, all Keys are expected to be strings"; //Field offset: 0x0
	internal const string MergeModeNoLocationMessageFormat = "
No Location found for Key={0}"; //Field offset: 0x0
	internal const string NoMergeModeMessageFormat = "{0} No MergeMode is set to merge the multiple keys requested. {1}, Type={2}"; //Field offset: 0x0
	internal const string MergeModeBaseMessageFormat = "{0} No {1} of Assets between {2} with Type={3}"; //Field offset: 0x0
	internal const string UnionAvailableForKeysMessageFormat = "
Union of Type={0} found with {1}"; //Field offset: 0x0
	internal const string UnionAvailableForKeysWithoutOtherMessageFormat = "
Union of Type={0} found with {1}. Without {2}"; //Field offset: 0x0
	internal const string IntersectionAvailableMessageFormat = "
An Intersection exists for Type={0}"; //Field offset: 0x0
	internal const string KeyAvailableAsTypeMessageFormat = "
Type={0} exists for {1}"; //Field offset: 0x0
	[CompilerGenerated]
	private object <Key>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private Type <Type>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private readonly Nullable<MergeMode> <MergeMode>k__BackingField; //Field offset: 0xA0
	private AddressablesImpl m_Addressables; //Field offset: 0xA8

	public private object Key
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Nullable<MergeMode> MergeMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public virtual string Message
	{
		 get { } //Length: 1284
	}

	public private Type Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public InvalidKeyException(string message, Exception innerException) { }

	public InvalidKeyException(object key) { }

	public InvalidKeyException(object key, Type type) { }

	internal InvalidKeyException(object key, Type type, AddressablesImpl addr) { }

	public InvalidKeyException(object key, Type type, MergeMode mergeMode) { }

	internal InvalidKeyException(object key, Type type, MergeMode mergeMode, AddressablesImpl addr) { }

	public InvalidKeyException() { }

	public InvalidKeyException(string message) { }

	protected InvalidKeyException(SerializationInfo message, StreamingContext context) { }

	internal string FormatMergeModeMessage(Format format, string keysAvailable = null, string keysUnavailable = null, string typeString = null) { }

	internal string FormatMessage(Format format, string foundWithTypeString = null) { }

	private string FormatMultipleAssignableTypesMessage(string keyString, HashSet<Type> typesAvailableForKey) { }

	private string FormatNotFoundMessage(string keyString) { }

	private string FormatTypeNotAssignableMessage(string keyString, HashSet<Type> typesAvailableForKey) { }

	[CompilerGenerated]
	public object get_Key() { }

	[CompilerGenerated]
	public Nullable<MergeMode> get_MergeMode() { }

	public virtual string get_Message() { }

	[CompilerGenerated]
	public Type get_Type() { }

	internal static string GetCSVString(IEnumerable enumerator, string prefixSingle, string prefixPlural) { }

	internal string GetKeyString() { }

	private string GetMessageforMergeKeys(List<String> keys) { }

	private string GetMessageForSingleKey(string keyString) { }

	private HashSet<Type> GetTypesForKey(string keyString) { }

	private bool GetTypeToKeys(string key, Dictionary<Type, List`1<String>> typeToKeys) { }

	[CompilerGenerated]
	private void set_Key(object value) { }

	[CompilerGenerated]
	private void set_Type(Type value) { }

}

