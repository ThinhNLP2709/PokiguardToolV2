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
	[NullableContext(2)]
	internal abstract class PathFilter // TypeDefIndex: 10357
	{
		// Constructors
		protected PathFilter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[NullableContext(1)]
		public abstract IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Nullable(2)] JsonSelectSettings settings);
		protected static JToken GetTokenIndex([Nullable(1)] JToken t, JsonSelectSettings settings, int index); // 0x0000000181769DF0-0x000000018176A150
		protected static JToken GetNextScanValue([Nullable(1)] JToken originalParent, JToken container, JToken value); // 0x0000000181769D20-0x0000000181769DF0
	}
}
