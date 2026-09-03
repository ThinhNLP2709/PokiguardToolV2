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
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerVFS.h")]
	public sealed class DownloadHandlerFile : DownloadHandler // TypeDefIndex: 15326
	{
		// Constructors
		public DownloadHandlerFile(string path, bool append); // 0x00000001825CB7B0-0x00000001825CB860
	
		// Methods
		[NativeMethod(ThrowsException = true)]
		private static IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] DownloadHandlerFile obj, string path, bool append); // 0x00000001825CB4B0-0x00000001825CB620
		private void InternalCreateVFS(string path, bool append); // 0x00000001825CB710-0x00000001825CB7B0
		protected override NativeArray<byte> GetNativeData(); // 0x00000001825CB670-0x00000001825CB6C0
		protected override byte[] GetData(); // 0x00000001825CB620-0x00000001825CB670
		protected override string GetText(); // 0x00000001825CB6C0-0x00000001825CB710
		private static IntPtr Create_Injected(DownloadHandlerFile obj, ref ManagedSpanWrapper path, bool append); // 0x00000001825CB450-0x00000001825CB4B0
	}
}
