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
	[Guid("7C367B9B-3D2B-450F-9E58-D61A20F486AA")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2CompositionController4 : ICoreWebView2CompositionController3 // TypeDefIndex: 10903
	{
		// Methods
		void _VtblGap1_13();
		COREWEBVIEW2_NON_CLIENT_REGION_KIND GetNonClientRegionAtPoint(in tagPOINT point); // 0x00000001813E29C0-0x00000001813E2A10
		ICoreWebView2RegionRectCollectionView QueryNonClientRegion(in COREWEBVIEW2_NON_CLIENT_REGION_KIND Kind); // 0x00000001813E2A10-0x00000001813E2AB0
		void add_NonClientRegionChanged(in ICoreWebView2NonClientRegionChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E2AB0-0x00000001813E2B50
		void remove_NonClientRegionChanged(in EventRegistrationToken token); // 0x00000001813E2B50-0x00000001813E2B90
	}
}
