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
	[Serializable]
	public struct FilterParameterDeclaration // TypeDefIndex: 4150
	{
		// Fields
		[DontCreateProperty]
		[SerializeField]
		private string m_Name; // 0x00
		[DontCreateProperty]
		[SerializeField]
		private FilterParameter m_InterpolationDefaultValue; // 0x08
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal FilterParameter defaultValue; // 0x20
	
		// Properties
		[CreateProperty]
		public string name { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		[CreateProperty]
		public FilterParameter interpolationDefaultValue { get; set; } // 0x0000000180C57200-0x0000000180C57220 0x0000000182495030-0x0000000182495050
	}
}
