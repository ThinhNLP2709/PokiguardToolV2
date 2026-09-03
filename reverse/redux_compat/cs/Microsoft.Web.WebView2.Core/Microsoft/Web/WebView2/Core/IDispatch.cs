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

namespace Microsoft.Web.WebView2.Core
{
	[ComImport]
	[Guid("00020400-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IDispatch // TypeDefIndex: 10807
	{
		// Methods
		int GetTypeInfoCount(out int Count); // 0x00000001813FC830-0x00000001813FC860
		int GetTypeInfo(int iTInfo, int lcid, out ITypeInfo typeInfo); // 0x00000001813FC860-0x00000001813FC920
		int GetIDsOfNames(ref Guid riid, string[] rgsNames, int cNames, int lcid, int[] rgDispId); // 0x00000001813FC710-0x00000001813FC830
		int Invoke(int dispIdMember, ref Guid riid, uint lcid, ushort wFlags, ref DISPPARAMS pDispParams, out object pVarResult, ref EXCEPINFO pExcepInfo, out uint pArgErr); // 0x00000001813FC920-0x00000001813FCAC0
	}
}
