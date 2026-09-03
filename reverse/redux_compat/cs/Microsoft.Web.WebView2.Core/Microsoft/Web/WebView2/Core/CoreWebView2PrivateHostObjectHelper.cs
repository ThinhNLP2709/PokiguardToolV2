/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class CoreWebView2PrivateHostObjectHelper // TypeDefIndex: 10581
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2PrivateHostObjectHelper _nativeICoreWebView2PrivateHostObjectHelperValue; // 0x18
		internal ICoreWebView2PrivateHostObjectHelper2 _nativeICoreWebView2PrivateHostObjectHelper2Value; // 0x20
		internal ICoreWebView2PrivateHostObjectHelper3 _nativeICoreWebView2PrivateHostObjectHelper3Value; // 0x28
	
		// Properties
		internal ICoreWebView2PrivateHostObjectHelper _nativeICoreWebView2PrivateHostObjectHelper { get; set; } // 0x00000001813C01B0-0x00000001813C02C0 0x00000001802FAF70-0x00000001802FAF80
		internal ICoreWebView2PrivateHostObjectHelper2 _nativeICoreWebView2PrivateHostObjectHelper2 { get; set; } // 0x00000001813BFF90-0x00000001813C00A0 0x000000018033E830-0x000000018033E840
		internal ICoreWebView2PrivateHostObjectHelper3 _nativeICoreWebView2PrivateHostObjectHelper3 { get; set; } // 0x00000001813C00A0-0x00000001813C01B0 0x000000018033E840-0x000000018033E850
	
		// Nested types
		private class RawHelper : ICoreWebView2PrivateHostObjectHelper, ICoreWebView2PrivateHostObjectHelper2, ICoreWebView2PrivateHostObjectHelper3 // TypeDefIndex: 10582
		{
			// Fields
			private const int DISP_E_MEMBERNOTFOUND = -2147352573; // Metadata: 0x006A1502
			private const int DISP_E_TYPEMISMATCH = -2147352571; // Metadata: 0x006A1507
			private const int WIN_BOOL_TRUE = 1; // Metadata: 0x006A150C
			private const int WIN_BOOL_FALSE = 0; // Metadata: 0x006A150D
			private const int S_OK = 0; // Metadata: 0x006A150E
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass10_0 // TypeDefIndex: 10583
			{
				// Fields
				public AwaitableReflection ar; // 0x10
				public object awaiter; // 0x18
				public ICoreWebView2PrivateHostObjectAsyncMethodContinuation continuation; // 0x20
	
				// Constructors
				public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _SetAsyncMethodContinuation_b__0(); // 0x00000001813C6CD0-0x00000001813C6FF0
			}
	
			// Constructors
			public RawHelper(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			private MethodInfo GetMethodInfo(Type type, string methodName, int? parameterCount); // 0x00000001813C5930-0x00000001813C5B00
			public int IsMethodMember(ref object rawObject, string memberName); // 0x00000001813C5C10-0x00000001813C5C70
			public object CreateBuiltInDispatch(ref object originalHostObject); // 0x00000001813C58D0-0x00000001813C5930
			public int IsAsyncMethod(ref object rawObject, string methodName, int parameterCount); // 0x00000001813C5B00-0x00000001813C5C10
			public void SetAsyncMethodContinuation(ref object rawObject, string methodName, int parameterCount, ref object methodResult, ICoreWebView2PrivateHostObjectAsyncMethodContinuation continuation); // 0x00000001813C5C70-0x00000001813C62A0
		}
	
		private class AwaitableReflection // TypeDefIndex: 10584
		{
			// Fields
			private Type _awaitable; // 0x10
			private MethodInfo _getAwaiter; // 0x18
			private Type _awaiter; // 0x20
			private PropertyInfo _isCompleted; // 0x28
			private MethodInfo _onCompleted; // 0x30
			private MethodInfo _getResult; // 0x38
	
			// Constructors
			private AwaitableReflection(Type awaitable, MethodInfo getAwaiter, Type awaiter, PropertyInfo isCompleted, MethodInfo onCompleted, MethodInfo getResult); // 0x00000001813A6390-0x00000001813A6440
	
			// Methods
			public static AwaitableReflection FromAwaitableType(Type type); // 0x00000001813A5A40-0x00000001813A5D90
			public object InvokeGetAwaiter(object awaitable); // 0x00000001813A5D90-0x00000001813A5F10
			public bool InvokeIsCompleted(object awaiter); // 0x00000001813A6090-0x00000001813A61E0
			public void InvokeOnCompleted(object awaiter, Action continuation); // 0x00000001813A61E0-0x00000001813A6390
			public object InvokeGetResult(object awaiter); // 0x00000001813A5F10-0x00000001813A6090
		}
	
		// Constructors
		internal CoreWebView2PrivateHostObjectHelper(object rawCoreWebView2PrivateHostObjectHelper); // 0x00000001803855F0-0x0000000180385630
		internal CoreWebView2PrivateHostObjectHelper(); // 0x00000001813BFF20-0x00000001813BFF90
	
		// Methods
		internal int IsMethodMember(object rawObject, string memberName); // 0x00000001813BFAE0-0x00000001813BFCD0
		internal int IsAsyncMethod(object rawObject, string methodName, int parameterCount); // 0x00000001813BF8E0-0x00000001813BFAE0
		internal void SetAsyncMethodContinuation(object rawObject, string methodName, int parameterCount, object methodResult, CoreWebView2PrivateHostObjectAsyncMethodContinuation continuation); // 0x00000001813BFCD0-0x00000001813BFF20
		internal object CreateBuiltInDispatch(object originalHostObject); // 0x00000001813BF700-0x00000001813BF8E0
	}
}
