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
	[Guid("1BF89E2D-1B2B-4629-B28F-05099B41BB03")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2FrameInfoCollectionIterator // TypeDefIndex: 11000
	{
		// Properties
		[DispId(1610678272)]
		int HasCurrent { get; } // 0x00000001813EB670-0x00000001813EB6C0 
	
		// Methods
		ICoreWebView2FrameInfo GetCurrent(); // 0x00000001813EB590-0x00000001813EB620
		int MoveNext(); // 0x00000001813EB620-0x00000001813EB670
	}
}
