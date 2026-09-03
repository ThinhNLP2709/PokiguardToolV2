/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct SortingSettings : IEquatable<SortingSettings> // TypeDefIndex: 8442
	{
		// Fields
		private Matrix4x4 m_WorldToCameraMatrix; // 0x00
		private Vector3 m_CameraPosition; // 0x40
		private Vector3 m_CustomAxis; // 0x4C
		private SortingCriteria m_Criteria; // 0x58
		private DistanceMetric m_DistanceMetric; // 0x5C
	
		// Properties
		public SortingCriteria criteria { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
	
		// Constructors
		public SortingSettings(Camera camera); // 0x000000018226AB40-0x000000018226AC00
	
		// Methods
		public bool Equals(SortingSettings other); // 0x000000018226A8C0-0x000000018226A9A0
		public override bool Equals(object obj); // 0x000000018226A9A0-0x000000018226AA70
		public override int GetHashCode(); // 0x000000018226AA70-0x000000018226AB40
	}
}
