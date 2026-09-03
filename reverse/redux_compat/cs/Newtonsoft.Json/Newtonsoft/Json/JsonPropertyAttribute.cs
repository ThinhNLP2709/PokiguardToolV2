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
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	[Nullable(0)]
	[NullableContext(2)]
	public sealed class JsonPropertyAttribute : Attribute // TypeDefIndex: 9983
	{
		// Fields
		internal NullValueHandling? _nullValueHandling; // 0x10
		internal DefaultValueHandling? _defaultValueHandling; // 0x18
		internal ReferenceLoopHandling? _referenceLoopHandling; // 0x20
		internal ObjectCreationHandling? _objectCreationHandling; // 0x28
		internal TypeNameHandling? _typeNameHandling; // 0x30
		internal bool? _isReference; // 0x38
		internal int? _order; // 0x3C
		internal Required? _required; // 0x44
		internal bool? _itemIsReference; // 0x4C
		internal ReferenceLoopHandling? _itemReferenceLoopHandling; // 0x50
		internal TypeNameHandling? _itemTypeNameHandling; // 0x58
		[CompilerGenerated]
		private Type _ItemConverterType_k__BackingField; // 0x60
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private object[] _ItemConverterParameters_k__BackingField; // 0x68
		[CompilerGenerated]
		private Type _NamingStrategyType_k__BackingField; // 0x70
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private object[] _NamingStrategyParameters_k__BackingField; // 0x78
		[CompilerGenerated]
		private string _PropertyName_k__BackingField; // 0x80
	
		// Properties
		public Type ItemConverterType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[Nullable(new byte[2] {2, 1 })]
		public object[] ItemConverterParameters { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public Type NamingStrategyType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[Nullable(new byte[2] {2, 1 })]
		public object[] NamingStrategyParameters { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public NullValueHandling NullValueHandling { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x000000018169C750-0x000000018169C780
		public DefaultValueHandling DefaultValueHandling { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x000000018169C660-0x000000018169C690
		public ReferenceLoopHandling ReferenceLoopHandling { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x000000018169C7E0-0x000000018169C810
		public ObjectCreationHandling ObjectCreationHandling { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x000000018169C780-0x000000018169C7B0
		public TypeNameHandling TypeNameHandling { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018169C810-0x000000018169C840
		public bool IsReference { get; set; } // 0x00000001814CFF30-0x00000001814CFF40 0x000000018169C690-0x000000018169C6C0
		public int Order { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018169C7B0-0x000000018169C7E0
		public Required Required { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x0000000181696E60-0x0000000181696E90
		public string PropertyName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public ReferenceLoopHandling ItemReferenceLoopHandling { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x000000018169C6F0-0x000000018169C720
		public TypeNameHandling ItemTypeNameHandling { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018169C720-0x000000018169C750
		public bool ItemIsReference { get; set; } // 0x000000018169C650-0x000000018169C660 0x000000018169C6C0-0x000000018169C6F0
	
		// Constructors
		public JsonPropertyAttribute(); // 0x00000001802F4070-0x00000001802F4080
		[NullableContext(1)]
		public JsonPropertyAttribute(string propertyName); // 0x000000018169C610-0x000000018169C650
	}
}
