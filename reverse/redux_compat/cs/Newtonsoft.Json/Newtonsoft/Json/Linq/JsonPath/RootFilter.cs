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
	internal class RootFilter : PathFilter // TypeDefIndex: 10366
	{
		// Fields
		public static readonly RootFilter Instance; // 0x00
	
		// Constructors
		private RootFilter(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static RootFilter(); // 0x000000018176AFC0-0x000000018176B030
	
		// Methods
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings); // 0x000000018176AF20-0x000000018176AFC0
	}
}
