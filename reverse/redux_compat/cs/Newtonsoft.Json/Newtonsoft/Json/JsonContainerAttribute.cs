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
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	[Nullable(0)]
	[NullableContext(2)]
	public abstract class JsonContainerAttribute : Attribute // TypeDefIndex: 9969
	{
		// Fields
		[CompilerGenerated]
		private string _Id_k__BackingField; // 0x10
		[CompilerGenerated]
		private string _Title_k__BackingField; // 0x18
		[CompilerGenerated]
		private string _Description_k__BackingField; // 0x20
		[CompilerGenerated]
		private Type _ItemConverterType_k__BackingField; // 0x28
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private object[] _ItemConverterParameters_k__BackingField; // 0x30
		[CompilerGenerated]
		private NamingStrategy _NamingStrategyInstance_k__BackingField; // 0x38
		internal bool? _isReference; // 0x40
		internal bool? _itemIsReference; // 0x42
		internal ReferenceLoopHandling? _itemReferenceLoopHandling; // 0x44
		internal TypeNameHandling? _itemTypeNameHandling; // 0x4C
		private Type _namingStrategyType; // 0x58
		[Nullable(new byte[2] {2, 1 })]
		private object[] _namingStrategyParameters; // 0x60
	
		// Properties
		public string Id { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string Title { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string Description { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public Type ItemConverterType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		[Nullable(new byte[2] {2, 1 })]
		public object[] ItemConverterParameters { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public Type NamingStrategyType { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x0000000181696EF0-0x0000000181696F20
		[Nullable(new byte[2] {2, 1 })]
		public object[] NamingStrategyParameters { get; set; } // 0x0000000180333260-0x0000000180333490 0x0000000181696EC0-0x0000000181696EF0
		internal NamingStrategy NamingStrategyInstance { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public bool IsReference { get; set; } // 0x00000001815B1190-0x00000001815B11A0 0x0000000181696E00-0x0000000181696E30
		public bool ItemIsReference { get; set; } // 0x00000001815B1180-0x00000001815B1190 0x0000000181696E30-0x0000000181696E60
		public ReferenceLoopHandling ItemReferenceLoopHandling { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x0000000181696E60-0x0000000181696E90
		public TypeNameHandling ItemTypeNameHandling { get; set; } // 0x000000018033D660-0x000000018033D670 0x0000000181696E90-0x0000000181696EC0
	
		// Constructors
		protected JsonContainerAttribute(); // 0x00000001802F4070-0x00000001802F4080
		[NullableContext(1)]
		protected JsonContainerAttribute(string id); // 0x00000001802E7420-0x00000001802E7460
	}
}
