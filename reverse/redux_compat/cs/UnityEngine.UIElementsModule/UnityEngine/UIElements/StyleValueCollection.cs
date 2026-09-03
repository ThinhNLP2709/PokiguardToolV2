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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class StyleValueCollection // TypeDefIndex: 4631
	{
		// Fields
		internal List<StyleValue> m_Values; // 0x10
	
		// Constructors
		public StyleValueCollection(); // 0x0000000182546BC0-0x0000000182546C40
	
		// Methods
		public StyleLength GetStyleLength(StylePropertyId id); // 0x00000001825467F0-0x0000000182546880
		public StyleFloat GetStyleFloat(StylePropertyId id); // 0x0000000182546710-0x0000000182546780
		public StyleInt GetStyleInt(StylePropertyId id); // 0x0000000182546780-0x00000001825467F0
		public StyleColor GetStyleColor(StylePropertyId id); // 0x0000000182546670-0x0000000182546710
		public StyleBackgroundPosition GetStyleBackgroundPosition(StylePropertyId id); // 0x0000000182546560-0x00000001825465F0
		public StyleBackgroundRepeat GetStyleBackgroundRepeat(StylePropertyId id); // 0x00000001825465F0-0x0000000182546670
		public StyleRatio GetStyleRatio(StylePropertyId id); // 0x0000000182546880-0x00000001825468F0
		public bool TryGetStyleValue(StylePropertyId id, ref StyleValue value); // 0x0000000182546AB0-0x0000000182546BC0
		public void SetStyleValue(StyleValue value); // 0x00000001825468F0-0x0000000182546AB0
	}
}
