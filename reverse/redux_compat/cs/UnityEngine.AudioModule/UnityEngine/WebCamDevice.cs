/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine
{
	[UsedByNativeCode]
	public struct WebCamDevice // TypeDefIndex: 14921
	{
		// Fields
		[NativeName("name")]
		internal string m_Name; // 0x00
		[NativeName("depthCameraName")]
		internal string m_DepthCameraName; // 0x08
		[NativeName("flags")]
		internal int m_Flags; // 0x10
		[NativeName("kind")]
		internal WebCamKind m_Kind; // 0x14
		[NativeName("resolutions")]
		internal Resolution[] m_Resolutions; // 0x18
	
		// Methods
		[RequiredByNativeCode]
		private static void ReconstructArrayElementRaw(WebCamDevice[] array, int i, object name, object depthCameraName, int flags, WebCamKind kind, Resolution[] resolutions); // 0x000000018216D770-0x000000018216D8E0
	}
}
