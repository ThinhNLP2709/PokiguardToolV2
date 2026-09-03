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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct RegexFCD // TypeDefIndex: 8710
	{
		// Fields
		private readonly List<RegexFC> _fcStack; // 0x00
		private ValueListBuilder<int> _intStack; // 0x08
		private bool _skipAllChildren; // 0x28
		private bool _skipchild; // 0x29
		private bool _failed; // 0x2A
	
		// Constructors
		private RegexFCD(Span<int> intStack); // 0x0000000181B6B410-0x0000000181B6B4D0
	
		// Methods
		public static RegexPrefix? FirstChars(RegexTree t); // 0x0000000181B6A7F0-0x0000000181B6AD70
		public static RegexPrefix Prefix(RegexTree tree); // 0x0000000181B6AE10-0x0000000181B6B0B0
		public static int Anchors(RegexTree tree); // 0x0000000181B69D40-0x0000000181B69F00
		private static int AnchorFromType(int type); // 0x0000000181B69CC0-0x0000000181B69D40
		private void PushInt(int i); // 0x0000000181B6B160-0x0000000181B6B1F0
		private bool IntIsEmpty(); // 0x0000000181B6AD70-0x0000000181B6AD80
		private int PopInt(); // 0x0000000181B6ADE0-0x0000000181B6AE10
		private void PushFC(RegexFC fc); // 0x0000000181B6B0B0-0x0000000181B6B160
		private bool FCIsEmpty(); // 0x0000000181B6A7D0-0x0000000181B6A7F0
		private RegexFC PopFC(); // 0x0000000181B6AD80-0x0000000181B6ADE0
		private RegexFC TopFC(); // 0x0000000181B6B3E0-0x0000000181B6B410
		public void Dispose(); // 0x0000000181B6A6F0-0x0000000181B6A7D0
		private RegexFC RegexFCFromRegexTree(RegexTree tree); // 0x0000000181B6B1F0-0x0000000181B6B3E0
		private void SkipChild(); // 0x0000000181B1FC30-0x0000000181B1FC40
		private void CalculateFC(int NodeType, RegexNode node, int CurIndex); // 0x0000000181B69F00-0x0000000181B6A6F0
	}
}
