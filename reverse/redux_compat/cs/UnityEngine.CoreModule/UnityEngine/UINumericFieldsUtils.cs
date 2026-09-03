/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[VisibleToOtherModules(new string[3] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class UINumericFieldsUtils // TypeDefIndex: 7834
	{
		// Fields
		public static readonly string k_AllowedCharactersForFloat; // 0x00
		public static readonly string k_AllowedCharactersForFloat_NoExpressions; // 0x08
		public static readonly string k_AllowedCharactersForInt; // 0x10
		public static readonly string k_AllowedCharactersForInt_NoExpressions; // 0x18
		public static readonly string k_AllowedCharactersForUInt_NoExpressions; // 0x20
		public static readonly string k_DoubleFieldFormatString; // 0x28
		public static readonly string k_FloatFieldFormatString; // 0x30
		public static readonly string k_IntFieldFormatString; // 0x38
	
		// Constructors
		static UINumericFieldsUtils(); // 0x00000001822274E0-0x0000000182227720
	
		// Methods
		public static bool TryConvertStringToDouble(string str, out double value, out ExpressionEvaluator.Expression expr); // 0x0000000182227110-0x00000001822272A0
		public static bool TryConvertStringToDouble(string str, string initialValueAsString, out double value, out ExpressionEvaluator.Expression expression); // 0x00000001822272A0-0x0000000182227390
		public static bool TryConvertStringToFloat(string str, string initialValueAsString, out float value, out ExpressionEvaluator.Expression expression); // 0x0000000182227390-0x00000001822274E0
	}
}
