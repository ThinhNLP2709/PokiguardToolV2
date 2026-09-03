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

namespace Newtonsoft.Json
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false)]
	public sealed class JsonObjectAttribute : JsonContainerAttribute // TypeDefIndex: 9980
	{
		// Fields
		private MemberSerialization _memberSerialization; // 0x68
		internal MissingMemberHandling? _missingMemberHandling; // 0x6C
		internal Required? _itemRequired; // 0x74
		internal NullValueHandling? _itemNullValueHandling; // 0x7C
	
		// Properties
		public MemberSerialization MemberSerialization { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
		public MissingMemberHandling MissingMemberHandling { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x000000018169BBC0-0x000000018169BBF0
		public NullValueHandling ItemNullValueHandling { get; set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x000000018169BB60-0x000000018169BB90
		public Required ItemRequired { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x000000018169BB90-0x000000018169BBC0
	
		// Constructors
		public JsonObjectAttribute(); // 0x00000001802F4070-0x00000001802F4080
		public JsonObjectAttribute(MemberSerialization memberSerialization); // 0x000000018169BB20-0x000000018169BB50
		[NullableContext(1)]
		public JsonObjectAttribute(string id); // 0x00000001802E7420-0x00000001802E7460
	}
}
