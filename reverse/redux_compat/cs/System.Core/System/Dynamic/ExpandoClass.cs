/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	internal class ExpandoClass // TypeDefIndex: 12564
	{
		// Fields
		private readonly string[] _keys; // 0x10
		private readonly int _hashCode; // 0x18
		private Dictionary<int, List<WeakReference>> _transitions; // 0x20
		internal static readonly ExpandoClass Empty; // 0x00
	
		// Properties
		internal string[] Keys { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal ExpandoClass(); // 0x00000001817EDD70-0x00000001817EDE00
		internal ExpandoClass(string[] keys, int hashCode); // 0x00000001817EDD20-0x00000001817EDD70
		static ExpandoClass(); // 0x00000001817EDC40-0x00000001817EDD20
	
		// Methods
		internal ExpandoClass FindNewClass(string newKey); // 0x00000001817ED400-0x00000001817ED8D0
		private List<WeakReference> GetTransitionList(int hashCode); // 0x00000001817ED8D0-0x00000001817EDA00
		internal int GetValueIndex(string name, bool caseInsensitive, ExpandoObject obj); // 0x00000001817EDC20-0x00000001817EDC40
		internal int GetValueIndexCaseSensitive(string name); // 0x00000001817EDB80-0x00000001817EDC20
		private int GetValueIndexCaseInsensitive(string name, ExpandoObject obj); // 0x00000001817EDA00-0x00000001817EDB80
	}
}
