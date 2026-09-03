/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class SortKey // TypeDefIndex: 3440
	{
		// Fields
		private readonly string source; // 0x10
		private readonly byte[] key; // 0x18
		private readonly CompareOptions options; // 0x20
		private readonly int lcid; // 0x24
	
		// Properties
		public virtual string OriginalString { get; } // 0x0000000180377550-0x0000000180377560 
		public virtual byte[] KeyData { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal SortKey(int lcid, string source, CompareOptions opt); // 0x000000018158B6F0-0x000000018158B7D0
		internal SortKey(int lcid, string source, byte[] buffer, CompareOptions opt, int lv1Length, int lv2Length, int lv3Length, int kanaSmallLength, int markTypeLength, int katakanaLength, int kanaWidthLength, int identLength); // 0x000000018158B630-0x000000018158B6A0
		internal SortKey(string localeName, string str, CompareOptions options, byte[] keyData); // 0x000000018158B6A0-0x000000018158B6F0
		internal SortKey(); // 0x000000018158B7D0-0x000000018158B800
	
		// Methods
		public static int Compare(SortKey sortkey1, SortKey sortkey2); // 0x000000018158B1A0-0x000000018158B3C0
		public override bool Equals(object value); // 0x000000018158B3C0-0x000000018158B460
		public override int GetHashCode(); // 0x000000018158B460-0x000000018158B4D0
		public override string ToString(); // 0x000000018158B4D0-0x000000018158B630
	}
}
