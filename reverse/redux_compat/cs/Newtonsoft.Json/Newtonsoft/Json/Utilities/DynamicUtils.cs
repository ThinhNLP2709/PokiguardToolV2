/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class DynamicUtils // TypeDefIndex: 10132
	{
		// Nested types
		[Nullable(0)]
		internal static class BinderWrapper // TypeDefIndex: 10133
		{
			// Fields
			public const string CSharpAssemblyName = "Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"; // Metadata: 0x006A06EF
			private const string BinderTypeName = "Microsoft.CSharp.RuntimeBinder.Binder, Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"; // Metadata: 0x006A0744
			private const string CSharpArgumentInfoTypeName = "Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo, Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"; // Metadata: 0x006A07C0
			private const string CSharpArgumentInfoFlagsTypeName = "Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfoFlags, Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"; // Metadata: 0x006A0848
			private const string CSharpBinderFlagsTypeName = "Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags, Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"; // Metadata: 0x006A08D5
			[Nullable(2)]
			private static object _getCSharpArgumentInfoArray; // 0x00
			[Nullable(2)]
			private static object _setCSharpArgumentInfoArray; // 0x08
			[Nullable(2)]
			private static MethodCall<object, object> _getMemberCall; // 0x10
			[Nullable(2)]
			private static MethodCall<object, object> _setMemberCall; // 0x18
			private static bool _init; // 0x20
	
			// Methods
			private static void Init(); // 0x00000001816E3530-0x00000001816E3740
			private static object CreateSharpArgumentInfoArray(params int[] values); // 0x00000001816E3020-0x00000001816E32E0
			private static void CreateMemberCalls(); // 0x00000001816E2A80-0x00000001816E3020
			public static CallSiteBinder GetMember(string name, Type context); // 0x00000001816E32E0-0x00000001816E3530
			public static CallSiteBinder SetMember(string name, Type context); // 0x00000001816E3740-0x00000001816E39A0
		}
	
		// Extension methods
		public static IEnumerable<string> GetDynamicMemberNames(this IDynamicMetaObjectProvider dynamicProvider); // 0x00000001816EDB90-0x00000001816EDC90
	}
}
