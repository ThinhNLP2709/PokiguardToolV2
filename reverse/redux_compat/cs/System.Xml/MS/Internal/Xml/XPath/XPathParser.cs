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
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.XPath
{
	internal class XPathParser // TypeDefIndex: 7310
	{
		// Fields
		private XPathScanner _scanner; // 0x10
		private int _parseDepth; // 0x18
		private static readonly XPathResultType[] s_temparray1; // 0x00
		private static readonly XPathResultType[] s_temparray2; // 0x08
		private static readonly XPathResultType[] s_temparray3; // 0x10
		private static readonly XPathResultType[] s_temparray4; // 0x18
		private static readonly XPathResultType[] s_temparray5; // 0x20
		private static readonly XPathResultType[] s_temparray6; // 0x28
		private static readonly XPathResultType[] s_temparray7; // 0x30
		private static readonly XPathResultType[] s_temparray8; // 0x38
		private static readonly XPathResultType[] s_temparray9; // 0x40
		private static Dictionary<string, ParamInfo> s_functionTable; // 0x48
		private static Dictionary<string, Axis.AxisType> s_AxesTable; // 0x50
	
		// Nested types
		private class ParamInfo // TypeDefIndex: 7311
		{
			// Fields
			private Function.FunctionType _ftype; // 0x10
			private int _minargs; // 0x14
			private int _maxargs; // 0x18
			private XPathResultType[] _argTypes; // 0x20
	
			// Properties
			public Function.FunctionType FType { get; } // 0x00000001802E64B0-0x00000001802E64C0 
			public int Minargs { get; } // 0x0000000180A5E110-0x0000000180A5E120 
			public int Maxargs { get; } // 0x0000000180B23260-0x0000000180B23270 
			public XPathResultType[] ArgTypes { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			internal ParamInfo(Function.FunctionType ftype, int minargs, int maxargs, XPathResultType[] argTypes); // 0x0000000181A21130-0x0000000181A21190
		}
	
		// Constructors
		private XPathParser(XPathScanner scanner); // 0x00000001803855F0-0x0000000180385630
		static XPathParser(); // 0x0000000181A27A70-0x0000000181A27E40
	
		// Methods
		public static AstNode ParseXPathExpression(string xpathExpression); // 0x0000000181A27840-0x0000000181A279F0
		private AstNode ParseExpression(AstNode qyInput); // 0x0000000181A255A0-0x0000000181A25740
		private AstNode ParseOrExpr(AstNode qyInput); // 0x0000000181A26740-0x0000000181A268A0
		private AstNode ParseAndExpr(AstNode qyInput); // 0x0000000181A25320-0x0000000181A25480
		private AstNode ParseEqualityExpr(AstNode qyInput); // 0x0000000181A25480-0x0000000181A255A0
		private AstNode ParseRelationalExpr(AstNode qyInput); // 0x0000000181A27070-0x0000000181A271A0
		private AstNode ParseAdditiveExpr(AstNode qyInput); // 0x0000000181A25200-0x0000000181A25320
		private AstNode ParseMultiplicativeExpr(AstNode qyInput); // 0x0000000181A26190-0x0000000181A26350
		private AstNode ParseUnaryExpr(AstNode qyInput); // 0x0000000181A27500-0x0000000181A27640
		private AstNode ParseUnionExpr(AstNode qyInput); // 0x0000000181A27640-0x0000000181A27840
		private static bool IsNodeType(XPathScanner scaner); // 0x0000000181A25050-0x0000000181A25120
		private AstNode ParsePathExpr(AstNode qyInput); // 0x0000000181A268A0-0x0000000181A26BB0
		private AstNode ParseFilterExpr(AstNode qyInput); // 0x0000000181A25740-0x0000000181A25810
		private AstNode ParsePredicate(AstNode qyInput); // 0x0000000181A26BB0-0x0000000181A26D40
		private AstNode ParseLocationPath(AstNode qyInput); // 0x0000000181A25810-0x0000000181A25970
		private AstNode ParseRelativeLocationPath(AstNode qyInput); // 0x0000000181A271A0-0x0000000181A27280
		private static bool IsStep(XPathScanner.LexKind lexKind); // 0x0000000181A251B0-0x0000000181A251E0
		private AstNode ParseStep(AstNode qyInput); // 0x0000000181A27280-0x0000000181A27500
		private AstNode ParseNodeTest(AstNode qyInput, Axis.AxisType axisType, XPathNodeType nodeType); // 0x0000000181A26350-0x0000000181A26740
		private static bool IsPrimaryExpr(XPathScanner scanner); // 0x0000000181A25120-0x0000000181A251B0
		private AstNode ParsePrimaryExpr(AstNode qyInput); // 0x0000000181A26D40-0x0000000181A27070
		private AstNode ParseMethod(AstNode qyInput); // 0x0000000181A25970-0x0000000181A26190
		private void CheckToken(XPathScanner.LexKind t); // 0x0000000181A23F90-0x0000000181A24010
		private void PassToken(XPathScanner.LexKind t); // 0x0000000181A279F0-0x0000000181A27A20
		private void NextLex(); // 0x0000000181A251E0-0x0000000181A25200
		private bool TestOp(string op); // 0x0000000181A27A20-0x0000000181A27A70
		private void CheckNodeSet(XPathResultType t); // 0x0000000181A23F20-0x0000000181A23F90
		private static Dictionary<string, ParamInfo> CreateFunctionTable(); // 0x0000000181A24290-0x0000000181A24F60
		private static Dictionary<string, Axis.AxisType> CreateAxesTable(); // 0x0000000181A24010-0x0000000181A24290
		private Axis.AxisType GetAxis(); // 0x0000000181A24F60-0x0000000181A25050
	}
}
