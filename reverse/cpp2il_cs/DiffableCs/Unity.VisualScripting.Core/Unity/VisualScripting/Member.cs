namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class Member : ISerializationCallbackReceiver
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ParameterInfo, Type> <>9__5_0; //Field offset: 0x8
		public static Func<ParameterInfo, Type> <>9__6_0; //Field offset: 0x10
		public static Func<ConstructorInfo, Boolean> <>9__122_0; //Field offset: 0x18
		public static Func<Type, String> <>9__122_1; //Field offset: 0x20
		public static Func<Type, String> <>9__123_0; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal Type <.ctor>b__5_0(ParameterInfo pi) { }

		internal Type <.ctor>b__6_0(ParameterInfo pi) { }

		internal bool <ReflectConstructor>b__122_0(ConstructorInfo c) { }

		internal string <ReflectConstructor>b__122_1(Type t) { }

		internal string <ReflectMethod>b__123_0(Type t) { }

	}

	internal enum Source
	{
		Unknown = 0,
		Field = 1,
		Property = 2,
		Method = 3,
		Constructor = 4,
	}

	private static readonly Object[] EmptyObjects; //Field offset: 0x0
	public const MemberTypes SupportedMemberTypes = 29; //Field offset: 0x0
	public const BindingFlags SupportedBindingFlags = 124; //Field offset: 0x0
	[SerializeAs("name")]
	private string _name; //Field offset: 0x10
	[SerializeAs("parameterTypes")]
	private Type[] _parameterTypes; //Field offset: 0x18
	[SerializeAs("targetType")]
	private Type _targetType; //Field offset: 0x20
	[SerializeAs("targetTypeName")]
	private string _targetTypeName; //Field offset: 0x28
	[DoNotSerialize]
	private Source _source; //Field offset: 0x30
	[DoNotSerialize]
	private FieldInfo _fieldInfo; //Field offset: 0x38
	[DoNotSerialize]
	private PropertyInfo _propertyInfo; //Field offset: 0x40
	[DoNotSerialize]
	private MethodInfo _methodInfo; //Field offset: 0x48
	[DoNotSerialize]
	private ConstructorInfo _constructorInfo; //Field offset: 0x50
	[DoNotSerialize]
	private bool _isExtension; //Field offset: 0x58
	[DoNotSerialize]
	private bool _isInvokedAsExtension; //Field offset: 0x59
	[DoNotSerialize]
	private IOptimizedAccessor fieldAccessor; //Field offset: 0x60
	[DoNotSerialize]
	private IOptimizedAccessor propertyAccessor; //Field offset: 0x68
	[DoNotSerialize]
	private IOptimizedInvoker methodInvoker; //Field offset: 0x70
	[CompilerGenerated]
	private bool <isReflected>k__BackingField; //Field offset: 0x78

	private MemberInfo _info
	{
		private get { } //Length: 178
	}

	public bool allowsNull
	{
		 get { } //Length: 272
	}

	[DoNotSerialize]
	public private ConstructorInfo constructorInfo
	{
		 get { } //Length: 42
		private set { } //Length: 13
	}

	public Type declaringType
	{
		 get { } //Length: 119
	}

	[DoNotSerialize]
	public private FieldInfo fieldInfo
	{
		 get { } //Length: 42
		private set { } //Length: 13
	}

	public MemberInfo info
	{
		 get { } //Length: 242
	}

	public bool isAccessor
	{
		 get { } //Length: 154
	}

	public bool isConstructor
	{
		 get { } //Length: 35
	}

	public bool isConversion
	{
		 get { } //Length: 123
	}

	public bool isCoroutine
	{
		 get { } //Length: 142
	}

	[DoNotSerialize]
	public private bool isExtension
	{
		 get { } //Length: 42
		private set { } //Length: 4
	}

	public bool isField
	{
		 get { } //Length: 35
	}

	public bool isGettable
	{
		 get { } //Length: 10
	}

	public bool isIndexer
	{
		 get { } //Length: 103
	}

	public bool isInherited
	{
		 get { } //Length: 69
	}

	public bool isInvocable
	{
		 get { } //Length: 154
	}

	[DoNotSerialize]
	public private bool isInvokedAsExtension
	{
		 get { } //Length: 42
		private set { } //Length: 4
	}

	public bool isMethod
	{
		 get { } //Length: 35
	}

	public bool isOperator
	{
		 get { } //Length: 123
	}

	public bool isPredictable
	{
		 get { } //Length: 135
	}

	public bool isProperty
	{
		 get { } //Length: 35
	}

	public bool isPseudoInherited
	{
		 get { } //Length: 226
	}

	public bool isPubliclyGettable
	{
		 get { } //Length: 10
	}

	public bool isPubliclyInvocable
	{
		 get { } //Length: 10
	}

	public bool isPubliclySettable
	{
		 get { } //Length: 10
	}

	[DoNotSerialize]
	public private bool isReflected
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public bool isSettable
	{
		 get { } //Length: 10
	}

	public bool isYieldInstruction
	{
		 get { } //Length: 164
	}

	public MethodBase methodBase
	{
		 get { } //Length: 95
	}

	[DoNotSerialize]
	public private MethodInfo methodInfo
	{
		 get { } //Length: 42
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public private string name
	{
		 get { } //Length: 5
		private set { } //Length: 65
	}

	public int order
	{
		 get { } //Length: 48
	}

	[DoNotSerialize]
	public private Type[] parameterTypes
	{
		 get { } //Length: 5
		private set { } //Length: 32
	}

	[DoNotSerialize]
	public private PropertyInfo propertyInfo
	{
		 get { } //Length: 42
		private set { } //Length: 13
	}

	public Type pseudoDeclaringType
	{
		 get { } //Length: 774
	}

	public bool requiresTarget
	{
		 get { } //Length: 397
	}

	[DoNotSerialize]
	public private Source source
	{
		 get { } //Length: 40
		private set { } //Length: 4
	}

	[DoNotSerialize]
	public private Type targetType
	{
		 get { } //Length: 5
		private set { } //Length: 224
	}

	[DoNotSerialize]
	public string targetTypeName
	{
		 get { } //Length: 5
	}

	public Type type
	{
		 get { } //Length: 356
	}

	private static Member() { }

	public Member(Type targetType, ConstructorInfo constructorInfo) { }

	public Member(Type targetType, MethodInfo methodInfo) { }

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public Member() { }

	public Member(Type targetType, FieldInfo fieldInfo) { }

	public Member(Type targetType, string name, Type[] parameterTypes = null) { }

	public Member(Type targetType, PropertyInfo propertyInfo) { }

	private void EnsureExplicitParameterTypes() { }

	private void EnsureInvocable(object target) { }

	public void EnsureReady(object target) { }

	public void EnsureReflected() { }

	public virtual bool Equals(object obj) { }

	public T Get(object target) { }

	public object Get(object target) { }

	private MemberInfo get__info() { }

	public bool get_allowsNull() { }

	public ConstructorInfo get_constructorInfo() { }

	public Type get_declaringType() { }

	public FieldInfo get_fieldInfo() { }

	public MemberInfo get_info() { }

	public bool get_isAccessor() { }

	public bool get_isConstructor() { }

	public bool get_isConversion() { }

	public bool get_isCoroutine() { }

	public bool get_isExtension() { }

	public bool get_isField() { }

	public bool get_isGettable() { }

	public bool get_isIndexer() { }

	public bool get_isInherited() { }

	public bool get_isInvocable() { }

	public bool get_isInvokedAsExtension() { }

	public bool get_isMethod() { }

	public bool get_isOperator() { }

	public bool get_isPredictable() { }

	public bool get_isProperty() { }

	public bool get_isPseudoInherited() { }

	public bool get_isPubliclyGettable() { }

	public bool get_isPubliclyInvocable() { }

	public bool get_isPubliclySettable() { }

	[CompilerGenerated]
	public bool get_isReflected() { }

	public bool get_isSettable() { }

	public bool get_isYieldInstruction() { }

	public MethodBase get_methodBase() { }

	public MethodInfo get_methodInfo() { }

	public string get_name() { }

	public int get_order() { }

	public Type[] get_parameterTypes() { }

	public PropertyInfo get_propertyInfo() { }

	public Type get_pseudoDeclaringType() { }

	public bool get_requiresTarget() { }

	public Source get_source() { }

	public Type get_targetType() { }

	public string get_targetTypeName() { }

	public Type get_type() { }

	public virtual int GetHashCode() { }

	public IEnumerable<ParameterInfo> GetParameterInfos() { }

	public object Invoke(object target, object arg0, object arg1) { }

	public object Invoke(object target, object arg0, object arg1, object arg2) { }

	public object Invoke(object target, object arg0, object arg1, object arg2, object arg3) { }

	public object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	public object Invoke(object target, Object[] arguments) { }

	public T Invoke(object target) { }

	public T Invoke(object target, object arg0) { }

	public T Invoke(object target, object arg0, object arg1) { }

	public T Invoke(object target, object arg0, object arg1, object arg2) { }

	public T Invoke(object target, object arg0, object arg1, object arg2, object arg3) { }

	public T Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	public T Invoke(object target, Object[] arguments) { }

	public object Invoke(object target, object arg0) { }

	public object Invoke(object target) { }

	public bool IsGettable(bool nonPublic) { }

	public bool IsInvocable(bool nonPublic) { }

	public bool IsSettable(bool nonPublic) { }

	public static bool op_Equality(Member a, Member b) { }

	public static bool op_Inequality(Member a, Member b) { }

	public void Prewarm() { }

	public void Reflect() { }

	private void ReflectConstructor(IEnumerable<MemberInfo> candidates) { }

	private void ReflectField(IEnumerable<MemberInfo> candidates) { }

	private void ReflectMethod(IEnumerable<MemberInfo> candidates) { }

	private void ReflectProperty(IEnumerable<MemberInfo> candidates) { }

	public object Set(object target, object value) { }

	private void set_constructorInfo(ConstructorInfo value) { }

	private void set_fieldInfo(FieldInfo value) { }

	private void set_isExtension(bool value) { }

	private void set_isInvokedAsExtension(bool value) { }

	[CompilerGenerated]
	private void set_isReflected(bool value) { }

	private void set_methodInfo(MethodInfo value) { }

	private void set_name(string value) { }

	private void set_parameterTypes(Type[] value) { }

	private void set_propertyInfo(PropertyInfo value) { }

	private void set_source(Source value) { }

	private void set_targetType(Type value) { }

	public Member ToDeclarer() { }

	public Member ToPseudoDeclarer() { }

	public virtual string ToString() { }

	public string ToUniqueString() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

