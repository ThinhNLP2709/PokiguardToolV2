/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "Volume", Order = 0)]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class URPDefaultVolumeProfileSettings : IDefaultVolumeProfileSettings // TypeDefIndex: 9772
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[SerializeField]
		private VolumeProfile m_VolumeProfile; // 0x18
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public VolumeProfile volumeProfile { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FF4460-0x0000000181FF44D0
	
		// Nested types
		internal enum Version // TypeDefIndex: 9773
		{
			Initial = 0
		}
	
		// Constructors
		public URPDefaultVolumeProfileSettings(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
