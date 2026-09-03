/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
	public class DownloadHandler : IDisposable // TypeDefIndex: 15323
	{
		// Fields
		[NonSerialized]
		[VisibleToOtherModules]
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public string error { get; } // 0x00000001825CC170-0x00000001825CC180 
		public byte[] data { get; } // 0x0000000181542050-0x0000000181542070 
		public string text { get; } // 0x0000000181624290-0x00000001816242B0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15324
		{
			// Methods
			public static IntPtr ConvertToNative(DownloadHandler handler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		[VisibleToOtherModules]
		internal DownloadHandler(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private void ReleaseFromScripting(); // 0x00000001825CC110-0x00000001825CC170
		~DownloadHandler(); // 0x00000001825CB920-0x00000001825CB9A0
		public virtual void Dispose(); // 0x00000001825CB8D0-0x00000001825CB920
		private string GetErrorMsg(); // 0x00000001825CBBC0-0x00000001825CBCB0
		protected virtual NativeArray<byte> GetNativeData(); // 0x0000000180A69580-0x0000000180A69590
		protected virtual byte[] GetData(); // 0x00000001825CBAE0-0x00000001825CBB70
		protected virtual string GetText(); // 0x00000001825CBEA0-0x00000001825CBF60
		private Encoding GetTextEncoder(); // 0x00000001825CBCB0-0x00000001825CBEA0
		private string GetContentType(); // 0x00000001825CB9F0-0x00000001825CBAE0
		[RequiredByNativeCode]
		protected virtual bool ReceiveData(byte[] data, int dataLength); // 0x00000001802E7990-0x00000001802E79A0
		[RequiredByNativeCode]
		protected virtual void ReceiveContentLengthHeader(ulong contentLength); // 0x00000001825CC0B0-0x00000001825CC0D0
		[Obsolete("Use ReceiveContentLengthHeader")]
		protected virtual void ReceiveContentLength(int contentLength); // 0x00000001802E76C0-0x00000001802E76D0
		[RequiredByNativeCode]
		private static void CompleteHeadersStatic(DownloadHandler handler); // 0x00000001825CB860-0x00000001825CB890
		internal virtual void CompleteHeaders(); // 0x00000001802E76C0-0x00000001802E76D0
		[RequiredByNativeCode]
		protected virtual void CompleteContent(); // 0x00000001802E76C0-0x00000001802E76D0
		[RequiredByNativeCode]
		protected virtual float GetProgress(); // 0x00000001807185C0-0x00000001807185D0
		protected static T GetCheckedDownloader<T>(UnityWebRequest www)
			where T : DownloadHandler;
		[NativeMethod(ThrowsException = true)]
		[VisibleToOtherModules]
		internal static unsafe byte* InternalGetByteArray(DownloadHandler dh, out int length); // 0x00000001825CBFB0-0x00000001825CC000
		internal static byte[] InternalGetByteArray(DownloadHandler dh); // 0x00000001825CBAE0-0x00000001825CBB70
		[VisibleToOtherModules(new string[2] {"UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
		internal static NativeArray<byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<byte> nativeArray); // 0x00000001825CC000-0x00000001825CC0B0
		[VisibleToOtherModules(new string[2] {"UnityEngine.UnityWebRequestAudioModule", "UnityEngine.UnityWebRequestTextureModule" })]
		internal static void DisposeNativeArray(ref NativeArray<byte> data); // 0x00000001825CB8C0-0x00000001825CB8D0
		internal static unsafe void CreateNativeArrayForNativeData(ref NativeArray<byte> data, byte* bytes, int length); // 0x00000001825CB890-0x00000001825CB8C0
		private static void ReleaseFromScripting_Injected(IntPtr _unity_self); // 0x00000001825CC0D0-0x00000001825CC110
		private static void GetErrorMsg_Injected(IntPtr _unity_self, ); // 0x00000001825CBB70-0x00000001825CBBC0
		private static void GetContentType_Injected(IntPtr _unity_self, ); // 0x00000001825CB9A0-0x00000001825CB9F0
		private static unsafe byte* InternalGetByteArray_Injected(IntPtr dh, out int length); // 0x00000001825CBF60-0x00000001825CBFB0
	}
}
