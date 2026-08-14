namespace Unity.VisualScripting;

[Extension]
public static class ConversionUtility
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<MethodInfo, Boolean> <>9__11_0; //Field offset: 0x8
		public static Func<MethodInfo, Boolean> <>9__11_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <FindUserDefinedConversionMethods>b__11_0(MethodInfo m) { }

		internal bool <FindUserDefinedConversionMethods>b__11_1(MethodInfo m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Type source; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <FindUserDefinedConversionMethods>b__2(MethodInfo m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public Type destination; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <GetUserDefinedConversionType>b__0(MethodInfo m) { }

		internal bool <GetUserDefinedConversionType>b__1(MethodInfo m) { }

		internal bool <GetUserDefinedConversionType>b__2(MethodInfo m) { }

	}

	private struct ConversionQuery : IEquatable<ConversionQuery>
	{
		public readonly Type source; //Field offset: 0x0
		public readonly Type destination; //Field offset: 0x8

		public ConversionQuery(Type source, Type destination) { }

		public override bool Equals(ConversionQuery other) { }

		public virtual bool Equals(object obj) { }

		public virtual int GetHashCode() { }

	}

	private struct ConversionQueryComparer : IEqualityComparer<ConversionQuery>
	{

		public override bool Equals(ConversionQuery x, ConversionQuery y) { }

		public override int GetHashCode(ConversionQuery obj) { }

	}

	internal enum ConversionType
	{
		Impossible = 0,
		Identity = 1,
		Upcast = 2,
		Downcast = 3,
		NumericImplicit = 4,
		NumericExplicit = 5,
		UserDefinedImplicit = 6,
		UserDefinedExplicit = 7,
		UserDefinedThenNumericImplicit = 8,
		UserDefinedThenNumericExplicit = 9,
		UnityHierarchy = 10,
		EnumerableToArray = 11,
		EnumerableToList = 12,
		ToString = 13,
	}

	private const BindingFlags UserDefinedBindingFlags = 24; //Field offset: 0x0
	private static readonly Dictionary<ConversionQuery, ConversionType> conversionTypesCache; //Field offset: 0x0
	private static readonly Dictionary<ConversionQuery, MethodInfo[]> userConversionMethodsCache; //Field offset: 0x8
	private static readonly Dictionary<Type, HashSet`1<Type>> implicitNumericConversions; //Field offset: 0x10
	private static readonly Dictionary<Type, HashSet`1<Type>> explicitNumericConversions; //Field offset: 0x18

	private static ConversionUtility() { }

	public static bool CanConvert(Type source, Type destination, bool guaranteed) { }

	public static bool CanConvert(object value, Type type, bool guaranteed) { }

	private static object Convert(object value, Type type, ConversionType conversionType) { }

	public static object Convert(object value, Type type) { }

	public static T Convert(object value) { }

	[Extension]
	public static object ConvertTo(object source, Type type) { }

	[Extension]
	public static T ConvertTo(object source) { }

	private static ConversionType DetermineConversionType(ConversionQuery query) { }

	private static object EnumerableToArrayConversion(object value, Type arrayType) { }

	private static object EnumerableToListConversion(object value, Type listType) { }

	private static bool ExpectsString(Type source, Type destination) { }

	private static IEnumerable<MethodInfo> FindUserDefinedConversionMethods(ConversionQuery query) { }

	public static ConversionType GetRequiredConversion(object value, Type type) { }

	public static ConversionType GetRequiredConversion(Type source, Type destination) { }

	private static MethodInfo[] GetUserDefinedConversionMethods(Type source, Type destination) { }

	private static ConversionType GetUserDefinedConversionType(Type source, Type destination) { }

	private static bool HasEnumerableToArrayConversion(Type source, Type destination) { }

	private static bool HasEnumerableToListConversion(Type source, Type destination) { }

	public static bool HasExplicitNumericConversion(Type source, Type destination) { }

	public static bool HasImplicitNumericConversion(Type source, Type destination) { }

	public static bool HasNumericConversion(Type source, Type destination) { }

	private static bool HasUnityHierarchyConversion(Type source, Type destination) { }

	[Extension]
	public static bool IsConvertibleTo(Type source, Type destination, bool guaranteed) { }

	[Extension]
	public static bool IsConvertibleTo(object source, Type type, bool guaranteed) { }

	[Extension]
	public static bool IsConvertibleTo(object source, bool guaranteed) { }

	private static bool IsDowncast(Type source, Type destination) { }

	private static bool IsUpcast(Type source, Type destination) { }

	private static bool IsValidConversion(ConversionType conversionType, bool guaranteed) { }

	private static object NumericConversion(object value, Type type) { }

	private static bool RespectsIdentity(Type source, Type destination) { }

	public static bool TryConvert(object value, out T result, bool guaranteed) { }

	public static bool TryConvert(object value, Type type, out object result, bool guaranteed) { }

	private static object UnityHierarchyConversion(object value, Type type) { }

	private static object UserDefinedConversion(ConversionType conversion, object value, Type type) { }

}

