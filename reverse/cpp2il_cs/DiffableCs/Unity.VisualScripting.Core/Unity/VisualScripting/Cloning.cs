namespace Unity.VisualScripting;

[Extension]
public static class Cloning
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public Type type; //Field offset: 0x10

		public <>c__DisplayClass35_0() { }

		internal bool <GetCloner>b__0(ICloner cloner) { }

	}

	private static readonly Dictionary<Type, Boolean> skippable; //Field offset: 0x0
	[CompilerGenerated]
	private static readonly HashSet<ICloner> <cloners>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static readonly ArrayCloner <arrayCloner>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static readonly DictionaryCloner <dictionaryCloner>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private static readonly EnumerableCloner <enumerableCloner>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private static readonly ListCloner <listCloner>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private static readonly AnimationCurveCloner <animationCurveCloner>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private static readonly GradientCloner <gradientCloner>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private static readonly FieldsCloner <fieldsCloner>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private static readonly FakeSerializationCloner <fakeSerializationCloner>k__BackingField; //Field offset: 0x48

	public static AnimationCurveCloner animationCurveCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static ArrayCloner arrayCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static HashSet<ICloner> cloners
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static DictionaryCloner dictionaryCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static EnumerableCloner enumerableCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static FakeSerializationCloner fakeSerializationCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public static FieldsCloner fieldsCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	internal static GradientCloner gradientCloner
	{
		[CompilerGenerated]
		internal get { } //Length: 79
	}

	public static ListCloner listCloner
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	private static Cloning() { }

	internal static object Clone(CloningContext context, object original) { }

	[Extension]
	public static object Clone(object original, ICloner fallbackCloner, bool tryPreserveInstances) { }

	[Extension]
	public static T Clone(T original, ICloner fallbackCloner, bool tryPreserveInstances) { }

	internal static void CloneInto(CloningContext context, ref object clone, object original) { }

	[Extension]
	public static T CloneViaFakeSerialization(T original) { }

	[Extension]
	public static object CloneViaFakeSerialization(object original) { }

	[CompilerGenerated]
	public static AnimationCurveCloner get_animationCurveCloner() { }

	[CompilerGenerated]
	public static ArrayCloner get_arrayCloner() { }

	[CompilerGenerated]
	public static HashSet<ICloner> get_cloners() { }

	[CompilerGenerated]
	public static DictionaryCloner get_dictionaryCloner() { }

	[CompilerGenerated]
	public static EnumerableCloner get_enumerableCloner() { }

	[CompilerGenerated]
	public static FakeSerializationCloner get_fakeSerializationCloner() { }

	[CompilerGenerated]
	public static FieldsCloner get_fieldsCloner() { }

	[CompilerGenerated]
	internal static GradientCloner get_gradientCloner() { }

	[CompilerGenerated]
	public static ListCloner get_listCloner() { }

	[CanBeNull]
	public static ICloner GetCloner(object original, Type type) { }

	private static ICloner GetCloner(object original, Type type, ICloner fallbackCloner) { }

	private static bool Skippable(Type type) { }

}

