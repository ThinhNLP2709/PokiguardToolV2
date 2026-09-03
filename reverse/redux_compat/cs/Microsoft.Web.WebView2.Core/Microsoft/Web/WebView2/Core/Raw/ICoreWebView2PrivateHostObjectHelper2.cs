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
	[Guid("A791A659-3AD9-41C3-9C7E-768FCC233666")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrivateHostObjectHelper2 // TypeDefIndex: 11057
	{
		// Methods
		int IsAsyncMethod(in object @object, in string methodName, in int parameterCount); // 0x00000001813F1470-0x00000001813F1510
		void SetAsyncMethodContinuation(in object @object, in string methodName, in int parameterCount, in object methodResult, in ICoreWebView2PrivateHostObjectAsyncMethodContinuation continuation); // 0x00000001813F1510-0x00000001813F1630
	}
}
