/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	[Serializable]
	public class AdaptivePerformanceScalerProfile : AdaptivePerformanceScalerSettings // TypeDefIndex: 14186
	{
		// Fields
		[SerializeField]
		private List<AdaptivePerformanceScaler> m_AddedScalers; // 0x98
		[SerializeField]
		[Tooltip("Name of the scaler profile.")]
		private string m_Name; // 0xA0
	
		// Properties
		public string Name { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public List<AdaptivePerformanceScaler> AddedScalers { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public AdaptivePerformanceScalerProfile(); // 0x000000018213BDB0-0x000000018213BE80
	
		// Methods
		internal void EnableAddedScalers(); // 0x000000018213BB20-0x000000018213BC80
		internal void RemoveAllAddedScalersFromIndexer(); // 0x000000018213BC80-0x000000018213BDB0
	}
}
