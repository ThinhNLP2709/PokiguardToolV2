/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class StringInfo // TypeDefIndex: 3434
	{
		// Fields
		[OptionalField(VersionAdded = 2)]
		private string m_str; // 0x10
		[NonSerialized]
		private int[] m_indexes; // 0x18
	
		// Properties
		private int[] Indexes { get; } // 0x000000018158BDD0-0x000000018158BE20 
		public string String { get; set; } // 0x0000000180377550-0x0000000180377560 0x000000018158BE80-0x000000018158BF30
		public int LengthInTextElements { get; } // 0x000000018158BE20-0x000000018158BE80 
	
		// Constructors
		public StringInfo(); // 0x000000018158BCF0-0x000000018158BDD0
		public StringInfo(string value); // 0x000000018158BC40-0x000000018158BCF0
	
		// Methods
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x000000018158B9E0-0x000000018158BA00
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x000000018158B9A0-0x000000018158B9E0
		[ComVisible(false)]
		public override bool Equals(object value); // 0x000000018158B800-0x000000018158B890
		[ComVisible(false)]
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
		internal static int GetCurrentTextElementLen(string str, int index, int len, ref UnicodeCategory ucCurrent, ref int currentCharCount); // 0x000000018158B890-0x000000018158B9A0
		public static int[] ParseCombiningCharacters(string str); // 0x000000018158BA00-0x000000018158BC40
	}
}
