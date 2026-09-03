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
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	internal static class CachedAttributeGetter<T> // TypeDefIndex: 10191
		where T : Attribute
	{
		// Fields
		[Nullable(new byte[3] {1, 1, 2 })]
		private static readonly ThreadSafeStore<object, T> TypeAttributeCache;
	
		// Constructors
		static CachedAttributeGetter();
	
		// Methods
		[NullableContext(1)]
		public static T GetAttribute(object type);
	}
}
