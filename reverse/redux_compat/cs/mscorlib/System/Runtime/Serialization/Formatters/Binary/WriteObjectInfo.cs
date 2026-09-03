/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class WriteObjectInfo // TypeDefIndex: 3095
	{
		// Fields
		internal int objectInfoId; // 0x10
		internal object obj; // 0x18
		internal Type objectType; // 0x20
		internal bool isSi; // 0x28
		internal bool isNamed; // 0x29
		internal bool isTyped; // 0x2A
		internal bool isArray; // 0x2B
		internal SerializationInfo si; // 0x30
		internal SerObjectInfoCache cache; // 0x38
		internal object[] memberData; // 0x40
		internal ISerializationSurrogate serializationSurrogate; // 0x48
		internal StreamingContext context; // 0x50
		internal SerObjectInfoInit serObjectInfoInit; // 0x60
		internal long objectId; // 0x68
		internal long assemId; // 0x70
		private string binderTypeName; // 0x78
		private string binderAssemblyString; // 0x80
	
		// Constructors
		internal WriteObjectInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void ObjectEnd(); // 0x0000000181506570-0x00000001815065A0
		private void InternalInit(); // 0x0000000181506490-0x0000000181506530
		internal static WriteObjectInfo Serialize(object obj, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, ObjectWriter objectWriter, SerializationBinder binder); // 0x0000000181506670-0x0000000181506720
		internal void InitSerialize(object obj, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, ObjectWriter objectWriter, SerializationBinder binder); // 0x0000000181505870-0x0000000181506100
		internal static WriteObjectInfo Serialize(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, SerializationBinder binder); // 0x00000001815065D0-0x0000000181506670
		internal void InitSerialize(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, SerializationBinder binder); // 0x0000000181505280-0x0000000181505870
		private void InitSiWrite(); // 0x0000000181506100-0x0000000181506490
		private static void CheckTypeForwardedFrom(SerObjectInfoCache cache, Type objectType, string binderAssemblyString); // 0x0000000181504760-0x00000001815048E0
		private void InitNoMembers(); // 0x0000000181505130-0x0000000181505280
		private void InitMemberInfo(); // 0x0000000181504D30-0x0000000181505130
		internal string GetTypeFullName(); // 0x0000000181504D00-0x0000000181504D30
		internal string GetAssemblyString(); // 0x00000001815048E0-0x0000000181504910
		private void InvokeSerializationBinder(SerializationBinder binder); // 0x0000000181506530-0x0000000181506570
		internal Type GetMemberType(MemberInfo objMember); // 0x00000001815049F0-0x0000000181504BA0
		internal void GetMemberInfo(out string[] outMemberNames, out Type[] outMemberTypes, out object[] outMemberData); // 0x0000000181504910-0x00000001815049F0
		private static WriteObjectInfo GetObjectInfo(SerObjectInfoInit serObjectInfoInit); // 0x0000000181504BA0-0x0000000181504D00
		private static void PutObjectInfo(SerObjectInfoInit serObjectInfoInit, WriteObjectInfo objectInfo); // 0x00000001815065A0-0x00000001815065D0
	}
}
