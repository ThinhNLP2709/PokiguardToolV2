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
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.UIElements.StyleSheets.Syntax;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class StyleVariableResolver // TypeDefIndex: 4816
	{
		// Fields
		private static StyleSyntaxParser s_SyntaxParser; // 0x00
		private StylePropertyValueMatcher m_Matcher; // 0x10
		private List<StylePropertyValue> m_ResolvedValues; // 0x18
		private Stack<int> m_ResolvedVarStack; // 0x20
		private StyleProperty m_Property; // 0x28
		private Stack<ResolveContext> m_ContextStack; // 0x30
		private ResolveContext m_CurrentContext; // 0x38
		[CompilerGenerated]
		private StyleVariableContext _variableContext_k__BackingField; // 0x48
	
		// Properties
		private StyleSheet currentSheet { get; } // 0x00000001803272A0-0x00000001803272B0 
		private StyleValueHandle[] currentHandles { get; } // 0x0000000180377940-0x0000000180377950 
		public List<StylePropertyValue> resolvedValues { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public StyleVariableContext variableContext { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
	
		// Nested types
		private enum Result // TypeDefIndex: 4817
		{
			Valid = 0,
			Invalid = 1,
			NotFound = 2
		}
	
		private struct ResolveContext // TypeDefIndex: 4818
		{
			// Fields
			public StyleSheet sheet; // 0x00
			public StyleValueHandle[] handles; // 0x08
		}
	
		// Constructors
		public StyleVariableResolver(); // 0x00000001823BBDE0-0x00000001823BBF20
		static StyleVariableResolver(); // 0x00000001823BBD60-0x00000001823BBDE0
	
		// Methods
		public void Init(StyleProperty property, StyleSheet sheet, StyleValueHandle[] handles); // 0x00000001823BAFA0-0x00000001823BB040
		private void PushContext(StyleSheet sheet, StyleValueHandle[] handles); // 0x00000001823BB170-0x00000001823BB220
		private void PopContext(); // 0x00000001823BB0E0-0x00000001823BB170
		public void AddValue(StyleValueHandle handle); // 0x00000001823BAE80-0x00000001823BAFA0
		public bool ResolveVarFunction(ref int index); // 0x00000001823BB630-0x00000001823BB830
		private Result ResolveVarFunction(ref int index, int argc, int varNameId); // 0x00000001823BB4F0-0x00000001823BB630
		public bool ValidateResolvedValues(); // 0x00000001823BBBC0-0x00000001823BBD60
		private Result ResolveVariable(int variableNameId); // 0x00000001823BB830-0x00000001823BBBC0
		private Result ResolveFallback(ref int index, bool appendValues); // 0x00000001823BB220-0x00000001823BB4F0
		private static void ParseVarFunction(StyleSheet sheet, StyleValueHandle[] handles, ref int index, out int argCount, out int variableNameId); // 0x00000001823BB040-0x00000001823BB0E0
	}
}
