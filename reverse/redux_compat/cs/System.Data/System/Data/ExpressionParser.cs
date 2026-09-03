/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class ExpressionParser // TypeDefIndex: 11278
	{
		// Fields
		private static readonly ReservedWords[] s_reservedwords; // 0x00
		private char _escape; // 0x10
		private char _decimalSeparator; // 0x12
		private char _listSeparator; // 0x14
		private char _exponentL; // 0x16
		private char _exponentU; // 0x18
		internal char[] _text; // 0x20
		internal int _pos; // 0x28
		internal int _start; // 0x2C
		internal Tokens _token; // 0x30
		internal int _op; // 0x34
		internal OperatorInfo[] _ops; // 0x38
		internal int _topOperator; // 0x40
		internal int _topNode; // 0x44
		private readonly DataTable _table; // 0x48
		internal ExpressionNode[] _nodeStack; // 0x50
		internal int _prevOperand; // 0x58
		internal ExpressionNode _expression; // 0x60
	
		// Nested types
		[IsReadOnly]
		private struct ReservedWords // TypeDefIndex: 11279
		{
			// Fields
			internal readonly string _word; // 0x00
			internal readonly Tokens _token; // 0x08
			internal readonly int _op; // 0x0C
	
			// Constructors
			internal ReservedWords(string word, Tokens token, int op); // 0x0000000180BE46C0-0x0000000180BE4700
		}
	
		// Constructors
		internal ExpressionParser(DataTable table); // 0x000000018188FEC0-0x000000018188FF80
		static ExpressionParser(); // 0x000000018188FA40-0x000000018188FEC0
	
		// Methods
		internal void LoadExpression(string data); // 0x000000018188D0F0-0x000000018188D1F0
		internal void StartScan(); // 0x000000018188F9A0-0x000000018188FA40
		internal ExpressionNode Parse(); // 0x000000018188D670-0x000000018188E940
		private ExpressionNode ParseAggregateArgument(FunctionId aggregate); // 0x000000018188D320-0x000000018188D670
		private ExpressionNode NodePop(); // 0x000000018188D230-0x000000018188D270
		private ExpressionNode NodePeek(); // 0x000000018188D1F0-0x000000018188D230
		private void NodePush(ExpressionNode node); // 0x000000018188D270-0x000000018188D320
		private void BuildExpression(int pri); // 0x000000018188CB90-0x000000018188CF10
		internal void CheckToken(Tokens token); // 0x000000018188CF10-0x000000018188CF60
		internal Tokens Scan(); // 0x000000018188F260-0x000000018188F9A0
		private void ScanNumeric(); // 0x000000018188EC80-0x000000018188EE60
		private void ScanName(); // 0x000000018188EA60-0x000000018188EB40
		private void ScanName(char chEnd, char esc, string charsToEscape); // 0x000000018188EB40-0x000000018188EC80
		private void ScanDate(); // 0x000000018188E940-0x000000018188EA60
		private void ScanBinaryConstant(); // 0x00000001802E76C0-0x00000001802E76D0
		private void ScanReserved(); // 0x000000018188EE60-0x000000018188F0D0
		private void ScanString(char escape); // 0x000000018188F0D0-0x000000018188F1B0
		internal void ScanToken(Tokens token); // 0x000000018188F1B0-0x000000018188F210
		private void ScanWhite(); // 0x000000018188F210-0x000000018188F260
		private bool IsWhiteSpace(char ch); // 0x000000018188D0E0-0x000000018188D0F0
		private bool IsAlphaNumeric(char ch); // 0x000000018188CF60-0x000000018188D000
		private bool IsDigit(char ch); // 0x000000018188D080-0x000000018188D0E0
		private bool IsAlpha(char ch); // 0x000000018188D000-0x000000018188D080
	}
}
