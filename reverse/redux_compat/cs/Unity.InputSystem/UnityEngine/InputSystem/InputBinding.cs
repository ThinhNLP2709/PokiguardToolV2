/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[Serializable]
	public struct InputBinding : IEquatable<InputBinding> // TypeDefIndex: 6101
	{
		// Fields
		public const char Separator = ';'; // Metadata: 0x00698966
		internal const string kSeparatorString = ";"; // Metadata: 0x00698968
		[SerializeField]
		private string m_Name; // 0x00
		[SerializeField]
		internal string m_Id; // 0x08
		[SerializeField]
		[Tooltip("Path of the control to bind to. Matched at runtime to controls from InputDevices present at the time.\n\nCan either be graphically from the control picker dropdown UI or edited manually in text mode by clicking the \'T\' button. Internally, both methods result in control path strings that look like, for example, \"<Gamepad>/buttonSouth\".")]
		private string m_Path; // 0x10
		[SerializeField]
		private string m_Interactions; // 0x18
		[SerializeField]
		private string m_Processors; // 0x20
		[SerializeField]
		internal string m_Groups; // 0x28
		[SerializeField]
		private string m_Action; // 0x30
		[SerializeField]
		internal Flags m_Flags; // 0x38
		[NonSerialized]
		private string m_OverridePath; // 0x40
		[NonSerialized]
		private string m_OverrideInteractions; // 0x48
		[NonSerialized]
		private string m_OverrideProcessors; // 0x50
	
		// Properties
		public string name { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public Guid id { get; set; } // 0x0000000181CE2560-0x0000000181CE25B0 0x0000000181CE2790-0x0000000181CE27C0
		public string path { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string overridePath { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public string interactions { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string overrideInteractions { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public string processors { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string overrideProcessors { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public string groups { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public string action { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public bool isComposite { get; set; } // 0x0000000181CE25B0-0x0000000181CE25C0 0x0000000181CE27C0-0x0000000181CE27E0
		public bool isPartOfComposite { get; set; } // 0x0000000181CE2610-0x0000000181CE2620 0x0000000181CE27E0-0x0000000181CE2800
		public bool hasOverrides { get; } // 0x0000000181CE2540-0x0000000181CE2560 
		public string effectivePath { get; } // 0x0000000181CE2520-0x0000000181CE2530 
		public string effectiveInteractions { get; } // 0x0000000181CE2510-0x0000000181CE2520 
		public string effectiveProcessors { get; } // 0x0000000181CE2530-0x0000000181CE2540 
		internal bool isEmpty { get; } // 0x0000000181CE25C0-0x0000000181CE2610 
	
		// Nested types
		[Flags]
		public enum DisplayStringOptions // TypeDefIndex: 6102
		{
			DontUseShortDisplayNames = 1,
			DontOmitDevice = 2,
			DontIncludeInteractions = 4,
			IgnoreBindingOverrides = 8
		}
	
		[Flags]
		internal enum MatchOptions // TypeDefIndex: 6103
		{
			EmptyGroupMatchesAny = 1
		}
	
		[Flags]
		internal enum Flags // TypeDefIndex: 6104
		{
			None = 0,
			Composite = 4,
			PartOfComposite = 8
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6105
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<string, bool> __9__45_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181D1A520-0x0000000181D1A590
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _MaskByGroups_b__45_0(string x); // 0x0000000181D1A4C0-0x0000000181D1A4E0
		}
	
		// Constructors
		public InputBinding(string path, string action = null, string groups = null, string processors = null, string interactions = null, string name = null); // 0x0000000181CE2440-0x0000000181CE2510
	
		// Methods
		public string GetNameOfComposite(); // 0x0000000181CE1A40-0x0000000181CE1A80
		internal void GenerateId(); // 0x0000000181CE18C0-0x0000000181CE1910
		internal void RemoveOverrides(); // 0x0000000181CE1DF0-0x0000000181CE1E40
		public static InputBinding MaskByGroup(string group); // 0x0000000181CE1A80-0x0000000181CE1AC0
		public static InputBinding MaskByGroups(params string[] groups); // 0x0000000181CE1AC0-0x0000000181CE1C20
		public bool Equals(InputBinding other); // 0x0000000181CE17E0-0x0000000181CE18C0
		public override bool Equals(object obj); // 0x0000000181CE1710-0x0000000181CE17E0
		public static bool operator ==(InputBinding left, InputBinding right); // 0x0000000181CE2620-0x0000000181CE2670
		public static bool operator !=(InputBinding left, InputBinding right); // 0x0000000181CE2670-0x0000000181CE2790
		public override int GetHashCode(); // 0x0000000181CE1910-0x0000000181CE1A40
		public override string ToString(); // 0x0000000181CE22D0-0x0000000181CE23E0
		public string ToDisplayString(DisplayStringOptions options =  /* Metadata: 0x00698963 */, InputControl control = null); // 0x0000000181CE2290-0x0000000181CE22D0
		public string ToDisplayString(out string deviceLayoutName, out string controlPath, DisplayStringOptions options =  /* Metadata: 0x00698964 */, InputControl control = null); // 0x0000000181CE1E40-0x0000000181CE2290
		internal bool TriggersAction(InputAction action); // 0x0000000181CE23E0-0x0000000181CE2440
		public bool Matches(InputBinding binding); // 0x0000000181CE1C20-0x0000000181CE1C40
		internal bool Matches(ref InputBinding binding, MatchOptions options =  /* Metadata: 0x00698965 */); // 0x0000000181CE1C40-0x0000000181CE1DF0
	}
}
