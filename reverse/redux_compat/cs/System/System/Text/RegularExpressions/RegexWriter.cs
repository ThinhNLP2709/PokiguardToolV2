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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct RegexWriter // TypeDefIndex: 8722
	{
		// Fields
		private ValueListBuilder<int> _emitted; // 0x00
		private ValueListBuilder<int> _intStack; // 0x20
		private readonly Dictionary<string, int> _stringHash; // 0x40
		private readonly List<string> _stringTable; // 0x48
		private Hashtable _caps; // 0x50
		private int _trackCount; // 0x58
	
		// Constructors
		private RegexWriter(Span<int> emittedSpan, Span<int> intStackSpan); // 0x0000000181B84D40-0x0000000181B84E70
	
		// Methods
		public static RegexCode Write(RegexTree tree); // 0x0000000181B84AF0-0x0000000181B84D40
		public void Dispose(); // 0x0000000181B83700-0x0000000181B83750
		public RegexCode RegexCodeFromRegexTree(RegexTree tree); // 0x0000000181B84450-0x0000000181B849B0
		private void PatchJump(int offset, int jumpDest); // 0x0000000181B84430-0x0000000181B84450
		private void Emit(int op); // 0x0000000181B841C0-0x0000000181B84260
		private void Emit(int op, int opd1); // 0x0000000181B840E0-0x0000000181B841C0
		private void Emit(int op, int opd1, int opd2); // 0x0000000181B84260-0x0000000181B84390
		private int StringCode(string str); // 0x0000000181B849B0-0x0000000181B84AF0
		private int MapCapnum(int capnum); // 0x0000000181B84390-0x0000000181B84430
		private void EmitFragment(int nodetype, RegexNode node, int curIndex); // 0x0000000181B83750-0x0000000181B840E0
	}
}
