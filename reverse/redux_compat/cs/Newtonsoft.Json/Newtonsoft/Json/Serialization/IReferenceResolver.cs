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
	[NullableContext(1)]
	public interface IReferenceResolver // TypeDefIndex: 10214
	{
		// Methods
		object ResolveReference(object context, string reference);
		string GetReference(object context, object value);
		bool IsReferenced(object context, object value);
		void AddReference(object context, string reference, object value);
	}
}
