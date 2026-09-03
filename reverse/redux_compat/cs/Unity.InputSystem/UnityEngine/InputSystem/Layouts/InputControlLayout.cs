/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Layouts
{
	public class InputControlLayout // TypeDefIndex: 6528
	{
		// Fields
		private static InternedString s_DefaultVariant; // 0x00
		public const string VariantSeparator = ";"; // Metadata: 0x00699162
		private InternedString m_Name; // 0x10
		private Type m_Type; // 0x20
		private InternedString m_Variants; // 0x28
		private FourCC m_StateFormat; // 0x38
		internal int m_StateSizeInBytes; // 0x3C
		internal bool? m_UpdateBeforeRender; // 0x40
		internal InlinedArray<InternedString> m_BaseLayouts; // 0x48
		private InlinedArray<InternedString> m_AppliedOverrides; // 0x68
		private InternedString[] m_CommonUsages; // 0x88
		internal ControlItem[] m_Controls; // 0x90
		internal string m_DisplayName; // 0x98
		private string m_Description; // 0xA0
		private Flags m_Flags; // 0xA8
		internal static Collection s_Layouts; // 0x10
		internal static Cache s_CacheInstance; // 0x50
		internal static int s_CacheInstanceRef; // 0x58
	
		// Properties
		public static InternedString DefaultVariant { get; } // 0x0000000181DDE590-0x0000000181DDE5F0 
		public InternedString name { get; } // 0x00000001802E65B0-0x00000001802E65C0 
		public string displayName { get; } // 0x0000000181DDE940-0x0000000181DDE970 
		public Type type { get; } // 0x00000001802F8630-0x00000001802F8640 
		public InternedString variants { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		public FourCC stateFormat { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		public int stateSizeInBytes { get; } // 0x00000001804EFAC0-0x00000001804EFAD0 
		public IEnumerable<InternedString> baseLayouts { get; } // 0x0000000181DDE800-0x0000000181DDE850 
		public IEnumerable<InternedString> appliedOverrides { get; } // 0x0000000181DDE7B0-0x0000000181DDE800 
		public ReadOnlyArray<InternedString> commonUsages { get; } // 0x0000000181DDE8E0-0x0000000181DDE910 
		public ReadOnlyArray<ControlItem> controls { get; } // 0x0000000181DDE910-0x0000000181DDE940 
		public bool updateBeforeRender { get; } // 0x00000001815B1190-0x00000001815B11A0 
		public bool isDeviceLayout { get; } // 0x0000000181DDE9F0-0x0000000181DDEA60 
		public bool isControlLayout { get; } // 0x0000000181DDE980-0x0000000181DDE9F0 
		public bool isOverride { get; internal set; } // 0x0000000181DDEA80-0x0000000181DDEA90 0x0000000181DDEB60-0x0000000181DDEB80
		public bool isGenericTypeOfDevice { get; internal set; } // 0x0000000181DDEA60-0x0000000181DDEA70 0x0000000181DDEB20-0x0000000181DDEB40
		public bool hideInUI { get; internal set; } // 0x0000000181DDE970-0x0000000181DDE980 0x0000000181DDEB00-0x0000000181DDEB20
		public bool isNoisy { get; internal set; } // 0x0000000181DDEA70-0x0000000181DDEA80 0x0000000181DDEB40-0x0000000181DDEB60
		public bool? canRunInBackground { get; internal set; } // 0x0000000181DDE8A0-0x0000000181DDE8E0 0x0000000181DDEA90-0x0000000181DDEB00
		public ControlItem this[string path] { get => default; } // 0x0000000181DDE5F0-0x0000000181DDE7B0 
		internal static ref Cache cache { get; } // 0x0000000181DDE850-0x0000000181DDE8A0 
	
		// Nested types
		public struct ControlItem // TypeDefIndex: 6529
		{
			// Fields
			[CompilerGenerated]
			private InternedString _name_k__BackingField; // 0x00
			[CompilerGenerated]
			private InternedString _layout_k__BackingField; // 0x10
			[CompilerGenerated]
			private InternedString _variants_k__BackingField; // 0x20
			[CompilerGenerated]
			private string _useStateFrom_k__BackingField; // 0x30
			[CompilerGenerated]
			private string _displayName_k__BackingField; // 0x38
			[CompilerGenerated]
			private string _shortDisplayName_k__BackingField; // 0x40
			[CompilerGenerated]
			private ReadOnlyArray<InternedString> _usages_k__BackingField; // 0x48
			[CompilerGenerated]
			private ReadOnlyArray<InternedString> _aliases_k__BackingField; // 0x58
			[CompilerGenerated]
			private ReadOnlyArray<NamedValue> _parameters_k__BackingField; // 0x68
			[CompilerGenerated]
			private ReadOnlyArray<NameAndParameters> _processors_k__BackingField; // 0x78
			[CompilerGenerated]
			private uint _offset_k__BackingField; // 0x88
			[CompilerGenerated]
			private uint _bit_k__BackingField; // 0x8C
			[CompilerGenerated]
			private uint _sizeInBits_k__BackingField; // 0x90
			[CompilerGenerated]
			private FourCC _format_k__BackingField; // 0x94
			[CompilerGenerated]
			private Flags _flags_k__BackingField; // 0x98
			[CompilerGenerated]
			private int _arraySize_k__BackingField; // 0x9C
			[CompilerGenerated]
			private PrimitiveValue _defaultState_k__BackingField; // 0xA0
			[CompilerGenerated]
			private PrimitiveValue _minValue_k__BackingField; // 0xB0
			[CompilerGenerated]
			private PrimitiveValue _maxValue_k__BackingField; // 0xC0
	
			// Properties
			public InternedString name { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018092E600-0x000000018092E610 0x0000000180DE2BC0-0x0000000180DE2BD0
			public InternedString layout { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001802E65B0-0x00000001802E65C0 0x0000000181DD9750-0x0000000181DD9770
			public InternedString variants { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180D91A40-0x0000000180D91A50 0x0000000181DD97F0-0x0000000181DD9810
			public string useStateFrom { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
			public string displayName { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
			public string shortDisplayName { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
			public ReadOnlyArray<InternedString> usages { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001817273C0-0x00000001817273D0 0x0000000181DD97D0-0x0000000181DD97F0
			public ReadOnlyArray<InternedString> aliases { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181B2AD40-0x0000000181B2AD50 0x0000000181DD9680-0x0000000181DD96A0
			public ReadOnlyArray<NamedValue> parameters { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181D97A10-0x0000000181D97A20 0x0000000181DD9790-0x0000000181DD97B0
			public ReadOnlyArray<NameAndParameters> processors { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 0x0000000181DD97B0-0x0000000181DD97D0
			public uint offset { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
			public uint bit { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
			public uint sizeInBits { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018169CBC0-0x000000018169CBD0 0x000000018170C9F0-0x000000018170CA00
			public FourCC format { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D1E0-0x000000018033D1F0 0x000000018033E7C0-0x000000018033E7D0
			private Flags flags { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
			public int arraySize { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018033D200-0x000000018033D210 0x000000018033E7E0-0x000000018033E7F0
			public PrimitiveValue defaultState { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181DD9600-0x0000000181DD9610 0x0000000181DD96A0-0x0000000181DD96B0
			public PrimitiveValue minValue { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181DD9670-0x0000000181DD9680 0x0000000181DD9780-0x0000000181DD9790
			public PrimitiveValue maxValue { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181C2D450-0x0000000181C2D460 0x0000000181DD9770-0x0000000181DD9780
			public bool isModifyingExistingControl { get; internal set; } // 0x0000000181DD9640-0x0000000181DD9650 0x0000000181DD96F0-0x0000000181DD9710
			public bool isNoisy { get; internal set; } // 0x0000000181DD9650-0x0000000181DD9660 0x0000000181DD9710-0x0000000181DD9730
			public bool isSynthetic { get; internal set; } // 0x0000000181DD9660-0x0000000181DD9670 0x0000000181DD9730-0x0000000181DD9750
			public bool dontReset { get; internal set; } // 0x0000000181DD9610-0x0000000181DD9620 0x0000000181DD96B0-0x0000000181DD96D0
			public bool isFirstDefinedInThisLayout { get; internal set; } // 0x0000000181DD9630-0x0000000181DD9640 0x0000000181DD96D0-0x0000000181DD96F0
			public bool isArray { get; } // 0x0000000181DD9620-0x0000000181DD9630 
	
			// Nested types
			[Flags]
			private enum Flags // TypeDefIndex: 6530
			{
				isModifyingExistingControl = 1,
				IsNoisy = 2,
				IsSynthetic = 4,
				IsFirstDefinedInThisLayout = 8,
				DontReset = 16
			}
	
			// Methods
			public ControlItem Merge(ControlItem other); // 0x0000000181DD9270-0x0000000181DD9600
		}
	
		public class Builder // TypeDefIndex: 6531
		{
			// Fields
			[CompilerGenerated]
			private string _name_k__BackingField; // 0x10
			[CompilerGenerated]
			private string _displayName_k__BackingField; // 0x18
			[CompilerGenerated]
			private Type _type_k__BackingField; // 0x20
			[CompilerGenerated]
			private FourCC _stateFormat_k__BackingField; // 0x28
			[CompilerGenerated]
			private int _stateSizeInBytes_k__BackingField; // 0x2C
			private string m_ExtendsLayout; // 0x30
			[CompilerGenerated]
			private bool? _updateBeforeRender_k__BackingField; // 0x38
			private int m_ControlCount; // 0x3C
			private ControlItem[] m_Controls; // 0x40
	
			// Properties
			public string name { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public string displayName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public Type type { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public FourCC stateFormat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
			public int stateSizeInBytes { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
			public string extendsLayout { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181DD5710-0x0000000181DD5750
			public bool? updateBeforeRender { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DD5700-0x0000000181DD5710 0x0000000181DD5750-0x0000000181DD5760
			public ReadOnlyArray<ControlItem> controls { get; } // 0x0000000181DD56C0-0x0000000181DD5700 
	
			// Nested types
			public struct ControlBuilder // TypeDefIndex: 6532
			{
				// Fields
				internal Builder builder; // 0x00
				internal int index; // 0x08
	
				// Nested types
				[Serializable]
				[CompilerGenerated]
				private sealed class __c // TypeDefIndex: 6533
				{
					// Fields
					public static readonly __c __9; // 0x00
					public static Func<string, InternedString> __9__14_0; // 0x08
	
					// Constructors
					static __c(); // 0x0000000181DEA400-0x0000000181DEA470
					public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
					// Methods
					internal InternedString _WithUsages_b__14_0(string x); // 0x0000000181DEA100-0x0000000181DEA130
				}
	
				// Methods
				public ControlBuilder WithDisplayName(string displayName); // 0x0000000181DD79A0-0x0000000181DD7A10
				public ControlBuilder WithLayout(string layout); // 0x0000000181DD7AE0-0x0000000181DD7C00
				public ControlBuilder WithFormat(FourCC format); // 0x0000000181DD7A90-0x0000000181DD7AE0
				public ControlBuilder WithFormat(string format); // 0x0000000181DD7A10-0x0000000181DD7A90
				public ControlBuilder WithByteOffset(uint offset); // 0x0000000181DD78F0-0x0000000181DD7940
				public ControlBuilder WithBitOffset(uint bit); // 0x0000000181DD78A0-0x0000000181DD78F0
				public ControlBuilder IsSynthetic(bool value); // 0x0000000181DD77B0-0x0000000181DD7820
				public ControlBuilder IsNoisy(bool value); // 0x0000000181DD7740-0x0000000181DD77B0
				public ControlBuilder DontReset(bool value); // 0x0000000181DD76D0-0x0000000181DD7740
				public ControlBuilder WithSizeInBits(uint sizeInBits); // 0x0000000181DD7ED0-0x0000000181DD7F20
				public ControlBuilder WithRange(float minValue, float maxValue); // 0x0000000181DD7DF0-0x0000000181DD7ED0
				public ControlBuilder WithUsages(params InternedString[] usages); // 0x0000000181DD7F20-0x0000000181DD8130
				public ControlBuilder WithUsages(IEnumerable<string> usages); // 0x0000000181DD8130-0x0000000181DD8280
				public ControlBuilder WithUsages(params string[] usages); // 0x0000000181DD8130-0x0000000181DD8280
				public ControlBuilder WithParameters(string parameters); // 0x0000000181DD7C00-0x0000000181DD7CE0
				public ControlBuilder WithProcessors(string processors); // 0x0000000181DD7CE0-0x0000000181DD7DF0
				public ControlBuilder WithDefaultState(PrimitiveValue value); // 0x0000000181DD7940-0x0000000181DD79A0
				public ControlBuilder UsingStateFrom(string path); // 0x0000000181DD7820-0x0000000181DD78A0
				public ControlBuilder AsArrayOfControlsWithSize(int arraySize); // 0x0000000181DD7680-0x0000000181DD76D0
			}
	
			// Constructors
			public Builder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public ControlBuilder AddControl(string name); // 0x0000000181DD51F0-0x0000000181DD5410
			public Builder WithName(string name); // 0x00000001807166C0-0x00000001807166E0
			public Builder WithDisplayName(string displayName); // 0x00000001806CFB10-0x00000001806CFB30
			public Builder WithType<T>()
				where T : InputControl;
			public Builder WithFormat(FourCC format); // 0x00000001806CFB00-0x00000001806CFB10
			public Builder WithFormat(string format); // 0x0000000181DD5680-0x0000000181DD56B0
			public Builder WithSizeInBytes(int sizeInBytes); // 0x0000000181DD56B0-0x0000000181DD56C0
			public Builder Extend(string baseLayoutName); // 0x0000000181DD5630-0x0000000181DD5680
			public InputControlLayout Build(); // 0x0000000181DD5410-0x0000000181DD5630
		}
	
		[Flags]
		private enum Flags // TypeDefIndex: 6534
		{
			IsGenericTypeOfDevice = 1,
			HideInUI = 2,
			IsOverride = 4,
			CanRunInBackground = 8,
			CanRunInBackgroundIsSet = 16,
			IsNoisy = 32
		}
	
		[Serializable]
		internal struct LayoutJsonNameAndDescriptorOnly // TypeDefIndex: 6535
		{
			// Fields
			public string name; // 0x00
			public string extend; // 0x08
			public string[] extendMultiple; // 0x10
			public InputDeviceMatcher.MatcherJson device; // 0x18
		}
	
		[Serializable]
		private struct LayoutJson // TypeDefIndex: 6536
		{
			// Fields
			public string name; // 0x00
			public string extend; // 0x08
			public string[] extendMultiple; // 0x10
			public string format; // 0x18
			public string beforeRender; // 0x20
			public string runInBackground; // 0x28
			public string[] commonUsages; // 0x30
			public string displayName; // 0x38
			public string description; // 0x40
			public string type; // 0x48
			public string variant; // 0x50
			public bool isGenericTypeOfDevice; // 0x58
			public bool hideInUI; // 0x59
			public ControlItemJson[] controls; // 0x60
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6537
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<string, InternedString> __9__14_0; // 0x08
				public static Func<InternedString, string> __9__15_0; // 0x10
				public static Func<InternedString, string> __9__15_1; // 0x18
	
				// Constructors
				static __c(); // 0x0000000181DEA390-0x0000000181DEA400
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal InternedString _ToLayout_b__14_0(string x); // 0x0000000181DEA100-0x0000000181DEA130
				internal string _FromLayout_b__15_0(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
				internal string _FromLayout_b__15_1(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
			}
	
			// Methods
			public InputControlLayout ToLayout(); // 0x0000000181DE51D0-0x0000000181DE5CD0
			public static LayoutJson FromLayout(InputControlLayout layout); // 0x0000000181DE4E00-0x0000000181DE51D0
		}
	
		[Serializable]
		private class ControlItemJson // TypeDefIndex: 6538
		{
			// Fields
			public string name; // 0x10
			public string layout; // 0x18
			public string variants; // 0x20
			public string usage; // 0x28
			public string alias; // 0x30
			public string useStateFrom; // 0x38
			public uint offset; // 0x40
			public uint bit; // 0x44
			public uint sizeInBits; // 0x48
			public string format; // 0x50
			public int arraySize; // 0x58
			public string[] usages; // 0x60
			public string[] aliases; // 0x68
			public string parameters; // 0x70
			public string processors; // 0x78
			public string displayName; // 0x80
			public string shortDisplayName; // 0x88
			public bool noisy; // 0x90
			public bool dontReset; // 0x91
			public bool synthetic; // 0x92
			public string defaultState; // 0x98
			public string minValue; // 0xA0
			public string maxValue; // 0xA8
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6539
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<string, InternedString> __9__24_0; // 0x08
				public static Func<string, InternedString> __9__24_1; // 0x10
				public static Func<NamedValue, string> __9__25_0; // 0x18
				public static Func<NameAndParameters, string> __9__25_1; // 0x20
				public static Func<InternedString, string> __9__25_2; // 0x28
				public static Func<InternedString, string> __9__25_3; // 0x30
	
				// Constructors
				static __c(); // 0x0000000181DEA320-0x0000000181DEA390
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal InternedString _ToLayout_b__24_0(string x); // 0x0000000181DEA100-0x0000000181DEA130
				internal InternedString _ToLayout_b__24_1(string x); // 0x0000000181DEA100-0x0000000181DEA130
				internal string _FromControlItems_b__25_0(NamedValue x); // 0x0000000181D01A50-0x0000000181D01A70
				internal string _FromControlItems_b__25_1(NameAndParameters x); // 0x0000000181D01980-0x0000000181D019A0
				internal string _FromControlItems_b__25_2(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
				internal string _FromControlItems_b__25_3(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
			}
	
			// Constructors
			public ControlItemJson(); // 0x0000000181DD9250-0x0000000181DD9270
	
			// Methods
			public ControlItem ToLayout(); // 0x0000000181DD8AE0-0x0000000181DD9250
			public static ControlItemJson[] FromControlItems(ControlItem[] items); // 0x0000000181DD8280-0x0000000181DD8AE0
		}
	
		internal struct Collection // TypeDefIndex: 6540
		{
			// Fields
			public const float kBaseScoreForNonGeneratedLayouts = 1f; // Metadata: 0x00699170
			public Dictionary<InternedString, Type> layoutTypes; // 0x00
			public Dictionary<InternedString, string> layoutStrings; // 0x08
			public Dictionary<InternedString, Func<InputControlLayout>> layoutBuilders; // 0x10
			public Dictionary<InternedString, InternedString> baseLayoutTable; // 0x18
			public Dictionary<InternedString, InternedString[]> layoutOverrides; // 0x20
			public HashSet<InternedString> layoutOverrideNames; // 0x28
			public Dictionary<InternedString, PrecompiledLayout> precompiledLayouts; // 0x30
			public List<LayoutMatcher> layoutMatchers; // 0x38
	
			// Nested types
			public struct LayoutMatcher // TypeDefIndex: 6541
			{
				// Fields
				public InternedString layoutName; // 0x00
				public InputDeviceMatcher deviceMatcher; // 0x10
			}
	
			public struct PrecompiledLayout // TypeDefIndex: 6542
			{
				// Fields
				public Func<InputDevice> factoryMethod; // 0x00
				public string metadata; // 0x08
			}
	
			[CompilerGenerated]
			private sealed class _GetBaseLayouts_d__24 : IEnumerable<InternedString>, IEnumerator<InternedString> // TypeDefIndex: 6543
			{
				// Fields
				private int __1__state; // 0x10
				private InternedString __2__current; // 0x18
				private int __l__initialThreadId; // 0x28
				private bool includeSelf; // 0x2C
				public bool __3__includeSelf; // 0x2D
				private InternedString layout; // 0x30
				public InternedString __3__layout; // 0x40
				public Collection __4__this; // 0x50
				public Collection __3____4__this; // 0x90
	
				// Properties
				InternedString IEnumerator<UnityEngine.InputSystem.Utilities.InternedString>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181CF7230-0x0000000181CF7280 
	
				// Constructors
				[DebuggerHidden]
				public _GetBaseLayouts_d__24(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
				private bool MoveNext(); // 0x0000000181CF7040-0x0000000181CF7110
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x0000000181CF71F0-0x0000000181CF7230
				[DebuggerHidden]
				IEnumerator<InternedString> IEnumerable<InternedString>.GetEnumerator(); // 0x0000000181CF7110-0x0000000181CF71F0
				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CF7110-0x0000000181CF71F0
			}
	
			// Methods
			public void Allocate(); // 0x0000000181DD59E0-0x0000000181DD5C40
			public InternedString TryFindLayoutForType(Type layoutType); // 0x0000000181DD65F0-0x0000000181DD6750
			public InternedString TryFindMatchingLayout(InputDeviceDescription deviceDescription); // 0x0000000181DD6750-0x0000000181DD6990
			public bool HasLayout(InternedString name); // 0x0000000181DD63F0-0x0000000181DD64C0
			private InputControlLayout TryLoadLayoutInternal(InternedString name); // 0x0000000181DD6990-0x0000000181DD6C20
			public InputControlLayout TryLoadLayout(InternedString name, Dictionary<InternedString, InputControlLayout> table = null); // 0x0000000181DD6C20-0x0000000181DD7060
			public InternedString GetBaseLayoutName(InternedString layoutName); // 0x0000000181DD6090-0x0000000181DD6130
			public InternedString GetRootLayoutName(InternedString layoutName); // 0x0000000181DD6340-0x0000000181DD63F0
			public bool ComputeDistanceInInheritanceHierarchy(InternedString firstLayout, InternedString secondLayout, out int distance); // 0x0000000181DD5C40-0x0000000181DD5E90
			public InternedString FindLayoutThatIntroducesControl(InputControl control, Cache cache); // 0x0000000181DD5E90-0x0000000181DD6090
			public Type GetControlTypeForLayout(InternedString layoutName); // 0x0000000181DD6200-0x0000000181DD6340
			public bool ValueTypeIsAssignableFrom(InternedString layoutName, Type valueType); // 0x0000000181DD7060-0x0000000181DD7230
			public bool IsGeneratedLayout(InternedString layout); // 0x0000000181DD6590-0x0000000181DD65F0
			[IteratorStateMachine(typeof(_GetBaseLayouts_d__24))]
			public IEnumerable<InternedString> GetBaseLayouts(InternedString layout, bool includeSelf = true /* Metadata: 0x0069916F */); // 0x0000000181DD6130-0x0000000181DD6200
			public bool IsBasedOn(InternedString parentLayout, InternedString childLayout); // 0x0000000181DD64C0-0x0000000181DD6590
			public void AddMatcher(InternedString layout, InputDeviceMatcher matcher); // 0x0000000181DD5810-0x0000000181DD59E0
		}
	
		public class LayoutNotFoundException : Exception // TypeDefIndex: 6544
		{
			// Fields
			[CompilerGenerated]
			private readonly string _layout_k__BackingField; // 0x90
	
			// Properties
			public string layout { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
			// Constructors
			public LayoutNotFoundException(); // 0x00000001815FE7B0-0x00000001815FE7E0
			public LayoutNotFoundException(string name, string message); // 0x0000000181429F20-0x0000000181429F80
			public LayoutNotFoundException(string name); // 0x0000000181CF4530-0x0000000181CF45E0
			public LayoutNotFoundException(string message, Exception innerException); // 0x00000001813FDED0-0x00000001813FDF70
			protected LayoutNotFoundException(SerializationInfo info, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
		}
	
		internal struct Cache // TypeDefIndex: 6545
		{
			// Fields
			public Dictionary<InternedString, InputControlLayout> table; // 0x00
	
			// Methods
			public void Clear(); // 0x000000018103EDD0-0x000000018103EDE0
			public InputControlLayout FindOrLoadLayout(string name, bool throwIfNotFound = true /* Metadata: 0x00699174 */); // 0x0000000181CE5630-0x0000000181CE5800
		}
	
		internal struct CacheRefInstance : IDisposable // TypeDefIndex: 6546
		{
			// Fields
			public bool valid; // 0x00
	
			// Methods
			public void Dispose(); // 0x0000000181CE55A0-0x0000000181CE5630
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6547
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<string, InternedString> __9__52_0; // 0x08
			public static Func<string, InternedString> __9__75_0; // 0x10
			public static Func<string, InternedString> __9__75_1; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181CF73F0-0x0000000181CF7460
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal InternedString _FromType_b__52_0(string x); // 0x0000000181CF7280-0x0000000181CF7330
			internal InternedString _CreateControlItemFromMember_b__75_0(string x); // 0x0000000181CF7280-0x0000000181CF7330
			internal InternedString _CreateControlItemFromMember_b__75_1(string x); // 0x0000000181CF7280-0x0000000181CF7330
		}
	
		// Constructors
		private InputControlLayout(string name, Type type); // 0x0000000181DDE520-0x0000000181DDE590
		static InputControlLayout(); // 0x0000000181DDE4A0-0x0000000181DDE520
	
		// Methods
		public ControlItem? FindControl(InternedString path); // 0x0000000181DDBC90-0x0000000181DDC070
		public ControlItem? FindControlIncludingArrayElements(string path, out int arrayIndex); // 0x0000000181DDB760-0x0000000181DDBC90
		public Type GetValueType(); // 0x0000000181DDC6A0-0x0000000181DDC6F0
		public static InputControlLayout FromType(string name, Type type); // 0x0000000181DDC110-0x0000000181DDC6A0
		public string ToJson(); // 0x0000000181DDE190-0x0000000181DDE240
		public static InputControlLayout FromJson(string json); // 0x0000000181DDC070-0x0000000181DDC110
		private static void AddControlItems(Type type, List<ControlItem> controlLayouts, string layoutName); // 0x0000000181DDA7E0-0x0000000181DDA920
		private static void AddControlItemsFromFields(Type type, List<ControlItem> controlLayouts, string layoutName); // 0x0000000181DD9C90-0x0000000181DD9D30
		private static void AddControlItemsFromProperties(Type type, List<ControlItem> controlLayouts, string layoutName); // 0x0000000181DDA740-0x0000000181DDA7E0
		private static void AddControlItemsFromMembers(MemberInfo[] members, List<ControlItem> controlItems, string layoutName); // 0x0000000181DDA110-0x0000000181DDA740
		private static void AddControlItemsFromMember(MemberInfo member, InputControlAttribute[] attributes, List<ControlItem> controlItems); // 0x0000000181DD9D30-0x0000000181DDA110
		private static ControlItem CreateControlItemFromMember(MemberInfo member, InputControlAttribute attribute); // 0x0000000181DDA980-0x0000000181DDB2B0
		private static string InferLayoutFromValueType(Type type); // 0x0000000181DDC6F0-0x0000000181DDC900
		public void MergeLayout(InputControlLayout other); // 0x0000000181DDC900-0x0000000181DDDF90
		private static Dictionary<string, ControlItem> CreateLookupTableForControls(ControlItem[] controlItems, List<string> variants = null); // 0x0000000181DDB2B0-0x0000000181DDB760
		internal static bool VariantsMatch(InternedString expected, InternedString actual); // 0x0000000181DDE2F0-0x0000000181DDE350
		internal static bool VariantsMatch(string expected, string actual); // 0x0000000181DDE350-0x0000000181DDE4A0
		internal static void ParseHeaderFieldsFromJson(string json, out InternedString name, out InlinedArray<InternedString> baseLayouts, out InputDeviceMatcher deviceMatcher); // 0x0000000181DDDF90-0x0000000181DDE190
		internal static CacheRefInstance CacheRef(); // 0x0000000181DDA920-0x0000000181DDA980
		[CompilerGenerated]
		private bool _MergeLayout_b__77_0(ControlItem x); // 0x0000000181DDE240-0x0000000181DDE2F0
	}
}
