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

// Image 70: UnityEngine.UnityWebRequestTextureModule.dll - Assembly: UnityEngine.UnityWebRequestTextureModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15854-15861

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequestTexture/Public/DownloadHandlerTexture.h")]
	public sealed class DownloadHandlerTexture : DownloadHandler // TypeDefIndex: 15859
	{
		// Fields
		private NativeArray<byte> m_NativeData; // 0x18
	
		// Properties
		public Texture2D texture { get; } // 0x00000001825D1690-0x00000001825D1790 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15860
		{
			// Methods
			public static IntPtr ConvertToNative(DownloadHandlerTexture handler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public DownloadHandlerTexture(bool readable); // 0x00000001825D1790-0x00000001825D1820
	
		// Methods
		private static IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] DownloadHandlerTexture obj, DownloadedTextureParams parameters); // 0x00000001825D1440-0x00000001825D1480
		private void InternalCreateTexture(DownloadedTextureParams parameters); // 0x00000001825D1600-0x00000001825D1650
		protected override NativeArray<byte> GetNativeData(); // 0x00000001825D15D0-0x00000001825D1600
		public override void Dispose(); // 0x00000001825D1480-0x00000001825D14B0
		[NativeMethod(ThrowsException = true)]
		private Texture2D InternalGetTextureNative(); // 0x00000001825D1690-0x00000001825D1790
		public static Texture2D GetContent(UnityWebRequest www); // 0x00000001825D14B0-0x00000001825D15D0
		private static IntPtr Create_Injected(DownloadHandlerTexture obj, in DownloadedTextureParams parameters); // 0x00000001825D13F0-0x00000001825D1440
		private static IntPtr InternalGetTextureNative_Injected(IntPtr _unity_self); // 0x00000001825D1650-0x00000001825D1690
	}
}
