/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets.Syntax;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	internal abstract class BaseStyleMatcher // TypeDefIndex: 5258
	{
		// Fields
		protected static readonly Regex s_CustomIdentRegex; // 0x00
		private Stack<MatchContext> m_ContextStack; // 0x10
		private MatchContext m_CurrentContext; // 0x18
	
		// Properties
		public abstract int valueCount { get; }
		public abstract bool isCurrentVariable { get; }
		public abstract bool isCurrentComma { get; }
		public bool hasCurrent { get; } // 0x0000000182465230-0x0000000182465260 
		public int currentIndex { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int matchedVariableCount { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
	
		// Nested types
		private struct MatchContext // TypeDefIndex: 5259
		{
			// Fields
			public int valueIndex; // 0x00
			public int matchedVariableCount; // 0x04
		}
	
		// Constructors
		protected BaseStyleMatcher(); // 0x00000001824651B0-0x0000000182465230
		static BaseStyleMatcher(); // 0x0000000182465120-0x00000001824651B0
	
		// Methods
		protected abstract bool MatchKeyword(string keyword);
		protected abstract bool MatchNumber(Expression exp);
		protected abstract bool MatchInteger();
		protected abstract bool MatchLength();
		protected abstract bool MatchPercentage();
		protected abstract bool MatchColor();
		protected abstract bool MatchResource();
		protected abstract bool MatchUrl();
		protected abstract bool MatchTime();
		protected abstract bool MatchFilterFunction();
		protected abstract bool MatchMaterialPropertyValue();
		protected abstract bool MatchAngle();
		protected abstract bool MatchCustomIdent();
		protected abstract bool MatchLinearGradient();
		protected abstract bool MatchRadialGradient();
		protected void Initialize(); // 0x00000001824640A0-0x00000001824640D0
		public void MoveNext(); // 0x0000000182465040-0x0000000182465080
		public void SaveContext(); // 0x00000001824650D0-0x0000000182465120
		public void RestoreContext(); // 0x0000000182465080-0x00000001824650D0
		public void DropContext(); // 0x0000000182464050-0x00000001824640A0
		protected bool Match(Expression exp); // 0x0000000182464EB0-0x0000000182465040
		private bool MatchExpression(Expression exp); // 0x00000001824647C0-0x00000001824648D0
		private bool MatchExpressionWithMultiplier(Expression exp); // 0x00000001824646A0-0x00000001824647C0
		private bool MatchGroup(Expression exp); // 0x00000001824648D0-0x0000000182464990
		private bool MatchCombinator(Expression exp); // 0x0000000182464150-0x00000001824644B0
		private bool MatchOr(Expression exp); // 0x0000000182464D90-0x0000000182464EB0
		private bool MatchOrOr(Expression exp); // 0x0000000182464D70-0x0000000182464D90
		private bool MatchAndAnd(Expression exp); // 0x00000001824640D0-0x0000000182464150
		private int MatchMany(Expression exp); // 0x0000000182464BC0-0x0000000182464D70
		private unsafe int MatchManyByOrder(Expression exp, int* matchOrder); // 0x0000000182464A10-0x0000000182464BC0
		private bool MatchJuxtaposition(Expression exp); // 0x0000000182464990-0x0000000182464A10
		private bool MatchDataType(Expression exp); // 0x00000001824644B0-0x00000001824646A0
	}
}
