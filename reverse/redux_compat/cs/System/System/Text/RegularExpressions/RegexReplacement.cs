/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexReplacement // TypeDefIndex: 8718
	{
		// Fields
		private readonly List<string> _strings; // 0x10
		private readonly List<int> _rules; // 0x18
		[CompilerGenerated]
		private readonly string _Pattern_k__BackingField; // 0x20
	
		// Properties
		public string Pattern { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public RegexReplacement(string rep, RegexNode concat, Hashtable _caps); // 0x0000000181B81FC0-0x0000000181B823D0
	
		// Methods
		public static RegexReplacement GetOrCreate(WeakReference<RegexReplacement> replRef, string replacement, Hashtable caps, int capsize, Hashtable capnames, RegexOptions roptions); // 0x0000000181B81410-0x0000000181B81630
		private void ReplacementImpl(StringBuilder sb, Match match); // 0x0000000181B81E30-0x0000000181B81FC0
		private void ReplacementImplRTL(List<string> al, Match match); // 0x0000000181B81C90-0x0000000181B81E30
		public string Replace(Regex regex, string input, int count, int startat); // 0x0000000181B81630-0x0000000181B81C90
	}
}
