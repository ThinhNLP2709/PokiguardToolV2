/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	[HelpURL("ui-systems/custom-filters")]
	public sealed class FilterFunctionDefinition : ScriptableObject // TypeDefIndex: 4151
	{
		// Fields
		[DontCreateProperty]
		[SerializeField]
		private string m_FilterName; // 0x18
		[DontCreateProperty]
		[SerializeField]
		private FilterParameterDeclaration[] m_Parameters; // 0x20
		[DontCreateProperty]
		[SerializeField]
		private PostProcessingPass[] m_Passes; // 0x28
	
		// Properties
		[CreateProperty]
		public string filterName { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		[CreateProperty]
		public FilterParameterDeclaration[] parameters { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		[CreateProperty]
		public PostProcessingPass[] passes { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
		// Constructors
		public FilterFunctionDefinition(); // 0x0000000182494F50-0x0000000182495030
	}
}
