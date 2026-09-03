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
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq.JsonPath
{
	[Nullable(0)]
	[NullableContext(1)]
	internal abstract class QueryExpression // TypeDefIndex: 10359
	{
		// Fields
		internal QueryOperator Operator; // 0x10
	
		// Constructors
		public QueryExpression(QueryOperator @operator); // 0x00000001802F9040-0x00000001802F9070
	
		// Methods
		public bool IsMatch(JToken root, JToken t); // 0x000000018176A150-0x000000018176A180
		public abstract bool IsMatch(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings);
	}
}
