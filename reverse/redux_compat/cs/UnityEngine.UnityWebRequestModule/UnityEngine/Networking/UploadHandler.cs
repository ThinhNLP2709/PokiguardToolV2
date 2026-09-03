/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandler.h")]
	public class UploadHandler : IDisposable // TypeDefIndex: 15334
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15335
		{
			// Methods
			public static IntPtr ConvertToNative(UploadHandler uploadHandler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		internal UploadHandler(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting(); // 0x00000001825CF950-0x00000001825CF9B0
		~UploadHandler(); // 0x00000001825CB920-0x00000001825CB9A0
		public virtual void Dispose(); // 0x00000001825CF8C0-0x00000001825CF910
		private static void ReleaseFromScripting_Injected(IntPtr _unity_self); // 0x00000001825CF910-0x00000001825CF950
	}
}
