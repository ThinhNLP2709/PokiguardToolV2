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
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class JsonContract // TypeDefIndex: 10225
	{
		// Fields
		internal bool IsNullable; // 0x10
		internal bool IsConvertable; // 0x11
		internal bool IsEnum; // 0x12
		internal Type NonNullableUnderlyingType; // 0x18
		internal ReadType InternalReadType; // 0x20
		internal JsonContractType ContractType; // 0x24
		internal bool IsReadOnlyOrFixedSize; // 0x28
		internal bool IsSealed; // 0x29
		internal bool IsInstantiable; // 0x2A
		[Nullable(new byte[2] {2, 1 })]
		private List<SerializationCallback> _onDeserializedCallbacks; // 0x30
		[Nullable(new byte[2] {2, 1 })]
		private List<SerializationCallback> _onDeserializingCallbacks; // 0x38
		[Nullable(new byte[2] {2, 1 })]
		private List<SerializationCallback> _onSerializedCallbacks; // 0x40
		[Nullable(new byte[2] {2, 1 })]
		private List<SerializationCallback> _onSerializingCallbacks; // 0x48
		[Nullable(new byte[2] {2, 1 })]
		private List<SerializationErrorCallback> _onErrorCallbacks; // 0x50
		private Type _createdType; // 0x58
		[CompilerGenerated]
		private readonly Type _UnderlyingType_k__BackingField; // 0x60
		[CompilerGenerated]
		private bool? _IsReference_k__BackingField; // 0x68
		[CompilerGenerated]
		[Nullable(2)]
		private JsonConverter _Converter_k__BackingField; // 0x70
		[CompilerGenerated]
		[Nullable(2)]
		private JsonConverter _InternalConverter_k__BackingField; // 0x78
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private Func<object> _DefaultCreator_k__BackingField; // 0x80
		[CompilerGenerated]
		private bool _DefaultCreatorNonPublic_k__BackingField; // 0x88
	
		// Properties
		public Type UnderlyingType { [CompilerGenerated] get; } // 0x0000000180333260-0x0000000180333490 
		public Type CreatedType { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x0000000181709DF0-0x0000000181709EF0
		public bool? IsReference { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181709B60-0x0000000181709B70 0x0000000181709F00-0x0000000181709F10
		[Nullable(2)]
		public JsonConverter Converter { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[Nullable(2)]
		public JsonConverter InternalConverter { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] internal set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public IList<SerializationCallback> OnDeserializedCallbacks { get; } // 0x0000000181709B70-0x0000000181709BF0 
		public IList<SerializationCallback> OnDeserializingCallbacks { get; } // 0x0000000181709BF0-0x0000000181709C70 
		public IList<SerializationCallback> OnSerializedCallbacks { get; } // 0x0000000181709CF0-0x0000000181709D70 
		public IList<SerializationCallback> OnSerializingCallbacks { get; } // 0x0000000181709D70-0x0000000181709DF0 
		public IList<SerializationErrorCallback> OnErrorCallbacks { get; } // 0x0000000181709C70-0x0000000181709CF0 
		[Nullable(new byte[2] {2, 1 })]
		public Func<object> DefaultCreator { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public bool DefaultCreatorNonPublic { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5710-0x00000001803B5720 0x0000000181709EF0-0x0000000181709F00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass57_0 // TypeDefIndex: 10226
		{
			// Fields
			[Nullable(0)]
			public MethodInfo callbackMethodInfo; // 0x10
	
			// Constructors
			public __c__DisplayClass57_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _CreateSerializationCallback_b__0(object o, StreamingContext context); // 0x000000018171DC20-0x000000018171DD20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_0 // TypeDefIndex: 10227
		{
			// Fields
			[Nullable(0)]
			public MethodInfo callbackMethodInfo; // 0x10
	
			// Constructors
			public __c__DisplayClass58_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _CreateSerializationErrorCallback_b__0(object o, StreamingContext context, ErrorContext econtext); // 0x000000018171DD20-0x000000018171DE70
		}
	
		// Constructors
		internal JsonContract(Type underlyingType); // 0x00000001817099C0-0x0000000181709B60
	
		// Methods
		internal void InvokeOnSerializing(object o, StreamingContext context); // 0x00000001817098C0-0x00000001817099C0
		internal void InvokeOnSerialized(object o, StreamingContext context); // 0x00000001817097C0-0x00000001817098C0
		internal void InvokeOnDeserializing(object o, StreamingContext context); // 0x00000001817095A0-0x00000001817096A0
		internal void InvokeOnDeserialized(object o, StreamingContext context); // 0x00000001817094A0-0x00000001817095A0
		internal void InvokeOnError(object o, StreamingContext context, ErrorContext errorContext); // 0x00000001817096A0-0x00000001817097C0
		internal static SerializationCallback CreateSerializationCallback(MethodInfo callbackMethodInfo); // 0x0000000181709250-0x0000000181709300
		internal static SerializationErrorCallback CreateSerializationErrorCallback(MethodInfo callbackMethodInfo); // 0x0000000181709300-0x00000001817094A0
	}
}
