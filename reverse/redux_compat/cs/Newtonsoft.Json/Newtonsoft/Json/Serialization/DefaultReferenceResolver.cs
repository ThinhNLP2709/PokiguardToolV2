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
	[Nullable(0)]
	[NullableContext(1)]
	internal class DefaultReferenceResolver : IReferenceResolver // TypeDefIndex: 10207
	{
		// Fields
		private int _referenceCount; // 0x10
	
		// Constructors
		public DefaultReferenceResolver(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private BidirectionalDictionary<string, object> GetMappings(object context); // 0x00000001817060E0-0x0000000181706340
		public object ResolveReference(object context, string reference); // 0x00000001817064A0-0x0000000181706530
		public string GetReference(object context, object value); // 0x0000000181706340-0x0000000181706420
		public void AddReference(object context, string reference, object value); // 0x0000000181706060-0x00000001817060E0
		public bool IsReferenced(object context, object value); // 0x0000000181706420-0x00000001817064A0
	}
}
