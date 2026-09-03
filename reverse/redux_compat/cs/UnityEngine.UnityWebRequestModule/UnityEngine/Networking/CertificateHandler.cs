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

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
	public class CertificateHandler // TypeDefIndex: 15321
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15322
		{
			// Methods
			public static IntPtr ConvertToNative(CertificateHandler handler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting(); // 0x00000001825CB200-0x00000001825CB260
		protected virtual bool ValidateCertificate(byte[] certificateData); // 0x00000001802E7840-0x00000001802E7850
		[RequiredByNativeCode]
		internal bool ValidateCertificateNative(byte[] certificateData); // 0x00000001825CB260-0x00000001825CB280
		public void Dispose(); // 0x00000001825CB170-0x00000001825CB1C0
		private static void ReleaseFromScripting_Injected(IntPtr _unity_self); // 0x00000001825CB1C0-0x00000001825CB200
	}
}
