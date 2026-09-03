/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 70: UnityEngine.UnityWebRequestTextureModule.dll - Assembly: UnityEngine.UnityWebRequestTextureModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15854-15861

namespace UnityEngine.Networking
{
	public struct DownloadedTextureParams // TypeDefIndex: 15858
	{
		// Fields
		public DownloadedTextureFlags flags; // 0x00
		public int mipmapCount; // 0x04
	
		// Properties
		public static DownloadedTextureParams Default { get; } // 0x00000001825D1820-0x00000001825D1840 
		public bool readable { set; } // 0x00000001825D1840-0x00000001825D1860
	
		// Methods
		private void SetFlags(DownloadedTextureFlags flgs, bool add); // 0x0000000181BC0E70-0x0000000181BC0E90
	}
}
