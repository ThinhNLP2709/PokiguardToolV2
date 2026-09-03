/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("A0D6DF20-3B92-416D-AA0C-437A9C727857")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_3 : ICoreWebView2_2 // TypeDefIndex: 11171
	{
		// Properties
		[DispId(1610809346)]
		int IsSuspended { get; } // 0x00000001813FA440-0x00000001813FA490 
	
		// Methods
		void _VtblGap1_65();
		void TrySuspend(in ICoreWebView2TrySuspendCompletedHandler handler); // 0x00000001813FA3B0-0x00000001813FA440
		void Resume(); // 0x00000001813FA300-0x00000001813FA340
		void SetVirtualHostNameToFolderMapping(in string hostName, in string folderPath, in COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind); // 0x00000001813FA340-0x00000001813FA3B0
		void ClearVirtualHostNameToFolderMapping(in string hostName); // 0x00000001813FA2B0-0x00000001813FA300
	}
}
