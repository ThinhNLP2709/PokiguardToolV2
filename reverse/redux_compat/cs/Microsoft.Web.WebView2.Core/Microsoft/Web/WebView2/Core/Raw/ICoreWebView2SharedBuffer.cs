/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("B747A495-0C6F-449E-97B8-2F81E9D6AB43")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2SharedBuffer // TypeDefIndex: 11121
	{
		// Properties
		[DispId(1610678272)]
		ulong Size { get; } // 0x00000001813F67F0-0x00000001813F6840 
		[DispId(1610678273)]
		IntPtr Buffer { get; } // 0x00000001813F6750-0x00000001813F67A0 
		[DispId(1610678275)]
		IntPtr FileMappingHandle { get; } // 0x00000001813F67A0-0x00000001813F67F0 
	
		// Methods
		IStream OpenStream(); // 0x00000001813F66C0-0x00000001813F6750
		void Close(); // 0x00000001813F6690-0x00000001813F66C0
	}
}
