/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	public class ReflectionAttributeProvider : IAttributeProvider // TypeDefIndex: 10255
	{
		// Fields
		private readonly object _attributeProvider; // 0x10
	
		// Constructors
		public ReflectionAttributeProvider(object attributeProvider); // 0x0000000181735010-0x0000000181735080
	
		// Methods
		public IList<Attribute> GetAttributes(bool inherit); // 0x0000000181734FB0-0x0000000181735010
		public IList<Attribute> GetAttributes(Type attributeType, bool inherit); // 0x0000000181734F40-0x0000000181734FB0
	}
}
