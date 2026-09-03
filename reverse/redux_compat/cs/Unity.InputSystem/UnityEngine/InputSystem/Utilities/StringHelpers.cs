/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal static class StringHelpers // TypeDefIndex: 6639
	{
		// Nested types
		[CompilerGenerated]
		private sealed class _Split_d__9 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 6640
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private string str; // 0x28
			public string __3__str; // 0x30
			private Func<char, bool> predicate; // 0x38
			public Func<char, bool> __3__predicate; // 0x40
			private int _length_5__2; // 0x48
			private int _position_5__3; // 0x4C
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Split_d__9(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181D013C0-0x0000000181D01510
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D015C0-0x0000000181D01600
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x0000000181D01510-0x0000000181D015C0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D01510-0x0000000181D015C0
		}
	
		[CompilerGenerated]
		private sealed class _Tokenize_d__8 : IEnumerable<Substring>, IEnumerator<Substring> // TypeDefIndex: 6641
		{
			// Fields
			private int __1__state; // 0x10
			private Substring __2__current; // 0x18
			private int __l__initialThreadId; // 0x28
			private string str; // 0x30
			public string __3__str; // 0x38
			private int _length_5__2; // 0x40
			private int _endPos_5__3; // 0x44
	
			// Properties
			Substring IEnumerator<UnityEngine.InputSystem.Utilities.Substring>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181D01930-0x0000000181D01980 
	
			// Constructors
			[DebuggerHidden]
			public _Tokenize_d__8(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181D01600-0x0000000181D01850
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D018F0-0x0000000181D01930
			[DebuggerHidden]
			IEnumerator<Substring> IEnumerable<Substring>.GetEnumerator(); // 0x0000000181D01850-0x0000000181D018F0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D01850-0x0000000181D018F0
		}
	
		// Methods
		public static string NicifyMemorySize(long numBytes); // 0x0000000181CFEEE0-0x0000000181CFF070
		public static bool FromNicifiedMemorySize(string text, out long result, long defaultMultiplier = 1 /* Metadata: 0x006991D2 */); // 0x0000000181CFEB30-0x0000000181CFECC0
		public static string Join<TValue>(string separator, params TValue[] values);
		public static string Join<TValue>(IEnumerable<TValue> values, string separator);
		public static string MakeUniqueName<TExisting>(string baseName, IEnumerable<TExisting> existingSet, Func<TExisting, string> getNameFunc);
		public static bool CharacterSeparatedListsHaveAtLeastOneCommonElement(string firstList, string secondList, char separator); // 0x0000000181CFE4A0-0x0000000181CFE730
		public static int ParseInt(string str, int pos); // 0x0000000181CFF070-0x0000000181CFF100
		public static bool WriteStringToBuffer(string text, IntPtr buffer, int bufferSizeInCharacters); // 0x0000000181CFF7A0-0x0000000181CFF7C0
		public static bool WriteStringToBuffer(string text, IntPtr buffer, int bufferSizeInCharacters, ref uint offset); // 0x0000000181CFF5F0-0x0000000181CFF7A0
		public static string ReadStringFromBuffer(IntPtr buffer, int bufferSize); // 0x0000000181CFF1F0-0x0000000181CFF2C0
		public static string ReadStringFromBuffer(IntPtr buffer, int bufferSize, ref uint offset); // 0x0000000181CFF100-0x0000000181CFF1F0
		public static string ExpandTemplateString(string template, Func<string, string> mapFunc); // 0x0000000181CFE950-0x0000000181CFEB30
	
		// Extension methods
		public static string Escape(this string str, string chars = "\n\t\r\\\"" /* Metadata: 0x006991BA */, string replacements = "ntr\\\"" /* Metadata: 0x006991C0 */); // 0x0000000181CFE800-0x0000000181CFE950
		public static string Unescape(this string str, string chars = "ntr\\\"" /* Metadata: 0x006991C6 */, string replacements = "\n\t\r\\\"" /* Metadata: 0x006991CC */); // 0x0000000181CFF3D0-0x0000000181CFF510
		public static bool Contains(this string str, char ch); // 0x0000000181CFE760-0x0000000181CFE790
		public static bool Contains(this string str, string text, StringComparison comparison); // 0x0000000181CFE730-0x0000000181CFE760
		public static string GetPlural(this string str); // 0x0000000181CFECC0-0x0000000181CFEE40
		public static int CountOccurrences(this string str, char ch); // 0x0000000181CFE790-0x0000000181CFE800
		[IteratorStateMachine(typeof(_Tokenize_d__8))]
		public static IEnumerable<Substring> Tokenize(this string str); // 0x0000000181CFF350-0x0000000181CFF3D0
		[IteratorStateMachine(typeof(_Split_d__9))]
		public static IEnumerable<string> Split(this string str, Func<char, bool> predicate); // 0x0000000181CFF2C0-0x0000000181CFF350
		public static bool IsPrintable(this char ch); // 0x0000000181CFEE90-0x0000000181CFEEE0
		public static string WithAllWhitespaceStripped(this string str); // 0x0000000181CFF510-0x0000000181CFF5F0
		public static bool InvariantEqualsIgnoreCase(this string left, string right); // 0x0000000181CFEE40-0x0000000181CFEE90
	}
}
