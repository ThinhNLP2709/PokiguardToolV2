namespace UnityEngine.InputSystem.Layouts;

[DefaultMember("Item")]
public class InputControlLayout
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, InternedString> <>9__52_0; //Field offset: 0x8
		public static Func<String, InternedString> <>9__75_0; //Field offset: 0x10
		public static Func<String, InternedString> <>9__75_1; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal InternedString <CreateControlItemFromMember>b__75_0(string x) { }

		internal InternedString <CreateControlItemFromMember>b__75_1(string x) { }

		internal InternedString <FromType>b__52_0(string x) { }

	}

	internal class Builder
	{
		internal struct ControlBuilder
		{
			[CompilerGenerated]
			private sealed class <>c
			{
				public static readonly <>c <>9; //Field offset: 0x0
				public static Func<String, InternedString> <>9__14_0; //Field offset: 0x8

				private static <>c() { }

				public <>c() { }

				internal InternedString <WithUsages>b__14_0(string x) { }

			}

			internal Builder builder; //Field offset: 0x0
			internal int index; //Field offset: 0x8

			public ControlBuilder AsArrayOfControlsWithSize(int arraySize) { }

			public ControlBuilder DontReset(bool value) { }

			public ControlBuilder IsNoisy(bool value) { }

			public ControlBuilder IsSynthetic(bool value) { }

			public ControlBuilder UsingStateFrom(string path) { }

			public ControlBuilder WithBitOffset(uint bit) { }

			public ControlBuilder WithByteOffset(uint offset) { }

			public ControlBuilder WithDefaultState(PrimitiveValue value) { }

			public ControlBuilder WithDisplayName(string displayName) { }

			public ControlBuilder WithFormat(FourCC format) { }

			public ControlBuilder WithFormat(string format) { }

			public ControlBuilder WithLayout(string layout) { }

			public ControlBuilder WithParameters(string parameters) { }

			public ControlBuilder WithProcessors(string processors) { }

			public ControlBuilder WithRange(float minValue, float maxValue) { }

			public ControlBuilder WithSizeInBits(uint sizeInBits) { }

			public ControlBuilder WithUsages(InternedString[] usages) { }

			public ControlBuilder WithUsages(IEnumerable<String> usages) { }

			public ControlBuilder WithUsages(String[] usages) { }

		}

		[CompilerGenerated]
		private string <name>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private string <displayName>k__BackingField; //Field offset: 0x18
		[CompilerGenerated]
		private Type <type>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private FourCC <stateFormat>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		private int <stateSizeInBytes>k__BackingField; //Field offset: 0x2C
		private string m_ExtendsLayout; //Field offset: 0x30
		[CompilerGenerated]
		private Nullable<Boolean> <updateBeforeRender>k__BackingField; //Field offset: 0x38
		private int m_ControlCount; //Field offset: 0x3C
		private ControlItem[] m_Controls; //Field offset: 0x40

		public ReadOnlyArray<ControlItem> controls
		{
			 get { } //Length: 95
		}

		public string displayName
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public string extendsLayout
		{
			 get { } //Length: 5
			 set { } //Length: 57
		}

		public string name
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public FourCC stateFormat
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public int stateSizeInBytes
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public Type type
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Nullable<Boolean> updateBeforeRender
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 5
		}

		public Builder() { }

		public ControlBuilder AddControl(string name) { }

		public InputControlLayout Build() { }

		public Builder Extend(string baseLayoutName) { }

		public ReadOnlyArray<ControlItem> get_controls() { }

		[CompilerGenerated]
		public string get_displayName() { }

		public string get_extendsLayout() { }

		[CompilerGenerated]
		public string get_name() { }

		[CompilerGenerated]
		public FourCC get_stateFormat() { }

		[CompilerGenerated]
		public int get_stateSizeInBytes() { }

		[CompilerGenerated]
		public Type get_type() { }

		[CompilerGenerated]
		public Nullable<Boolean> get_updateBeforeRender() { }

		[CompilerGenerated]
		public void set_displayName(string value) { }

		public void set_extendsLayout(string value) { }

		[CompilerGenerated]
		public void set_name(string value) { }

		[CompilerGenerated]
		public void set_stateFormat(FourCC value) { }

		[CompilerGenerated]
		public void set_stateSizeInBytes(int value) { }

		[CompilerGenerated]
		public void set_type(Type value) { }

		[CompilerGenerated]
		public void set_updateBeforeRender(Nullable<Boolean> value) { }

		public Builder WithDisplayName(string displayName) { }

		public Builder WithFormat(FourCC format) { }

		public Builder WithFormat(string format) { }

		public Builder WithName(string name) { }

		public Builder WithSizeInBytes(int sizeInBytes) { }

		public Builder WithType() { }

	}

	public struct Cache
	{
		public Dictionary<InternedString, InputControlLayout> table; //Field offset: 0x0

		public void Clear() { }

		public InputControlLayout FindOrLoadLayout(string name, bool throwIfNotFound = true) { }

	}

	public struct CacheRefInstance : IDisposable
	{
		public bool valid; //Field offset: 0x0

		public override void Dispose() { }

	}

	public struct Collection
	{
		[CompilerGenerated]
		private sealed class <GetBaseLayouts>d__24 : IEnumerable<InternedString>, IEnumerable, IEnumerator<InternedString>, IEnumerator, IDisposable
		{
			private int <>1__state; //Field offset: 0x10
			private InternedString <>2__current; //Field offset: 0x18
			private int <>l__initialThreadId; //Field offset: 0x28
			private bool includeSelf; //Field offset: 0x2C
			public bool <>3__includeSelf; //Field offset: 0x2D
			private InternedString layout; //Field offset: 0x30
			public InternedString <>3__layout; //Field offset: 0x40
			public Collection <>4__this; //Field offset: 0x50
			public Collection <>3__<>4__this; //Field offset: 0x90

			private override InternedString System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.Utilities.InternedString>.Current
			{
				[DebuggerHidden]
				private get { } //Length: 11
			}

			private override object System.Collections.IEnumerator.Current
			{
				[DebuggerHidden]
				private get { } //Length: 69
			}

			[DebuggerHidden]
			public <GetBaseLayouts>d__24(int <>1__state) { }

			private override bool MoveNext() { }

			[DebuggerHidden]
			private override IEnumerator<InternedString> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.Utilities.InternedString>.GetEnumerator() { }

			[DebuggerHidden]
			private override InternedString System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.Utilities.InternedString>.get_Current() { }

			[DebuggerHidden]
			private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

			[DebuggerHidden]
			private override object System.Collections.IEnumerator.get_Current() { }

			[DebuggerHidden]
			private override void System.Collections.IEnumerator.Reset() { }

			[DebuggerHidden]
			private override void System.IDisposable.Dispose() { }

		}

		internal struct LayoutMatcher
		{
			public InternedString layoutName; //Field offset: 0x0
			public InputDeviceMatcher deviceMatcher; //Field offset: 0x10

		}

		internal struct PrecompiledLayout
		{
			public Func<InputDevice> factoryMethod; //Field offset: 0x0
			public string metadata; //Field offset: 0x8

		}

		public const float kBaseScoreForNonGeneratedLayouts = 1; //Field offset: 0x0
		public Dictionary<InternedString, Type> layoutTypes; //Field offset: 0x0
		public Dictionary<InternedString, String> layoutStrings; //Field offset: 0x8
		public Dictionary<InternedString, Func`1<InputControlLayout>> layoutBuilders; //Field offset: 0x10
		public Dictionary<InternedString, InternedString> baseLayoutTable; //Field offset: 0x18
		public Dictionary<InternedString, InternedString[]> layoutOverrides; //Field offset: 0x20
		public HashSet<InternedString> layoutOverrideNames; //Field offset: 0x28
		public Dictionary<InternedString, PrecompiledLayout> precompiledLayouts; //Field offset: 0x30
		public List<LayoutMatcher> layoutMatchers; //Field offset: 0x38

		public void AddMatcher(InternedString layout, InputDeviceMatcher matcher) { }

		public void Allocate() { }

		public bool ComputeDistanceInInheritanceHierarchy(InternedString firstLayout, InternedString secondLayout, out int distance) { }

		public InternedString FindLayoutThatIntroducesControl(InputControl control, Cache cache) { }

		public InternedString GetBaseLayoutName(InternedString layoutName) { }

		[IteratorStateMachine(typeof(<GetBaseLayouts>d__24))]
		public IEnumerable<InternedString> GetBaseLayouts(InternedString layout, bool includeSelf = true) { }

		public Type GetControlTypeForLayout(InternedString layoutName) { }

		public InternedString GetRootLayoutName(InternedString layoutName) { }

		public bool HasLayout(InternedString name) { }

		public bool IsBasedOn(InternedString parentLayout, InternedString childLayout) { }

		public bool IsGeneratedLayout(InternedString layout) { }

		public InternedString TryFindLayoutForType(Type layoutType) { }

		public InternedString TryFindMatchingLayout(InputDeviceDescription deviceDescription) { }

		public InputControlLayout TryLoadLayout(InternedString name, Dictionary<InternedString, InputControlLayout> table = null) { }

		private InputControlLayout TryLoadLayoutInternal(InternedString name) { }

		public bool ValueTypeIsAssignableFrom(InternedString layoutName, Type valueType) { }

	}

	internal struct ControlItem
	{
		[Flags]
		private enum Flags
		{
			isModifyingExistingControl = 1,
			IsNoisy = 2,
			IsSynthetic = 4,
			IsFirstDefinedInThisLayout = 8,
			DontReset = 16,
		}

		[CompilerGenerated]
		private InternedString <name>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private InternedString <layout>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private InternedString <variants>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private string <useStateFrom>k__BackingField; //Field offset: 0x30
		[CompilerGenerated]
		private string <displayName>k__BackingField; //Field offset: 0x38
		[CompilerGenerated]
		private string <shortDisplayName>k__BackingField; //Field offset: 0x40
		[CompilerGenerated]
		private ReadOnlyArray<InternedString> <usages>k__BackingField; //Field offset: 0x48
		[CompilerGenerated]
		private ReadOnlyArray<InternedString> <aliases>k__BackingField; //Field offset: 0x58
		[CompilerGenerated]
		private ReadOnlyArray<NamedValue> <parameters>k__BackingField; //Field offset: 0x68
		[CompilerGenerated]
		private ReadOnlyArray<NameAndParameters> <processors>k__BackingField; //Field offset: 0x78
		[CompilerGenerated]
		private uint <offset>k__BackingField; //Field offset: 0x88
		[CompilerGenerated]
		private uint <bit>k__BackingField; //Field offset: 0x8C
		[CompilerGenerated]
		private uint <sizeInBits>k__BackingField; //Field offset: 0x90
		[CompilerGenerated]
		private FourCC <format>k__BackingField; //Field offset: 0x94
		[CompilerGenerated]
		private Flags <flags>k__BackingField; //Field offset: 0x98
		[CompilerGenerated]
		private int <arraySize>k__BackingField; //Field offset: 0x9C
		[CompilerGenerated]
		private PrimitiveValue <defaultState>k__BackingField; //Field offset: 0xA0
		[CompilerGenerated]
		private PrimitiveValue <minValue>k__BackingField; //Field offset: 0xB0
		[CompilerGenerated]
		private PrimitiveValue <maxValue>k__BackingField; //Field offset: 0xC0

		public internal ReadOnlyArray<InternedString> aliases
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		public internal int arraySize
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 7
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		public internal uint bit
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 7
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		public internal PrimitiveValue defaultState
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 14
			[CompilerGenerated]
			internal set { } //Length: 11
		}

		public internal string displayName
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			internal set { } //Length: 13
		}

		public internal bool dontReset
		{
			 get { } //Length: 12
			internal set { } //Length: 31
		}

		private Flags flags
		{
			[CompilerGenerated]
			[IsReadOnly]
			private get { } //Length: 7
			[CompilerGenerated]
			private set { } //Length: 7
		}

		public internal FourCC format
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 7
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		public bool isArray
		{
			 get { } //Length: 11
		}

		public internal bool isFirstDefinedInThisLayout
		{
			 get { } //Length: 11
			internal set { } //Length: 31
		}

		public internal bool isModifyingExistingControl
		{
			 get { } //Length: 10
			internal set { } //Length: 31
		}

		public internal bool isNoisy
		{
			 get { } //Length: 11
			internal set { } //Length: 31
		}

		public internal bool isSynthetic
		{
			 get { } //Length: 12
			internal set { } //Length: 31
		}

		public internal InternedString layout
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		public internal PrimitiveValue maxValue
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 14
			[CompilerGenerated]
			internal set { } //Length: 11
		}

		public internal PrimitiveValue minValue
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 14
			[CompilerGenerated]
			internal set { } //Length: 11
		}

		public internal InternedString name
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 10
			[CompilerGenerated]
			internal set { } //Length: 13
		}

		public internal uint offset
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 7
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		public internal ReadOnlyArray<NamedValue> parameters
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		public internal ReadOnlyArray<NameAndParameters> processors
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		public internal string shortDisplayName
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			internal set { } //Length: 13
		}

		public internal uint sizeInBits
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 7
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		public internal ReadOnlyArray<InternedString> usages
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		public internal string useStateFrom
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			internal set { } //Length: 13
		}

		public internal InternedString variants
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 18
		}

		[CompilerGenerated]
		[IsReadOnly]
		public ReadOnlyArray<InternedString> get_aliases() { }

		[CompilerGenerated]
		[IsReadOnly]
		public int get_arraySize() { }

		[CompilerGenerated]
		[IsReadOnly]
		public uint get_bit() { }

		[CompilerGenerated]
		[IsReadOnly]
		public PrimitiveValue get_defaultState() { }

		[CompilerGenerated]
		[IsReadOnly]
		public string get_displayName() { }

		public bool get_dontReset() { }

		[CompilerGenerated]
		[IsReadOnly]
		private Flags get_flags() { }

		[CompilerGenerated]
		[IsReadOnly]
		public FourCC get_format() { }

		public bool get_isArray() { }

		public bool get_isFirstDefinedInThisLayout() { }

		public bool get_isModifyingExistingControl() { }

		public bool get_isNoisy() { }

		public bool get_isSynthetic() { }

		[CompilerGenerated]
		[IsReadOnly]
		public InternedString get_layout() { }

		[CompilerGenerated]
		[IsReadOnly]
		public PrimitiveValue get_maxValue() { }

		[CompilerGenerated]
		[IsReadOnly]
		public PrimitiveValue get_minValue() { }

		[CompilerGenerated]
		[IsReadOnly]
		public InternedString get_name() { }

		[CompilerGenerated]
		[IsReadOnly]
		public uint get_offset() { }

		[CompilerGenerated]
		[IsReadOnly]
		public ReadOnlyArray<NamedValue> get_parameters() { }

		[CompilerGenerated]
		[IsReadOnly]
		public ReadOnlyArray<NameAndParameters> get_processors() { }

		[CompilerGenerated]
		[IsReadOnly]
		public string get_shortDisplayName() { }

		[CompilerGenerated]
		[IsReadOnly]
		public uint get_sizeInBits() { }

		[CompilerGenerated]
		[IsReadOnly]
		public ReadOnlyArray<InternedString> get_usages() { }

		[CompilerGenerated]
		[IsReadOnly]
		public string get_useStateFrom() { }

		[CompilerGenerated]
		[IsReadOnly]
		public InternedString get_variants() { }

		public ControlItem Merge(ControlItem other) { }

		[CompilerGenerated]
		internal void set_aliases(ReadOnlyArray<InternedString> value) { }

		[CompilerGenerated]
		internal void set_arraySize(int value) { }

		[CompilerGenerated]
		internal void set_bit(uint value) { }

		[CompilerGenerated]
		internal void set_defaultState(PrimitiveValue value) { }

		[CompilerGenerated]
		internal void set_displayName(string value) { }

		internal void set_dontReset(bool value) { }

		[CompilerGenerated]
		private void set_flags(Flags value) { }

		[CompilerGenerated]
		internal void set_format(FourCC value) { }

		internal void set_isFirstDefinedInThisLayout(bool value) { }

		internal void set_isModifyingExistingControl(bool value) { }

		internal void set_isNoisy(bool value) { }

		internal void set_isSynthetic(bool value) { }

		[CompilerGenerated]
		internal void set_layout(InternedString value) { }

		[CompilerGenerated]
		internal void set_maxValue(PrimitiveValue value) { }

		[CompilerGenerated]
		internal void set_minValue(PrimitiveValue value) { }

		[CompilerGenerated]
		internal void set_name(InternedString value) { }

		[CompilerGenerated]
		internal void set_offset(uint value) { }

		[CompilerGenerated]
		internal void set_parameters(ReadOnlyArray<NamedValue> value) { }

		[CompilerGenerated]
		internal void set_processors(ReadOnlyArray<NameAndParameters> value) { }

		[CompilerGenerated]
		internal void set_shortDisplayName(string value) { }

		[CompilerGenerated]
		internal void set_sizeInBits(uint value) { }

		[CompilerGenerated]
		internal void set_usages(ReadOnlyArray<InternedString> value) { }

		[CompilerGenerated]
		internal void set_useStateFrom(string value) { }

		[CompilerGenerated]
		internal void set_variants(InternedString value) { }

	}

	private class ControlItemJson
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<String, InternedString> <>9__24_0; //Field offset: 0x8
			public static Func<String, InternedString> <>9__24_1; //Field offset: 0x10
			public static Func<NamedValue, String> <>9__25_0; //Field offset: 0x18
			public static Func<NameAndParameters, String> <>9__25_1; //Field offset: 0x20
			public static Func<InternedString, String> <>9__25_2; //Field offset: 0x28
			public static Func<InternedString, String> <>9__25_3; //Field offset: 0x30

			private static <>c() { }

			public <>c() { }

			internal string <FromControlItems>b__25_0(NamedValue x) { }

			internal string <FromControlItems>b__25_1(NameAndParameters x) { }

			internal string <FromControlItems>b__25_2(InternedString x) { }

			internal string <FromControlItems>b__25_3(InternedString x) { }

			internal InternedString <ToLayout>b__24_0(string x) { }

			internal InternedString <ToLayout>b__24_1(string x) { }

		}

		public string name; //Field offset: 0x10
		public string layout; //Field offset: 0x18
		public string variants; //Field offset: 0x20
		public string usage; //Field offset: 0x28
		public string alias; //Field offset: 0x30
		public string useStateFrom; //Field offset: 0x38
		public uint offset; //Field offset: 0x40
		public uint bit; //Field offset: 0x44
		public uint sizeInBits; //Field offset: 0x48
		public string format; //Field offset: 0x50
		public int arraySize; //Field offset: 0x58
		public String[] usages; //Field offset: 0x60
		public String[] aliases; //Field offset: 0x68
		public string parameters; //Field offset: 0x70
		public string processors; //Field offset: 0x78
		public string displayName; //Field offset: 0x80
		public string shortDisplayName; //Field offset: 0x88
		public bool noisy; //Field offset: 0x90
		public bool dontReset; //Field offset: 0x91
		public bool synthetic; //Field offset: 0x92
		public string defaultState; //Field offset: 0x98
		public string minValue; //Field offset: 0xA0
		public string maxValue; //Field offset: 0xA8

		public ControlItemJson() { }

		public static ControlItemJson[] FromControlItems(ControlItem[] items) { }

		public ControlItem ToLayout() { }

	}

	[Flags]
	private enum Flags
	{
		IsGenericTypeOfDevice = 1,
		HideInUI = 2,
		IsOverride = 4,
		CanRunInBackground = 8,
		CanRunInBackgroundIsSet = 16,
		IsNoisy = 32,
	}

	private struct LayoutJson
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<String, InternedString> <>9__14_0; //Field offset: 0x8
			public static Func<InternedString, String> <>9__15_0; //Field offset: 0x10
			public static Func<InternedString, String> <>9__15_1; //Field offset: 0x18

			private static <>c() { }

			public <>c() { }

			internal string <FromLayout>b__15_0(InternedString x) { }

			internal string <FromLayout>b__15_1(InternedString x) { }

			internal InternedString <ToLayout>b__14_0(string x) { }

		}

		public string name; //Field offset: 0x0
		public string extend; //Field offset: 0x8
		public String[] extendMultiple; //Field offset: 0x10
		public string format; //Field offset: 0x18
		public string beforeRender; //Field offset: 0x20
		public string runInBackground; //Field offset: 0x28
		public String[] commonUsages; //Field offset: 0x30
		public string displayName; //Field offset: 0x38
		public string description; //Field offset: 0x40
		public string type; //Field offset: 0x48
		public string variant; //Field offset: 0x50
		public bool isGenericTypeOfDevice; //Field offset: 0x58
		public bool hideInUI; //Field offset: 0x59
		public ControlItemJson[] controls; //Field offset: 0x60

		public static LayoutJson FromLayout(InputControlLayout layout) { }

		public InputControlLayout ToLayout() { }

	}

	public struct LayoutJsonNameAndDescriptorOnly
	{
		public string name; //Field offset: 0x0
		public string extend; //Field offset: 0x8
		public String[] extendMultiple; //Field offset: 0x10
		public MatcherJson device; //Field offset: 0x18

	}

	internal class LayoutNotFoundException : Exception
	{
		[CompilerGenerated]
		private readonly string <layout>k__BackingField; //Field offset: 0x90

		public string layout
		{
			[CompilerGenerated]
			 get { } //Length: 8
		}

		public LayoutNotFoundException() { }

		public LayoutNotFoundException(string name, string message) { }

		public LayoutNotFoundException(string name) { }

		public LayoutNotFoundException(string message, Exception innerException) { }

		protected LayoutNotFoundException(SerializationInfo info, StreamingContext context) { }

		[CompilerGenerated]
		public string get_layout() { }

	}

	private static InternedString s_DefaultVariant; //Field offset: 0x0
	public const string VariantSeparator = ";"; //Field offset: 0x0
	internal static Collection s_Layouts; //Field offset: 0x10
	internal static Cache s_CacheInstance; //Field offset: 0x50
	internal static int s_CacheInstanceRef; //Field offset: 0x58
	private InternedString m_Name; //Field offset: 0x10
	private Type m_Type; //Field offset: 0x20
	private InternedString m_Variants; //Field offset: 0x28
	private FourCC m_StateFormat; //Field offset: 0x38
	internal int m_StateSizeInBytes; //Field offset: 0x3C
	internal Nullable<Boolean> m_UpdateBeforeRender; //Field offset: 0x40
	internal InlinedArray<InternedString> m_BaseLayouts; //Field offset: 0x48
	private InlinedArray<InternedString> m_AppliedOverrides; //Field offset: 0x68
	private InternedString[] m_CommonUsages; //Field offset: 0x88
	internal ControlItem[] m_Controls; //Field offset: 0x90
	internal string m_DisplayName; //Field offset: 0x98
	private string m_Description; //Field offset: 0xA0
	private Flags m_Flags; //Field offset: 0xA8

	public IEnumerable<InternedString> appliedOverrides
	{
		 get { } //Length: 78
	}

	public IEnumerable<InternedString> baseLayouts
	{
		 get { } //Length: 78
	}

	internal static Cache cache
	{
		internal get { } //Length: 79
	}

	public internal Nullable<Boolean> canRunInBackground
	{
		 get { } //Length: 91
		internal set { } //Length: 149
	}

	public ReadOnlyArray<InternedString> commonUsages
	{
		 get { } //Length: 86
	}

	public ReadOnlyArray<ControlItem> controls
	{
		 get { } //Length: 86
	}

	public static InternedString DefaultVariant
	{
		 get { } //Length: 90
	}

	public string displayName
	{
		 get { } //Length: 42
	}

	public internal bool hideInUI
	{
		 get { } //Length: 11
		internal set { } //Length: 31
	}

	public bool isControlLayout
	{
		 get { } //Length: 132
	}

	public bool isDeviceLayout
	{
		 get { } //Length: 126
	}

	public internal bool isGenericTypeOfDevice
	{
		 get { } //Length: 10
		internal set { } //Length: 31
	}

	public internal bool isNoisy
	{
		 get { } //Length: 11
		internal set { } //Length: 31
	}

	public internal bool isOverride
	{
		 get { } //Length: 11
		internal set { } //Length: 31
	}

	public ControlItem Item
	{
		 get { } //Length: 443
	}

	public InternedString name
	{
		 get { } //Length: 11
	}

	public FourCC stateFormat
	{
		 get { } //Length: 4
	}

	public int stateSizeInBytes
	{
		 get { } //Length: 4
	}

	public Type type
	{
		 get { } //Length: 5
	}

	public bool updateBeforeRender
	{
		 get { } //Length: 57
	}

	public InternedString variants
	{
		 get { } //Length: 11
	}

	private static InputControlLayout() { }

	private InputControlLayout(string name, Type type) { }

	[CompilerGenerated]
	private bool <MergeLayout>b__77_0(ControlItem x) { }

	private static void AddControlItems(Type type, List<ControlItem> controlLayouts, string layoutName) { }

	private static void AddControlItemsFromFields(Type type, List<ControlItem> controlLayouts, string layoutName) { }

	private static void AddControlItemsFromMember(MemberInfo member, InputControlAttribute[] attributes, List<ControlItem> controlItems) { }

	private static void AddControlItemsFromMembers(MemberInfo[] members, List<ControlItem> controlItems, string layoutName) { }

	private static void AddControlItemsFromProperties(Type type, List<ControlItem> controlLayouts, string layoutName) { }

	internal static CacheRefInstance CacheRef() { }

	private static ControlItem CreateControlItemFromMember(MemberInfo member, InputControlAttribute attribute) { }

	private static Dictionary<String, ControlItem> CreateLookupTableForControls(ControlItem[] controlItems, List<String> variants = null) { }

	public Nullable<ControlItem> FindControl(InternedString path) { }

	public Nullable<ControlItem> FindControlIncludingArrayElements(string path, out int arrayIndex) { }

	public static InputControlLayout FromJson(string json) { }

	public static InputControlLayout FromType(string name, Type type) { }

	public IEnumerable<InternedString> get_appliedOverrides() { }

	public IEnumerable<InternedString> get_baseLayouts() { }

	internal static Cache get_cache() { }

	public Nullable<Boolean> get_canRunInBackground() { }

	public ReadOnlyArray<InternedString> get_commonUsages() { }

	public ReadOnlyArray<ControlItem> get_controls() { }

	public static InternedString get_DefaultVariant() { }

	public string get_displayName() { }

	public bool get_hideInUI() { }

	public bool get_isControlLayout() { }

	public bool get_isDeviceLayout() { }

	public bool get_isGenericTypeOfDevice() { }

	public bool get_isNoisy() { }

	public bool get_isOverride() { }

	public ControlItem get_Item(string path) { }

	public InternedString get_name() { }

	public FourCC get_stateFormat() { }

	public int get_stateSizeInBytes() { }

	public Type get_type() { }

	public bool get_updateBeforeRender() { }

	public InternedString get_variants() { }

	public Type GetValueType() { }

	private static string InferLayoutFromValueType(Type type) { }

	public void MergeLayout(InputControlLayout other) { }

	internal static void ParseHeaderFieldsFromJson(string json, out InternedString name, out InlinedArray<InternedString>& baseLayouts, out InputDeviceMatcher deviceMatcher) { }

	internal void set_canRunInBackground(Nullable<Boolean> value) { }

	internal void set_hideInUI(bool value) { }

	internal void set_isGenericTypeOfDevice(bool value) { }

	internal void set_isNoisy(bool value) { }

	internal void set_isOverride(bool value) { }

	public string ToJson() { }

	internal static bool VariantsMatch(InternedString expected, InternedString actual) { }

	internal static bool VariantsMatch(string expected, string actual) { }

}

