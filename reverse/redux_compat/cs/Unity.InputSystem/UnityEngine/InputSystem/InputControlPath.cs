/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public static class InputControlPath // TypeDefIndex: 6145
	{
		// Fields
		public const string Wildcard = "*"; // Metadata: 0x00698A42
		public const string DoubleWildcard = "**"; // Metadata: 0x00698A44
		public const char Separator = '/'; // Metadata: 0x00698A47
		internal const char SeparatorReplacement = ' '; // Metadata: 0x00698A49
	
		// Nested types
		[Flags]
		public enum HumanReadableStringOptions // TypeDefIndex: 6146
		{
			None = 0,
			OmitDevice = 2,
			UseShortNames = 4
		}
	
		internal enum PathComponentType // TypeDefIndex: 6147
		{
			Name = 0,
			DisplayName = 1,
			Usage = 2,
			Layout = 3
		}
	
		public struct ParsedPathComponent // TypeDefIndex: 6148
		{
			// Fields
			internal Substring m_Layout; // 0x00
			internal InlinedArray<Substring> m_Usages; // 0x10
			internal Substring m_Name; // 0x30
			internal Substring m_DisplayName; // 0x40
	
			// Properties
			public string layout { get; } // 0x0000000181D189B0-0x0000000181D189C0 
			public IEnumerable<string> usages { get; } // 0x0000000181D189D0-0x0000000181D18B00 
			public string name { get; } // 0x0000000181D189C0-0x0000000181D189D0 
			public string displayName { get; } // 0x0000000181D188C0-0x0000000181D188D0 
			internal bool isWildcard { get; } // 0x0000000181D18940-0x0000000181D189B0 
			internal bool isDoubleWildcard { get; } // 0x0000000181D188D0-0x0000000181D18940 
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6149
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<Substring, string> __9__7_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181D1A590-0x0000000181D1A600
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _get_usages_b__7_0(Substring x); // 0x0000000181D1A4E0-0x0000000181D1A500
			}
	
			// Methods
			internal string ToHumanReadableString(string parentLayoutName, string parentControlPath, out string referencedLayoutName, out string controlPath, HumanReadableStringOptions options); // 0x0000000181D17B70-0x0000000181D188C0
			private static string ToHumanReadableString(Substring substring); // 0x0000000181D17B20-0x0000000181D17B70
			public bool Matches(InputControl control); // 0x0000000181D176F0-0x0000000181D17B20
			private static bool ComparePathElementToString(Substring pathElement, string element); // 0x0000000181D175C0-0x0000000181D176F0
		}
	
		private struct PathParser // TypeDefIndex: 6150
		{
			// Fields
			private string path; // 0x00
			private int length; // 0x08
			private int leftIndexInPath; // 0x0C
			private int rightIndexInPath; // 0x10
			public ParsedPathComponent current; // 0x18
	
			// Properties
			public bool isAtEnd { get; } // 0x0000000181D19160-0x0000000181D19170 
	
			// Constructors
			public PathParser(string path); // 0x0000000181D19100-0x0000000181D19160
	
			// Methods
			public bool MoveToNextComponent(); // 0x0000000181D18B00-0x0000000181D19020
			private Substring ParseComponentPart(char terminator); // 0x0000000181D19020-0x0000000181D19100
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6151
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Substring, string> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181D1A670-0x0000000181D1A6E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _TryGetDeviceUsages_b__9_0(Substring x); // 0x0000000181D1A4E0-0x0000000181D1A500
		}
	
		[CompilerGenerated]
		private sealed class _Parse_d__34 : IEnumerable<ParsedPathComponent>, IEnumerator<ParsedPathComponent> // TypeDefIndex: 6152
		{
			// Fields
			private int __1__state; // 0x10
			private ParsedPathComponent __2__current; // 0x18
			private int __l__initialThreadId; // 0x68
			private string path; // 0x70
			public string __3__path; // 0x78
			private PathParser _parser_5__2; // 0x80
	
			// Properties
			ParsedPathComponent IEnumerator<UnityEngine.InputSystem.InputControlPath.ParsedPathComponent>.Current { [DebuggerHidden] get; } // 0x0000000181107510-0x0000000181107540 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181D1A3E0-0x0000000181D1A450 
	
			// Constructors
			[DebuggerHidden]
			public _Parse_d__34(int __1__state); // 0x0000000181D1A490-0x0000000181D1A4C0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181D1A450-0x0000000181D1A490
			private bool MoveNext(); // 0x0000000181D1A120-0x0000000181D1A300
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D1A3A0-0x0000000181D1A3E0
			[DebuggerHidden]
			IEnumerator<ParsedPathComponent> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputControlPath.ParsedPathComponent>.GetEnumerator(); // 0x0000000181D1A300-0x0000000181D1A3A0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D1A300-0x0000000181D1A3A0
		}
	
		// Methods
		public static string Combine(InputControl parent, string path); // 0x0000000181D09F90-0x0000000181D0A070
		public static string ToHumanReadableString(string path, HumanReadableStringOptions options = HumanReadableStringOptions.None /* Metadata: 0x00698A37 */, InputControl control = null); // 0x0000000181D0B3E0-0x0000000181D0B420
		public static string ToHumanReadableString(string path, out string deviceLayoutName, out string controlPath, HumanReadableStringOptions options = HumanReadableStringOptions.None /* Metadata: 0x00698A38 */, InputControl control = null); // 0x0000000181D0B420-0x0000000181D0BA70
		public static string[] TryGetDeviceUsages(string path); // 0x0000000181D0C090-0x0000000181D0C270
		public static string TryGetDeviceLayout(string path); // 0x0000000181D0BF30-0x0000000181D0C090
		public static string TryGetControlLayout(string path); // 0x0000000181D0BCD0-0x0000000181D0BF30
		private static string FindControlLayoutRecursive(ref PathParser parser, string layoutName); // 0x0000000181D0A5E0-0x0000000181D0A740
		private static string FindControlLayoutRecursive(ref PathParser parser, InputControlLayout layout); // 0x0000000181D0A240-0x0000000181D0A5E0
		private static bool ControlLayoutMatchesPathComponent(ref InputControlLayout.ControlItem controlItem, ref PathParser parser); // 0x0000000181D0A070-0x0000000181D0A240
		private static bool StringMatches(Substring str, InternedString matchTo); // 0x0000000181D0B220-0x0000000181D0B3E0
		public static InputControl TryFindControl(InputControl control, string path, int indexInPath = 0 /* Metadata: 0x00698A39 */); // 0x0000000181D0BAD0-0x0000000181D0BB30
		public static InputControl[] TryFindControls(InputControl control, string path, int indexInPath = 0 /* Metadata: 0x00698A3A */); // 0x0000000181D0BBA0-0x0000000181D0BCD0
		public static int TryFindControls(InputControl control, string path, ref InputControlList<InputControl> matches, int indexInPath = 0 /* Metadata: 0x00698A3B */); // 0x0000000181D0BB30-0x0000000181D0BBA0
		public static TControl TryFindControl<TControl>(InputControl control, string path, int indexInPath = 0 /* Metadata: 0x00698A3C */)
			where TControl : InputControl;
		public static int TryFindControls<TControl>(InputControl control, string path, int indexInPath, ref InputControlList<TControl> matches)
			where TControl : InputControl;
		public static InputControl TryFindChild(InputControl control, string path, int indexInPath = 0 /* Metadata: 0x00698A3D */); // 0x0000000181D0BA70-0x0000000181D0BAD0
		public static TControl TryFindChild<TControl>(InputControl control, string path, int indexInPath = 0 /* Metadata: 0x00698A3E */)
			where TControl : InputControl;
		public static bool Matches(string expected, InputControl control); // 0x0000000181D0AF30-0x0000000181D0B0D0
		internal static bool MatchControlComponent(ref ParsedPathComponent expectedControlComponent, ref InputControlLayout.ControlItem controlItem, bool matchAlias = false /* Metadata: 0x00698A3F */); // 0x0000000181D0A740-0x0000000181D0AAD0
		public static bool MatchesPrefix(string expected, InputControl control); // 0x0000000181D0ACF0-0x0000000181D0AEA0
		private static bool MatchesRecursive(ref PathParser parser, InputControl currentControl, bool prefixOnly = false /* Metadata: 0x00698A40 */); // 0x0000000181D0AEA0-0x0000000181D0AF30
		private static TControl MatchControlsRecursive<TControl>(InputControl control, string path, int indexInPath, ref InputControlList<TControl> matches, bool matchMultiple)
			where TControl : InputControl;
		private static TControl MatchByUsageAtDeviceRootRecursive<TControl>(InputDevice device, string path, int indexInPath, ref InputControlList<TControl> matches, bool matchMultiple)
			where TControl : InputControl;
		private static TControl MatchChildrenRecursive<TControl>(InputControl control, string path, int indexInPath, ref InputControlList<TControl> matches, bool matchMultiple)
			where TControl : InputControl;
		internal static bool MatchPathComponent(string component, string path, ref int indexInPath, PathComponentType componentType, int startIndexInComponent = 0 /* Metadata: 0x00698A41 */); // 0x0000000181D0AAD0-0x0000000181D0ACF0
		private static bool PathComponentCanYieldMultipleMatches(string path, int indexInPath); // 0x0000000181D0B150-0x0000000181D0B220
		[IteratorStateMachine(typeof(_Parse_d__34))]
		public static IEnumerable<ParsedPathComponent> Parse(string path); // 0x0000000181D0B0D0-0x0000000181D0B150
	
		// Extension methods
		internal static string CleanSlashes(this string pathComponent); // 0x0000000181D09F60-0x0000000181D09F90
	}
}
