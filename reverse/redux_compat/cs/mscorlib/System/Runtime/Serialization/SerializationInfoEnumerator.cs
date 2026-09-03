/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	public sealed class SerializationInfoEnumerator : IEnumerator // TypeDefIndex: 3017
	{
		// Fields
		private readonly string[] _members; // 0x10
		private readonly object[] _data; // 0x18
		private readonly Type[] _types; // 0x20
		private readonly int _numItems; // 0x28
		private int _currItem; // 0x2C
		private bool _current; // 0x30
	
		// Properties
		object IEnumerator.Current { get; } // 0x00000001814EB220-0x00000001814EB280 
		public SerializationEntry Current { get; } // 0x00000001814EB300-0x00000001814EB420 
		public string Name { get; } // 0x00000001814EB420-0x00000001814EB4B0 
		public object Value { get; } // 0x00000001814EB540-0x00000001814EB5D0 
		public Type ObjectType { get; } // 0x00000001814EB4B0-0x00000001814EB540 
	
		// Constructors
		internal SerializationInfoEnumerator(string[] members, object[] info, Type[] types, int numItems); // 0x00000001814EB280-0x00000001814EB300
	
		// Methods
		public bool MoveNext(); // 0x00000001814EB1F0-0x00000001814EB210
		public void Reset(); // 0x00000001814EB210-0x00000001814EB220
	}
}
