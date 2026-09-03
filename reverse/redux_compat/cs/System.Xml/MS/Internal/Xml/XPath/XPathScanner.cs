/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.XPath
{
	internal sealed class XPathScanner // TypeDefIndex: 7312
	{
		// Fields
		private string _xpathExpr; // 0x10
		private int _xpathExprIndex; // 0x18
		private LexKind _kind; // 0x1C
		private char _currentChar; // 0x20
		private string _name; // 0x28
		private string _prefix; // 0x30
		private string _stringValue; // 0x38
		private double _numberValue; // 0x40
		private bool _canBeFunction; // 0x48
		private XmlCharType _xmlCharType; // 0x50
	
		// Properties
		public string SourceText { get; } // 0x0000000180377550-0x0000000180377560 
		private char CurrentChar { get; } // 0x00000001816A1C50-0x00000001816A1C60 
		public LexKind Kind { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public string Name { get; } // 0x000000018033D240-0x000000018033D250 
		public string Prefix { get; } // 0x000000018031E110-0x000000018031E120 
		public string StringValue { get; } // 0x00000001803272A0-0x00000001803272B0 
		public double NumberValue { get; } // 0x0000000181A28A90-0x0000000181A28AA0 
		public bool CanBeFunction { get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
	
		// Nested types
		public enum LexKind // TypeDefIndex: 7313
		{
			Bang = 33,
			Quote = 34,
			Dollar = 36,
			Apos = 39,
			LParens = 40,
			RParens = 41,
			Star = 42,
			Plus = 43,
			Comma = 44,
			Minus = 45,
			Dot = 46,
			Slash = 47,
			Lt = 60,
			Eq = 61,
			Gt = 62,
			At = 64,
			And = 65,
			DotDot = 68,
			Eof = 69,
			Ge = 71,
			Le = 76,
			Ne = 78,
			Or = 79,
			SlashSlash = 83,
			LBracket = 91,
			RBracket = 93,
			Axe = 97,
			Number = 100,
			Name = 110,
			String = 115,
			Union = 124
		}
	
		// Constructors
		public XPathScanner(string xpathExpr); // 0x0000000181A289B0-0x0000000181A28A90
	
		// Methods
		private bool NextChar(); // 0x0000000181A27E40-0x0000000181A27EA0
		private void SkipSpace(); // 0x0000000181A28940-0x0000000181A289B0
		public bool NextLex(); // 0x0000000181A27EA0-0x0000000181A284D0
		private double ScanNumber(); // 0x0000000181A28680-0x0000000181A28800
		private double ScanFraction(); // 0x0000000181A284D0-0x0000000181A285C0
		private string ScanString(); // 0x0000000181A28800-0x0000000181A28940
		private string ScanName(); // 0x0000000181A285C0-0x0000000181A28680
	}
}
