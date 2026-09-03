/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Match : Group // TypeDefIndex: 8696
	{
		// Fields
		internal GroupCollection _groupcoll; // 0x38
		internal Regex _regex; // 0x40
		internal int _textbeg; // 0x48
		internal int _textpos; // 0x4C
		internal int _textend; // 0x50
		internal int _textstart; // 0x54
		internal int[][] _matches; // 0x58
		internal int[] _matchcount; // 0x60
		internal bool _balancing; // 0x68
		[CompilerGenerated]
		private static readonly Match _Empty_k__BackingField; // 0x00
	
		// Properties
		public static Match Empty { [CompilerGenerated] get; } // 0x0000000181B61240-0x0000000181B61290 
		public virtual GroupCollection Groups { get; } // 0x0000000181B61290-0x0000000181B61320 
	
		// Constructors
		internal Match(Regex regex, int capcount, string text, int begpos, int len, int startpos); // 0x0000000181B61080-0x0000000181B61210
		static Match(); // 0x0000000181B60FE0-0x0000000181B61080
		internal Match(); // 0x0000000181B61210-0x0000000181B61240
	
		// Methods
		internal virtual void Reset(Regex regex, string text, int textbeg, int textend, int textstart); // 0x0000000181B60D40-0x0000000181B60DF0
		public Match NextMatch(); // 0x0000000181B60CC0-0x0000000181B60D10
		internal virtual ReadOnlySpan<char> GroupToStringImpl(int groupnum); // 0x0000000181B60970-0x0000000181B60AD0
		internal ReadOnlySpan<char> LastGroupToStringImpl(); // 0x0000000181B60B50-0x0000000181B60BA0
		internal virtual void AddMatch(int cap, int start, int len); // 0x0000000181B60620-0x0000000181B60820
		internal virtual void BalanceMatch(int cap); // 0x0000000181B60820-0x0000000181B60970
		internal virtual void RemoveMatch(int cap); // 0x0000000181B60D10-0x0000000181B60D40
		internal virtual bool IsMatched(int cap); // 0x0000000181B60AD0-0x0000000181B60B50
		internal virtual int MatchIndex(int cap); // 0x0000000181B60BA0-0x0000000181B60C30
		internal virtual int MatchLength(int cap); // 0x0000000181B60C30-0x0000000181B60CC0
		internal virtual void Tidy(int textpos); // 0x0000000181B60DF0-0x0000000181B60FE0
	}
}
