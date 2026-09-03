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
using UnityEngine.UIElements.StyleSheets.Syntax;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	internal class StylePropertyValueMatcher : BaseStyleMatcher // TypeDefIndex: 5260
	{
		// Fields
		private List<StylePropertyValue> m_Values; // 0x20
	
		// Properties
		private StylePropertyValue current { get; } // 0x0000000182467640-0x00000001824676B0 
		public override int valueCount { get; } // 0x0000000180634EF0-0x0000000180634F10 
		public override bool isCurrentVariable { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool isCurrentComma { get; } // 0x00000001824676B0-0x0000000182467720 
	
		// Constructors
		public StylePropertyValueMatcher(); // 0x0000000182467590-0x0000000182467640
	
		// Methods
		public MatchResult Match(Expression exp, List<StylePropertyValue> values); // 0x0000000182467340-0x0000000182467590
		protected override bool MatchKeyword(string keyword); // 0x0000000182466E00-0x0000000182466ED0
		protected override bool MatchNumber(Expression exp); // 0x0000000182466FE0-0x00000001824670A0
		protected override bool MatchInteger(); // 0x0000000182466D90-0x0000000182466E00
		protected override bool MatchLength(); // 0x0000000182466ED0-0x0000000182466FD0
		protected override bool MatchPercentage(); // 0x00000001824670A0-0x00000001824671A0
		protected override bool MatchColor(); // 0x0000000182466890-0x00000001824669F0
		protected override bool MatchResource(); // 0x00000001824671B0-0x0000000182467220
		protected override bool MatchUrl(); // 0x00000001824672C0-0x0000000182467340
		protected override bool MatchTime(); // 0x0000000182467220-0x00000001824672C0
		protected override bool MatchFilterFunction(); // 0x0000000182466B00-0x0000000182466C30
		protected override bool MatchLinearGradient(); // 0x0000000182466FD0-0x0000000182466FE0
		protected override bool MatchRadialGradient(); // 0x00000001824671A0-0x00000001824671B0
		private bool MatchGradientFunction(StyleValueFunction expected); // 0x0000000182466C30-0x0000000182466D90
		protected override bool MatchMaterialPropertyValue(); // 0x0000000182466B00-0x0000000182466C30
		protected override bool MatchCustomIdent(); // 0x00000001824669F0-0x0000000182466B00
		protected override bool MatchAngle(); // 0x0000000182466780-0x0000000182466890
	}
}
