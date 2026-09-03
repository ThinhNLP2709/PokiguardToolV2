/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Dynamic;
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
	public class JsonDynamicContract : JsonContainerContract // TypeDefIndex: 10229
	{
		// Fields
		[CompilerGenerated]
		private readonly JsonPropertyCollection _Properties_k__BackingField; // 0xC0
		[CompilerGenerated]
		[Nullable(new byte[3] {2, 1, 1 })]
		private Func<string, string> _PropertyNameResolver_k__BackingField; // 0xC8
		private readonly ThreadSafeStore<string, CallSite<Func<CallSite, object, object>>> _callSiteGetters; // 0xD0
		[Nullable(new byte[8] {1, 1, 1, 1, 1, 1, 2, 1 })]
		private readonly ThreadSafeStore<string, CallSite<Func<CallSite, object, object, object>>> _callSiteSetters; // 0xD8
	
		// Properties
		public JsonPropertyCollection Properties { [CompilerGenerated] get; } // 0x00000001806CCB70-0x00000001806CCB80 
		[Nullable(new byte[3] {2, 1, 1 })]
		public Func<string, string> PropertyNameResolver { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
	
		// Constructors
		public JsonDynamicContract(Type underlyingType); // 0x000000018170B610-0x000000018170B7C0
	
		// Methods
		private static CallSite<Func<CallSite, object, object>> CreateCallSiteGetter(string name); // 0x000000018170B180-0x000000018170B270
		private static CallSite<Func<CallSite, object, object, object>> CreateCallSiteSetter(string name); // 0x000000018170B270-0x000000018170B360
		internal bool TryGetMember(IDynamicMetaObjectProvider dynamicProvider, string name, [Nullable(2)] out object value); // 0x000000018170B360-0x000000018170B4C0
		internal bool TrySetMember(IDynamicMetaObjectProvider dynamicProvider, string name, [Nullable(2)] object value); // 0x000000018170B4C0-0x000000018170B610
	}
}
