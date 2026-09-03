/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public class ReflectionValueProvider : IValueProvider // TypeDefIndex: 10256
	{
		// Fields
		private readonly MemberInfo _memberInfo; // 0x10
	
		// Constructors
		public ReflectionValueProvider(MemberInfo memberInfo); // 0x0000000181735420-0x0000000181735490
	
		// Methods
		public void SetValue(object target, [Nullable(2)] object value); // 0x00000001817352D0-0x0000000181735420
		public object GetValue(object target); // 0x0000000181735080-0x00000001817352D0
	}
}
