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
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq.JsonPath
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class CompositeExpression : QueryExpression // TypeDefIndex: 10360
	{
		// Fields
		[CompilerGenerated]
		private List<QueryExpression> _Expressions_k__BackingField; // 0x18
	
		// Properties
		public List<QueryExpression> Expressions { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		public CompositeExpression(QueryOperator @operator); // 0x0000000181758360-0x00000001817583E0
	
		// Methods
		public override bool IsMatch(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181758100-0x0000000181758360
	}
}
