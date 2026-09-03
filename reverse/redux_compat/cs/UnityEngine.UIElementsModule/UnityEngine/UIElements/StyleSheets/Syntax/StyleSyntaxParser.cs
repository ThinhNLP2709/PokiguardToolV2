/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal class StyleSyntaxParser // TypeDefIndex: 5267
	{
		// Fields
		private List<Expression> m_ProcessExpressionList; // 0x10
		private Stack<Expression> m_ExpressionStack; // 0x18
		private Stack<ExpressionCombinator> m_CombinatorStack; // 0x20
		private Dictionary<string, Expression> m_ParsedExpressionCache; // 0x28
	
		// Constructors
		public StyleSyntaxParser(); // 0x000000018246C190-0x000000018246C2E0
	
		// Methods
		public Expression Parse(string syntax); // 0x000000018246BCB0-0x000000018246BE60
		private Expression ParseExpression(StyleSyntaxTokenizer tokenizer); // 0x000000018246A620-0x000000018246A910
		private void ProcessCombinatorStack(); // 0x000000018246BE60-0x000000018246C190
		private Expression ParseTerm(StyleSyntaxTokenizer tokenizer); // 0x000000018246BAF0-0x000000018246BCB0
		private ExpressionCombinator ParseCombinatorType(StyleSyntaxTokenizer tokenizer); // 0x0000000182469BC0-0x0000000182469E40
		private Expression ParseGroup(StyleSyntaxTokenizer tokenizer); // 0x000000018246A910-0x000000018246ACC0
		private Expression ParseDataType(StyleSyntaxTokenizer tokenizer); // 0x0000000182469E40-0x000000018246A620
		private Expression ParseNonTerminalValue(string syntax); // 0x000000018246B2C0-0x000000018246B470
		private Expression ParseProperty(StyleSyntaxTokenizer tokenizer); // 0x000000018246B470-0x000000018246B930
		private void ParseMultiplier(StyleSyntaxTokenizer tokenizer, ref ExpressionMultiplier multiplier); // 0x000000018246AFB0-0x000000018246B2C0
		private void ParseLimits(StyleSyntaxTokenizer tokenizer, out float min, out float max); // 0x000000018246ACC0-0x000000018246AFB0
		private void ParseRanges(StyleSyntaxTokenizer tokenizer, out int min, out int max); // 0x000000018246B930-0x000000018246BAF0
		private static void EatSpace(StyleSyntaxTokenizer tokenizer); // 0x0000000182469AD0-0x0000000182469B60
		private static bool IsExpressionEnd(StyleSyntaxToken token); // 0x0000000182469B80-0x0000000182469BA0
		private static bool IsCombinator(StyleSyntaxToken token); // 0x0000000182469B60-0x0000000182469B80
		private static bool IsMultiplier(StyleSyntaxToken token); // 0x0000000182469BA0-0x0000000182469BC0
	}
}
