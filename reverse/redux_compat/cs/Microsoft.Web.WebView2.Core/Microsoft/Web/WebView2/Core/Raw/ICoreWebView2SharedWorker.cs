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
	[Guid("BCD39C8D-48BB-5F1B-BE22-89F9C0C4484A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2SharedWorker // TypeDefIndex: 11122
	{
		// Properties
		[DispId(1610678272)]
		string Origin { get; } // 0x00000001813F6EB0-0x00000001813F6F20 
		[DispId(1610678273)]
		string ScriptUri { get; } // 0x00000001813F6DD0-0x00000001813F6E40 
		[DispId(1610678274)]
		string TopLevelOrigin { get; } // 0x00000001813F6E40-0x00000001813F6EB0 
	
		// Methods
		void add_Destroying(in ICoreWebView2SharedWorkerDestroyingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F6D30-0x00000001813F6DD0
		void remove_Destroying(in EventRegistrationToken token); // 0x00000001813F6F20-0x00000001813F6F60
	}
}
