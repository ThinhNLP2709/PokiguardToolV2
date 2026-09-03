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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class ReadObjectInfo // TypeDefIndex: 3096
	{
		// Fields
		internal int objectInfoId; // 0x10
		internal static int readObjectInfoCounter; // 0x00
		internal Type objectType; // 0x18
		internal ObjectManager objectManager; // 0x20
		internal int count; // 0x28
		internal bool isSi; // 0x2C
		internal bool isNamed; // 0x2D
		internal bool isTyped; // 0x2E
		internal bool bSimpleAssembly; // 0x2F
		internal SerObjectInfoCache cache; // 0x30
		internal string[] wireMemberNames; // 0x38
		internal Type[] wireMemberTypes; // 0x40
		private int lastPosition; // 0x48
		internal ISerializationSurrogate serializationSurrogate; // 0x50
		internal StreamingContext context; // 0x58
		internal List<Type> memberTypesList; // 0x68
		internal SerObjectInfoInit serObjectInfoInit; // 0x70
		internal IFormatterConverter formatterConverter; // 0x78
	
		// Constructors
		internal ReadObjectInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void ObjectEnd(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void PrepareForReuse(); // 0x0000000181500670-0x0000000181500680
		internal static ReadObjectInfo Create(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, ObjectManager objectManager, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, bool bSimpleAssembly); // 0x00000001814FEC60-0x00000001814FED90
		internal void Init(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, ObjectManager objectManager, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, bool bSimpleAssembly); // 0x00000001815002A0-0x0000000181500360
		internal static ReadObjectInfo Create(Type objectType, string[] memberNames, Type[] memberTypes, ISurrogateSelector surrogateSelector, StreamingContext context, ObjectManager objectManager, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, bool bSimpleAssembly); // 0x00000001814FED90-0x00000001814FEF00
		internal void Init(Type objectType, string[] memberNames, Type[] memberTypes, ISurrogateSelector surrogateSelector, StreamingContext context, ObjectManager objectManager, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, bool bSimpleAssembly); // 0x0000000181500360-0x0000000181500470
		private void InitReadConstructor(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context); // 0x00000001814FFFE0-0x0000000181500220
		private void InitSiRead(); // 0x0000000181500220-0x00000001815002A0
		private void InitNoMembers(); // 0x00000001814FFF70-0x00000001814FFFE0
		private void InitMemberInfo(); // 0x00000001814FFCC0-0x00000001814FFF70
		internal MemberInfo GetMemberInfo(string name); // 0x00000001814FEF00-0x00000001814FF170
		internal Type GetType(string name); // 0x00000001814FFA40-0x00000001814FFBC0
		internal void AddValue(string name, object value, ref SerializationInfo si, ref object[] memberData); // 0x00000001814FEA00-0x00000001814FEC60
		internal void InitDataStore(ref SerializationInfo si, ref object[] memberData); // 0x00000001814FFBC0-0x00000001814FFCC0
		internal void RecordFixup(long objectId, string name, long idRef); // 0x0000000181500680-0x0000000181500750
		internal void PopulateObjectMembers(object obj, object[] memberData); // 0x0000000181500470-0x0000000181500500
		private int Position(string name); // 0x0000000181500500-0x0000000181500670
		internal Type[] GetMemberTypes(string[] inMemberNames, Type objectType); // 0x00000001814FF320-0x00000001814FF9D0
		internal Type GetMemberType(MemberInfo objMember); // 0x00000001814FF170-0x00000001814FF320
		private static ReadObjectInfo GetObjectInfo(SerObjectInfoInit serObjectInfoInit); // 0x00000001814FF9D0-0x00000001814FFA40
	}
}
