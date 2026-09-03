/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Layouts
{
	public struct InputDeviceMatcher : IEquatable<UnityEngine.InputSystem.Layouts.InputDeviceMatcher> // TypeDefIndex: 6553
	{
		// Fields
		private KeyValuePair<InternedString, object>[] m_Patterns; // 0x00
		private static readonly InternedString kInterfaceKey; // 0x00
		private static readonly InternedString kDeviceClassKey; // 0x10
		private static readonly InternedString kManufacturerKey; // 0x20
		private static readonly InternedString kManufacturerContainsKey; // 0x30
		private static readonly InternedString kProductKey; // 0x40
		private static readonly InternedString kVersionKey; // 0x50
	
		// Properties
		public bool empty { get; } // 0x0000000180E87410-0x0000000180E87420 
		public IEnumerable<KeyValuePair<string, object>> patterns { [IteratorStateMachine(typeof(_get_patterns_d__4))] get; } // 0x0000000181CF07C0-0x0000000181CF0840 
	
		// Nested types
		[Serializable]
		internal struct MatcherJson // TypeDefIndex: 6554
		{
			// Fields
			public string @interface; // 0x00
			public string[] interfaces; // 0x08
			public string deviceClass; // 0x10
			public string[] deviceClasses; // 0x18
			public string manufacturer; // 0x20
			public string manufacturerContains; // 0x28
			public string[] manufacturers; // 0x30
			public string product; // 0x38
			public string[] products; // 0x40
			public string version; // 0x48
			public string[] versions; // 0x50
			public Capability[] capabilities; // 0x58
	
			// Nested types
			public struct Capability // TypeDefIndex: 6555
			{
				// Fields
				public string path; // 0x00
				public string value; // 0x08
			}
	
			// Methods
			public static MatcherJson FromMatcher(InputDeviceMatcher matcher); // 0x0000000181CF45E0-0x0000000181CF4980
			public InputDeviceMatcher ToMatcher(); // 0x0000000181CF4980-0x0000000181CF52D0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6556
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<char, bool> __9__12_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181CF7380-0x0000000181CF73F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _With_b__12_0(char ch); // 0x0000000181CF7330-0x0000000181CF7380
		}
	
		[CompilerGenerated]
		private sealed class _get_patterns_d__4 : IEnumerable<KeyValuePair<string, object>>, IEnumerator<KeyValuePair<string, object>> // TypeDefIndex: 6557
		{
			// Fields
			private int __1__state; // 0x10
			private KeyValuePair<string, object> __2__current; // 0x18
			private int __l__initialThreadId; // 0x28
			public InputDeviceMatcher __4__this; // 0x30
			public InputDeviceMatcher __3____4__this; // 0x38
			private int _count_5__2; // 0x40
			private int _i_5__3; // 0x44
	
			// Properties
			KeyValuePair<string, object> IEnumerator<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181CF7640-0x0000000181CF7690 
	
			// Constructors
			[DebuggerHidden]
			public _get_patterns_d__4(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181CF7460-0x0000000181CF7560
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181CF7600-0x0000000181CF7640
			[DebuggerHidden]
			IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator(); // 0x0000000181CF7560-0x0000000181CF7600
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CF7560-0x0000000181CF7600
		}
	
		// Constructors
		static InputDeviceMatcher(); // 0x0000000181CF0280-0x0000000181CF07C0
	
		// Methods
		public InputDeviceMatcher WithInterface(string pattern, bool supportRegex = true /* Metadata: 0x00699176 */); // 0x0000000181CEFCC0-0x0000000181CEFD50
		public InputDeviceMatcher WithDeviceClass(string pattern, bool supportRegex = true /* Metadata: 0x00699177 */); // 0x0000000181CEFC20-0x0000000181CEFCC0
		public InputDeviceMatcher WithManufacturer(string pattern, bool supportRegex = true /* Metadata: 0x00699178 */); // 0x0000000181CEFE90-0x0000000181CEFF30
		public InputDeviceMatcher WithManufacturerContains(string noRegExPattern); // 0x0000000181CEFD50-0x0000000181CEFE90
		public InputDeviceMatcher WithProduct(string pattern, bool supportRegex = true /* Metadata: 0x00699179 */); // 0x0000000181CEFF30-0x0000000181CEFFD0
		public InputDeviceMatcher WithVersion(string pattern, bool supportRegex = true /* Metadata: 0x0069917A */); // 0x0000000181CEFFD0-0x0000000181CF0070
		public InputDeviceMatcher WithCapability<TValue>(string path, TValue value);
		private InputDeviceMatcher With(InternedString key, object value, bool supportRegex = true /* Metadata: 0x0069917B */); // 0x0000000181CF0070-0x0000000181CF0280
		public float MatchPercentage(InputDeviceDescription deviceDescription); // 0x0000000181CEF4C0-0x0000000181CEF990
		private static bool MatchSingleProperty(object pattern, string value); // 0x0000000181CEF9E0-0x0000000181CEFAA0
		private static bool MatchSinglePropertyContains(object pattern, string value); // 0x0000000181CEF990-0x0000000181CEF9E0
		private static int GetNumPropertiesIn(InputDeviceDescription description); // 0x0000000181CEF420-0x0000000181CEF4C0
		public static InputDeviceMatcher FromDeviceDescription(InputDeviceDescription deviceDescription); // 0x0000000181CEEDF0-0x0000000181CEF420
		public override string ToString(); // 0x0000000181CEFAA0-0x0000000181CEFC20
		public bool Equals(InputDeviceMatcher other); // 0x0000000181CEECC0-0x0000000181CEEDF0
		public override bool Equals(object obj); // 0x0000000181CEEC20-0x0000000181CEECC0
		public static bool operator ==(InputDeviceMatcher left, InputDeviceMatcher right); // 0x0000000181CF0840-0x0000000181CF08A0
		public static bool operator !=(InputDeviceMatcher left, InputDeviceMatcher right); // 0x0000000181CF08A0-0x0000000181CF0940
		public override int GetHashCode(); // 0x0000000181302320-0x0000000181302340
	}
}
