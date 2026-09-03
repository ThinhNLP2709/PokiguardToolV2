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
	internal sealed class RegexNode // TypeDefIndex: 8714
	{
		// Fields
		public int NType; // 0x10
		public List<RegexNode> Children; // 0x18
		public string Str; // 0x20
		public char Ch; // 0x28
		public int M; // 0x2C
		public int N; // 0x30
		public readonly RegexOptions Options; // 0x34
		public RegexNode Next; // 0x38
	
		// Constructors
		public RegexNode(int type, RegexOptions options); // 0x0000000181B7A650-0x0000000181B7A690
		public RegexNode(int type, RegexOptions options, char ch); // 0x0000000181B7A690-0x0000000181B7A6E0
		public RegexNode(int type, RegexOptions options, string str); // 0x0000000181B7A560-0x0000000181B7A5B0
		public RegexNode(int type, RegexOptions options, int m); // 0x0000000181B7A5B0-0x0000000181B7A600
		public RegexNode(int type, RegexOptions options, int m, int n); // 0x0000000181B7A600-0x0000000181B7A650
	
		// Methods
		public bool UseOptionR(); // 0x0000000181B7A550-0x0000000181B7A560
		public RegexNode ReverseLeft(); // 0x0000000181B7A440-0x0000000181B7A4A0
		private void MakeRep(int type, int min, int max); // 0x0000000181B79660-0x0000000181B79670
		private RegexNode Reduce(); // 0x0000000181B7A130-0x0000000181B7A440
		private RegexNode StripEnation(int emptyType); // 0x0000000181B7A4A0-0x0000000181B7A550
		private RegexNode ReduceGroup(); // 0x0000000181B79E40-0x0000000181B79E90
		private RegexNode ReduceRep(); // 0x0000000181B79E90-0x0000000181B7A010
		private RegexNode ReduceSet(); // 0x0000000181B7A010-0x0000000181B7A130
		private RegexNode ReduceAlternation(); // 0x0000000181B79670-0x0000000181B79A80
		private RegexNode ReduceConcatenation(); // 0x0000000181B79A80-0x0000000181B79E40
		public RegexNode MakeQuantifier(bool lazy, int min, int max); // 0x0000000181B79550-0x0000000181B79660
		public void AddChild(RegexNode newChild); // 0x0000000181B79420-0x0000000181B79550
		public RegexNode Child(int i); // 0x000000018142D840-0x000000018142D860
		public int ChildCount(); // 0x0000000181332730-0x0000000181332750
		public int Type(); // 0x00000001802E64B0-0x00000001802E64C0
	}
}
