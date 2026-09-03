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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	internal class StyleSyntaxTokenizer // TypeDefIndex: 5270
	{
		// Fields
		private List<StyleSyntaxToken> m_Tokens; // 0x10
		private int m_CurrentTokenIndex; // 0x18
	
		// Properties
		public StyleSyntaxToken current { get; } // 0x000000018246D480-0x000000018246D510 
	
		// Constructors
		public StyleSyntaxTokenizer(); // 0x000000018246D400-0x000000018246D480
	
		// Methods
		public StyleSyntaxToken MoveNext(); // 0x000000018246C520-0x000000018246C670
		public StyleSyntaxToken PeekNext(); // 0x000000018246C670-0x000000018246C700
		public void Tokenize(string syntax); // 0x000000018246C700-0x000000018246D400
		private static bool IsNextCharacter(string s, int index, char c); // 0x000000018246C3E0-0x000000018246C420
		private static bool IsNextLetterOrDash(string s, int index); // 0x000000018246C420-0x000000018246C4C0
		private static bool IsNextNumber(string s, int index); // 0x000000018246C4C0-0x000000018246C520
		private static int GlobCharacter(string s, int index, char c); // 0x000000018246C380-0x000000018246C3E0
	}
}
