namespace Unity.VisualScripting.FullSerializer;

public class fsMetaType
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public MemberInfo member; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal bool <CollectProperties>b__0(Type t) { }

		internal bool <CollectProperties>b__1(Type t) { }

		internal bool <CollectProperties>b__2(Type t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public PropertyInfo property; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <CanSerializeProperty>b__0(Type t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public FieldInfo field; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <CanSerializeField>b__0(Type t) { }

	}

	private static Dictionary<fsConfig, Dictionary`2<Type, fsMetaType>> _configMetaTypes; //Field offset: 0x0
	public Type ReflectedType; //Field offset: 0x10
	private bool _hasEmittedAotData; //Field offset: 0x18
	private Nullable<Boolean> _hasDefaultConstructorCache; //Field offset: 0x19
	private bool _isDefaultConstructorPublic; //Field offset: 0x1B
	[CompilerGenerated]
	private fsMetaProperty[] <Properties>k__BackingField; //Field offset: 0x20

	public bool HasDefaultConstructor
	{
		 get { } //Length: 440
	}

	public private fsMetaProperty[] Properties
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private static fsMetaType() { }

	private fsMetaType(fsConfig config, Type reflectedType) { }

	private static bool CanSerializeField(fsConfig config, FieldInfo field, bool annotationFreeValue) { }

	private static bool CanSerializeProperty(fsConfig config, PropertyInfo property, MemberInfo[] members, bool annotationFreeValue) { }

	public static void ClearCache() { }

	private static void CollectProperties(fsConfig config, List<fsMetaProperty> properties, Type reflectedType) { }

	public object CreateInstance() { }

	public bool EmitAotData() { }

	public static fsMetaType Get(fsConfig config, Type type) { }

	public bool get_HasDefaultConstructor() { }

	[CompilerGenerated]
	public fsMetaProperty[] get_Properties() { }

	private static bool IsAutoProperty(PropertyInfo property, MemberInfo[] members) { }

	[CompilerGenerated]
	private void set_Properties(fsMetaProperty[] value) { }

}

