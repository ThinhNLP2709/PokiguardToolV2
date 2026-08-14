namespace Unity.VisualScripting.FullSerializer;

public class fsSerializer
{
	public class fsLazyCycleDefinitionWriter
	{
		private Dictionary<Int32, fsData> _pendingDefinitions; //Field offset: 0x10
		private HashSet<Int32> _references; //Field offset: 0x18

		public fsLazyCycleDefinitionWriter() { }

		public void Clear() { }

		public void WriteDefinition(int id, fsData data) { }

		public void WriteReference(int id, Dictionary<String, fsData> dict) { }

	}

	private static HashSet<String> _reservedKeywords; //Field offset: 0x0
	private static readonly string Key_ObjectReference; //Field offset: 0x8
	private static readonly string Key_ObjectDefinition; //Field offset: 0x10
	private static readonly string Key_InstanceType; //Field offset: 0x18
	private static readonly string Key_Version; //Field offset: 0x20
	private static readonly string Key_Content; //Field offset: 0x28
	internal static readonly string Key_UnitDefault; //Field offset: 0x30
	internal static readonly string Key_UnitPosition; //Field offset: 0x38
	internal static readonly string Key_UnitGuid; //Field offset: 0x40
	internal static readonly string Key_UnitFormerType; //Field offset: 0x48
	internal static readonly string Key_UnitFormerValue; //Field offset: 0x50
	internal static readonly string TypeName_Unit; //Field offset: 0x58
	private static readonly Type Type_Unit; //Field offset: 0x60
	internal static readonly string TypeName_MissingType; //Field offset: 0x68
	private static readonly Type Type_MissingType; //Field offset: 0x70
	private readonly List<fsConverter> _availableConverters; //Field offset: 0x10
	private readonly Dictionary<Type, fsDirectConverter> _availableDirectConverters; //Field offset: 0x18
	private readonly List<fsObjectProcessor> _processors; //Field offset: 0x20
	private readonly fsCyclicReferenceManager _references; //Field offset: 0x28
	private readonly fsLazyCycleDefinitionWriter _lazyReferenceWriter; //Field offset: 0x30
	private readonly Dictionary<Type, Type> _abstractTypeRemap; //Field offset: 0x38
	private Dictionary<Type, fsBaseConverter> _cachedConverterTypeInstances; //Field offset: 0x40
	private Dictionary<Type, fsBaseConverter> _cachedConverters; //Field offset: 0x48
	private Dictionary<Type, List`1<fsObjectProcessor>> _cachedProcessors; //Field offset: 0x50
	public fsContext Context; //Field offset: 0x58
	public fsConfig Config; //Field offset: 0x60

	private static fsSerializer() { }

	public fsSerializer() { }

	public void AddConverter(fsBaseConverter converter) { }

	public void AddProcessor(fsObjectProcessor processor) { }

	private static void ConvertLegacyData(ref fsData data) { }

	private static void EnsureDictionary(fsData data) { }

	private fsBaseConverter GetConverter(Type type, Type overrideConverterType) { }

	private static Type GetDataType(ref fsData data, Type defaultType, ref fsResult deserializeResult) { }

	private List<fsObjectProcessor> GetProcessors(Type type) { }

	private fsResult InternalDeserialize_1_CycleReference(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor>& processors) { }

	private fsResult InternalDeserialize_2_Version(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor>& processors) { }

	private fsResult InternalDeserialize_3_Inheritance(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor>& processors) { }

	private fsResult InternalDeserialize_4_Cycles(Type overrideConverterType, fsData data, Type resultType, ref object result) { }

	private fsResult InternalDeserialize_5_Converter(Type overrideConverterType, fsData data, Type resultType, ref object result) { }

	private fsResult InternalSerialize_1_ProcessCycles(Type storageType, Type overrideConverterType, object instance, out fsData data) { }

	private fsResult InternalSerialize_2_Inheritance(Type storageType, Type overrideConverterType, object instance, out fsData data) { }

	private fsResult InternalSerialize_3_ProcessVersioning(Type overrideConverterType, object instance, out fsData data) { }

	private fsResult InternalSerialize_4_Converter(Type overrideConverterType, object instance, out fsData data) { }

	private static void Invoke_OnAfterDeserialize(List<fsObjectProcessor> processors, Type storageType, object instance) { }

	private static void Invoke_OnAfterSerialize(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data) { }

	private static void Invoke_OnBeforeDeserialize(List<fsObjectProcessor> processors, Type storageType, ref fsData data) { }

	private static void Invoke_OnBeforeDeserializeAfterInstanceCreation(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data) { }

	private static void Invoke_OnBeforeSerialize(List<fsObjectProcessor> processors, Type storageType, object instance) { }

	private static bool IsObjectDefinition(fsData data) { }

	private static bool IsObjectReference(fsData data) { }

	public static bool IsReservedKeyword(string key) { }

	private static bool IsTypeSpecified(fsData data) { }

	private static bool IsVersioned(fsData data) { }

	private static bool IsVisualScriptingUnit(fsData data) { }

	private static bool IsWrappedData(fsData data) { }

	private void RemapAbstractStorageTypeToDefaultType(ref Type storageType) { }

	public void RemoveProcessor() { }

	public void SetDefaultStorageType(Type abstractType, Type defaultStorageType) { }

	public static void StripDeserializationMetadata(ref fsData data) { }

	public fsResult TryDeserialize(fsData data, ref T instance) { }

	public fsResult TryDeserialize(fsData data, Type storageType, Type overrideConverterType, ref object result) { }

	public fsResult TryDeserialize(fsData data, Type storageType, ref object result) { }

	public fsResult TrySerialize(T instance, out fsData data) { }

	public fsResult TrySerialize(Type storageType, object instance, out fsData data) { }

	public fsResult TrySerialize(Type storageType, Type overrideConverterType, object instance, out fsData data) { }

}

