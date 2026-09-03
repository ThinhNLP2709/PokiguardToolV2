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
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class NamingStrategy // TypeDefIndex: 10252
	{
		// Fields
		[CompilerGenerated]
		private bool _ProcessDictionaryKeys_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _ProcessExtensionDataNames_k__BackingField; // 0x11
		[CompilerGenerated]
		private bool _OverrideSpecifiedNames_k__BackingField; // 0x12
	
		// Properties
		public bool ProcessDictionaryKeys { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public bool ProcessExtensionDataNames { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
		public bool OverrideSpecifiedNames { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E20-0x0000000180E38E30 0x0000000181734F30-0x0000000181734F40
	
		// Constructors
		protected NamingStrategy(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual string GetPropertyName(string name, bool hasSpecifiedName); // 0x0000000181734F00-0x0000000181734F30
		public virtual string GetExtensionDataName(string name); // 0x0000000181734E10-0x0000000181734E30
		public virtual string GetDictionaryKey(string key); // 0x0000000181734DF0-0x0000000181734E10
		protected abstract string ResolvePropertyName(string name);
		public override int GetHashCode(); // 0x0000000181734E30-0x0000000181734F00
		[NullableContext(2)]
		public override bool Equals(object obj); // 0x0000000181734D00-0x0000000181734DF0
		[NullableContext(2)]
		protected bool Equals(NamingStrategy other); // 0x0000000181734C60-0x0000000181734D00
	}
}
