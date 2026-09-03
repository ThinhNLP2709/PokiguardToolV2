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
	internal class BooleanQueryExpression : QueryExpression // TypeDefIndex: 10361
	{
		// Fields
		public readonly object Left; // 0x18
		[Nullable(2)]
		public readonly object Right; // 0x20
	
		// Constructors
		public BooleanQueryExpression(QueryOperator @operator, object left, [Nullable(2)] object right); // 0x00000001810F81C0-0x00000001810F8220
	
		// Methods
		private IEnumerable<JToken> GetResult(JToken root, JToken t, [Nullable(2)] object o); // 0x0000000181757330-0x0000000181757500
		public override bool IsMatch(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181757500-0x00000001817579D0
		private bool MatchTokens(JToken leftResult, JToken rightResult, [Nullable(2)] JsonSelectSettings settings); // 0x00000001817579D0-0x0000000181757C40
		private static bool RegexEquals(JValue input, JValue pattern, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181757C40-0x0000000181757E20
		internal static bool EqualsWithStringCoercion(JValue value, JValue queryValue); // 0x0000000181756E10-0x0000000181757330
		internal static bool EqualsWithStrictMatch(JValue value, JValue queryValue); // 0x0000000181756CB0-0x0000000181756E10
	}
}
