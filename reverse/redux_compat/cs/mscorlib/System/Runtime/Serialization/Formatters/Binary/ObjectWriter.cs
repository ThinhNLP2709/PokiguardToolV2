/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class ObjectWriter // TypeDefIndex: 3103
	{
		// Fields
		private Queue m_objectQueue; // 0x10
		private ObjectIDGenerator m_idGenerator; // 0x18
		private int m_currentId; // 0x20
		private ISurrogateSelector m_surrogates; // 0x28
		private StreamingContext m_context; // 0x30
		private __BinaryWriter serWriter; // 0x40
		private SerializationObjectManager m_objectManager; // 0x48
		private long topId; // 0x50
		private string topName; // 0x58
		private Header[] headers; // 0x60
		private InternalFE formatterEnums; // 0x68
		private SerializationBinder m_binder; // 0x70
		private SerObjectInfoInit serObjectInfoInit; // 0x78
		private IFormatterConverter m_formatterConverter; // 0x80
		internal object[] crossAppDomainArray; // 0x88
		private object previousObj; // 0x90
		private long previousId; // 0x98
		private Type previousType; // 0xA0
		private InternalPrimitiveTypeE previousCode; // 0xA8
		private Hashtable assemblyToIdTable; // 0xB0
		private SerStack niPool; // 0xB8
	
		// Properties
		internal SerializationObjectManager ObjectManager { get; } // 0x00000001803272B0-0x00000001803272C0 
	
		// Constructors
		internal ObjectWriter(ISurrogateSelector selector, StreamingContext context, InternalFE formatterEnums, SerializationBinder binder); // 0x00000001814FE830-0x00000001814FE970
	
		// Methods
		internal void Serialize(object graph, Header[] inHeaders, __BinaryWriter serWriter, bool fCheck); // 0x00000001814FB170-0x00000001814FB760
		private void Write(WriteObjectInfo objectInfo, NameInfo memberNameInfo, NameInfo typeNameInfo); // 0x00000001814FDF70-0x00000001814FE830
		private void Write(WriteObjectInfo objectInfo, NameInfo memberNameInfo, NameInfo typeNameInfo, string[] memberNames, Type[] memberTypes, object[] memberData, WriteObjectInfo[] memberObjectInfos); // 0x00000001814FDB00-0x00000001814FDF70
		private void WriteMemberSetup(WriteObjectInfo objectInfo, NameInfo memberNameInfo, NameInfo typeNameInfo, string memberName, Type memberType, object memberData, WriteObjectInfo memberObjectInfo); // 0x00000001814FCE80-0x00000001814FD000
		private void WriteMembers(NameInfo memberNameInfo, NameInfo memberTypeNameInfo, object memberData, WriteObjectInfo objectInfo, NameInfo typeNameInfo, WriteObjectInfo memberObjectInfo); // 0x00000001814FD000-0x00000001814FD600
		private void WriteArray(WriteObjectInfo objectInfo, NameInfo memberNameInfo, WriteObjectInfo memberObjectInfo); // 0x00000001814FBE30-0x00000001814FCC60
		private void WriteArrayMember(WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, object data); // 0x00000001814FBB10-0x00000001814FBE30
		private void WriteRectangle(WriteObjectInfo objectInfo, int rank, int[] maxA, Array array, NameInfo arrayElemNameTypeInfo, int[] lowerBoundA); // 0x00000001814FD620-0x00000001814FD870
		private object GetNext(out long objID); // 0x00000001814FACE0-0x00000001814FAEA0
		private long InternalGetId(object obj, bool assignUniqueIdToValueType, Type type, out bool isNew); // 0x00000001814FAEC0-0x00000001814FAFC0
		private long Schedule(object obj, bool assignUniqueIdToValueType, Type type); // 0x00000001814FB0F0-0x00000001814FB170
		private long Schedule(object obj, bool assignUniqueIdToValueType, Type type, WriteObjectInfo objectInfo); // 0x00000001814FB030-0x00000001814FB0F0
		private bool WriteKnownValueClass(NameInfo memberNameInfo, NameInfo typeNameInfo, object data); // 0x00000001814FCC60-0x00000001814FCE80
		private void WriteObjectRef(NameInfo nameInfo, long objectId); // 0x00000001814FD600-0x00000001814FD620
		private void WriteString(NameInfo memberNameInfo, NameInfo typeNameInfo, object stringObject); // 0x00000001814FD9B0-0x00000001814FDB00
		private bool CheckForNull(WriteObjectInfo objectInfo, NameInfo memberNameInfo, NameInfo typeNameInfo, object data); // 0x00000001814FA6D0-0x00000001814FA880
		private void WriteSerializedStreamHeader(long topId, long headerId); // 0x00000001814FD870-0x00000001814FD9B0
		private NameInfo TypeToNameInfo(Type type, WriteObjectInfo objectInfo, InternalPrimitiveTypeE code, NameInfo nameInfo); // 0x00000001814FB8D0-0x00000001814FB980
		private NameInfo TypeToNameInfo(Type type); // 0x00000001814FB980-0x00000001814FB9E0
		private NameInfo TypeToNameInfo(WriteObjectInfo objectInfo); // 0x00000001814FB9E0-0x00000001814FBA90
		private NameInfo TypeToNameInfo(WriteObjectInfo objectInfo, NameInfo nameInfo); // 0x00000001814FB800-0x00000001814FB8D0
		private void TypeToNameInfo(Type type, NameInfo nameInfo); // 0x00000001814FBA90-0x00000001814FBB10
		private NameInfo MemberToNameInfo(string name); // 0x00000001814FAFC0-0x00000001814FB000
		internal InternalPrimitiveTypeE ToCode(Type type); // 0x00000001814FB760-0x00000001814FB800
		private long GetAssemblyId(WriteObjectInfo objectInfo); // 0x00000001814FA890-0x00000001814FAC30
		private Type GetType(object obj); // 0x00000001814FAEA0-0x00000001814FAEC0
		private NameInfo GetNameInfo(); // 0x00000001814FAC30-0x00000001814FACE0
		private bool CheckTypeFormat(FormatterTypeStyle test, FormatterTypeStyle want); // 0x00000001814FA880-0x00000001814FA890
		private void PutNameInfo(NameInfo nameInfo); // 0x00000001814FB000-0x00000001814FB030
	}
}
