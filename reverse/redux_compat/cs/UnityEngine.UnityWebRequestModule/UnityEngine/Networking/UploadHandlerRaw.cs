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
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandlerRaw.h")]
	public sealed class UploadHandlerRaw : UploadHandler // TypeDefIndex: 15336
	{
		// Fields
		private NativeArray<byte> m_Payload; // 0x18
	
		// Constructors
		public UploadHandlerRaw(byte[] data); // 0x00000001825CF740-0x00000001825CF820
		public UploadHandlerRaw(NativeArray<byte> data, bool transferOwnership); // 0x00000001825CF820-0x00000001825CF8C0
	
		// Methods
		private static unsafe IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] UploadHandlerRaw self, byte* data, int dataLength); // 0x00000001825CF650-0x00000001825CF6B0
		public override void Dispose(); // 0x00000001825CF6B0-0x00000001825CF740
	}
}
