/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerBuffer.h")]
	public sealed class DownloadHandlerBuffer : DownloadHandler // TypeDefIndex: 15325
	{
		// Fields
		private NativeArray<byte> m_NativeData; // 0x18
	
		// Constructors
		public DownloadHandlerBuffer(); // 0x00000001825CB410-0x00000001825CB450
	
		// Methods
		private static IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] DownloadHandlerBuffer obj); // 0x00000001825CB280-0x00000001825CB2C0
		private void InternalCreateBuffer(); // 0x00000001825CB3D0-0x00000001825CB410
		protected override NativeArray<byte> GetNativeData(); // 0x00000001825CB320-0x00000001825CB3D0
		public override void Dispose(); // 0x00000001825CB2C0-0x00000001825CB320
	}
}
