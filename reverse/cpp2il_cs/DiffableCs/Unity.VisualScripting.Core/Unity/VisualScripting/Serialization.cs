namespace Unity.VisualScripting;

[Extension]
public static class Serialization
{
	public const string ConstructorWarning = "This parameterless constructor is only made public for serialization. Use another constructor instead."; //Field offset: 0x0
	private static readonly HashSet<SerializationOperation> freeOperations; //Field offset: 0x0
	private static readonly HashSet<SerializationOperation> busyOperations; //Field offset: 0x8
	private static readonly object lock; //Field offset: 0x10
	[CompilerGenerated]
	private static bool <isUnitySerializing>k__BackingField; //Field offset: 0x18
	private static readonly HashSet<ISerializationDepender> awaitingDependers; //Field offset: 0x20

	public static bool isCustomSerializing
	{
		 get { } //Length: 108
	}

	public static bool isSerializing
	{
		 get { } //Length: 161
	}

	public static bool isUnitySerializing
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 84
	}

	private static Serialization() { }

	public static void AwaitDependencies(ISerializationDepender depender) { }

	private static void CheckIfDependenciesMet(ISerializationDepender depender) { }

	[Extension]
	public static T CloneViaSerialization(T value, bool forceReflected = false) { }

	[Extension]
	public static void CloneViaSerializationInto(TSource value, ref TDestination instance, bool forceReflected = false) { }

	[Extension]
	public static object Deserialize(SerializationData data, bool forceReflected = false) { }

	[Extension]
	public static void DeserializeInto(SerializationData data, ref object instance, bool forceReflected = false) { }

	private static void DeserializeJson(fsSerializer serializer, string json, ref object instance, bool forceReflected) { }

	private static fsResult DeserializeJsonUtil(fsSerializer serializer, string json, ref object instance, bool forceReflected) { }

	private static void EndOperation(SerializationOperation operation) { }

	public static bool get_isCustomSerializing() { }

	public static bool get_isSerializing() { }

	[CompilerGenerated]
	public static bool get_isUnitySerializing() { }

	private static void HandleResult(string label, fsResult result, object context = null) { }

	public static void LogStuckDependers() { }

	public static void NotifyDependencyAvailable(ISerializationDependency dependency) { }

	public static void NotifyDependencyDeserialized(ISerializationDependency dependency) { }

	public static void NotifyDependencyDeserializing(ISerializationDependency dependency) { }

	public static void NotifyDependencyUnavailable(ISerializationDependency dependency) { }

	public static string PrettyPrint(string json) { }

	[Extension]
	public static SerializationData Serialize(object value, bool forceReflected = false) { }

	private static string SerializeJson(fsSerializer serializer, object instance, bool forceReflected) { }

	[CompilerGenerated]
	public static void set_isUnitySerializing(bool value) { }

	private static SerializationOperation StartOperation() { }

}

