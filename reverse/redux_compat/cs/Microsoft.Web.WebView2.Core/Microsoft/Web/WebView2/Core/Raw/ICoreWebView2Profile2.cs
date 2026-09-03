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
	[Guid("FA740D4B-5EAE-4344-A8AD-74BE31925397")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile2 : ICoreWebView2Profile // TypeDefIndex: 11076
	{
		// Methods
		void _VtblGap1_7();
		void ClearBrowsingData(in COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, in ICoreWebView2ClearBrowsingDataCompletedHandler handler); // 0x00000001813F27C0-0x00000001813F2860
		void ClearBrowsingDataInTimeRange(in COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, in double startTime, in double endTime, in ICoreWebView2ClearBrowsingDataCompletedHandler handler); // 0x00000001813F2700-0x00000001813F27C0
		void ClearBrowsingDataAll(in ICoreWebView2ClearBrowsingDataCompletedHandler handler); // 0x00000001813F2670-0x00000001813F2700
	}
}
