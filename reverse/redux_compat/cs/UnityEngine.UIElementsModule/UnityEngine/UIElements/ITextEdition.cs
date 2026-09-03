/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public interface ITextEdition // TypeDefIndex: 4853
	{
		// Properties
		bool multiline { get; set; }
		bool isReadOnly { get; set; }
		int maxLength { get; set; }
		string placeholder { get; set; }
		bool isDelayed { get; set; }
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		Func<char, bool> AcceptCharacter { get; set; }
		Action<bool> UpdateScrollOffset { get; set; }
		Action UpdateValueFromText { get; set; }
		Action UpdateTextFromValue { get; set; }
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		Action MoveFocusToCompositeRoot { get; set; }
		Func<string> GetDefaultValueType { get; set; }
		char maskChar { get; set; }
		bool isPassword { get; set; }
		bool hidePlaceholderOnFocus { get; set; }
		bool autoCorrection { get; set; } // 0x00000001823CE6B0-0x00000001823CE760 0x00000001823CEA20-0x00000001823CEAD0
		bool hideSoftKeyboard { get; set; } // 0x00000001823CE810-0x00000001823CE8C0 0x00000001823CEB80-0x00000001823CEC30
		bool hideMobileInput { get; set; } // 0x00000001823CE760-0x00000001823CE810 0x00000001823CEAD0-0x00000001823CEB80
		TouchScreenKeyboard touchScreenKeyboard { get; } // 0x00000001823CE970-0x00000001823CEA20 
		TouchScreenKeyboardType keyboardType { get; set; } // 0x00000001823CE8C0-0x00000001823CE970 0x00000001823CEC30-0x00000001823CECE0
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		void SaveValueAndText();
		void RestoreValueAndText();
		void UpdateText(string value);
		string CullString(string s);
	}
}
