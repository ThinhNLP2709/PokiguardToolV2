/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class __BinaryWriter // TypeDefIndex: 3093
	{
		// Fields
		internal Stream sout; // 0x10
		internal FormatterTypeStyle formatterTypeStyle; // 0x18
		internal Hashtable objectMapTable; // 0x20
		internal ObjectWriter objectWriter; // 0x28
		internal BinaryWriter dataWriter; // 0x30
		internal int m_nestedObjectCount; // 0x38
		private int nullCount; // 0x3C
		internal BinaryMethodCall binaryMethodCall; // 0x40
		internal BinaryMethodReturn binaryMethodReturn; // 0x48
		internal BinaryObject binaryObject; // 0x50
		internal BinaryObjectWithMap binaryObjectWithMap; // 0x58
		internal BinaryObjectWithMapTyped binaryObjectWithMapTyped; // 0x60
		internal BinaryObjectString binaryObjectString; // 0x68
		internal BinaryArray binaryArray; // 0x70
		private byte[] byteBuffer; // 0x78
		private int chunkSize; // 0x80
		internal MemberPrimitiveUnTyped memberPrimitiveUnTyped; // 0x88
		internal MemberPrimitiveTyped memberPrimitiveTyped; // 0x90
		internal ObjectNull objectNull; // 0x98
		internal MemberReference memberReference; // 0xA0
		internal BinaryAssembly binaryAssembly; // 0xA8
	
		// Constructors
		internal __BinaryWriter(Stream sout, ObjectWriter objectWriter, FormatterTypeStyle formatterTypeStyle); // 0x0000000181509270-0x00000001815097B0
	
		// Methods
		internal void WriteBegin(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void WriteEnd(); // 0x0000000181506D00-0x0000000181506D30
		internal void WriteBoolean(bool value); // 0x0000000181506A70-0x0000000181506AA0
		internal void WriteByte(byte value); // 0x0000000181506AA0-0x0000000181506AD0
		private void WriteBytes(byte[] value); // 0x0000000181506AD0-0x0000000181506B00
		private void WriteBytes(byte[] byteA, int offset, int size); // 0x0000000181506B00-0x0000000181506B30
		internal void WriteChar(char value); // 0x0000000181506B30-0x0000000181506B60
		internal void WriteChars(char[] value); // 0x0000000181506B60-0x0000000181506B90
		internal void WriteDecimal(decimal value); // 0x0000000181506C10-0x0000000181506CC0
		internal void WriteSingle(float value); // 0x0000000181508870-0x00000001815088A0
		internal void WriteDouble(double value); // 0x0000000181506CD0-0x0000000181506D00
		internal void WriteInt16(short value); // 0x0000000181506D30-0x0000000181506D60
		internal void WriteInt32(int value); // 0x0000000181506D60-0x0000000181506D90
		internal void WriteInt64(long value); // 0x0000000181506D90-0x0000000181506DC0
		internal void WriteSByte(sbyte value); // 0x0000000181506AA0-0x0000000181506AD0
		internal void WriteString(string value); // 0x00000001815088A0-0x00000001815088D0
		internal void WriteTimeSpan(TimeSpan value); // 0x00000001815088D0-0x0000000181508950
		internal void WriteDateTime(DateTime value); // 0x0000000181506B90-0x0000000181506C10
		internal void WriteUInt16(ushort value); // 0x0000000181508950-0x0000000181508980
		internal void WriteUInt32(uint value); // 0x0000000181508980-0x00000001815089B0
		internal void WriteUInt64(ulong value); // 0x00000001815089B0-0x00000001815089E0
		internal void WriteObjectEnd(NameInfo memberNameInfo, NameInfo typeNameInfo); // 0x00000001802E76C0-0x00000001802E76D0
		internal void WriteSerializationHeaderEnd(); // 0x00000001815081A0-0x0000000181508220
		internal void WriteSerializationHeader(int topId, int headerId, int minorVersion, int majorVersion); // 0x0000000181508220-0x0000000181508360
		internal void WriteMethodCall(); // 0x00000001815073D0-0x0000000181507460
		internal void WriteMethodReturn(); // 0x0000000181507460-0x00000001815074F0
		internal void WriteObject(NameInfo nameInfo, NameInfo typeNameInfo, int numMembers, string[] memberNames, Type[] memberTypes, WriteObjectInfo[] memberObjectInfos); // 0x0000000181507750-0x0000000181507FE0
		internal void WriteObjectString(int objectId, string value); // 0x0000000181507630-0x0000000181507750
		internal void WriteSingleArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound, Array array); // 0x0000000181508360-0x0000000181508870
		private void WriteArrayAsBytes(Array array, int typeLength); // 0x00000001815067D0-0x0000000181506920
		internal void WriteJaggedArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound); // 0x0000000181506E70-0x0000000181507070
		internal void WriteRectangleArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int rank, int[] lengthA, int[] lowerBoundA); // 0x0000000181507FE0-0x00000001815081A0
		internal void WriteObjectByteArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound, byte[] byteA); // 0x00000001815075D0-0x0000000181507630
		internal void WriteMember(NameInfo memberNameInfo, NameInfo typeNameInfo, object value); // 0x0000000181507200-0x00000001815073D0
		internal void WriteNullMember(NameInfo memberNameInfo, NameInfo typeNameInfo); // 0x0000000181507500-0x00000001815075D0
		internal void WriteMemberObjectRef(NameInfo memberNameInfo, int idRef); // 0x00000001815070A0-0x00000001815071A0
		internal void WriteMemberNested(NameInfo memberNameInfo); // 0x0000000181507070-0x00000001815070A0
		internal void WriteMemberString(NameInfo memberNameInfo, NameInfo typeNameInfo, string value); // 0x00000001815071A0-0x0000000181507200
		internal void WriteItem(NameInfo itemNameInfo, NameInfo typeNameInfo, object value); // 0x0000000181506E10-0x0000000181506E70
		internal void WriteNullItem(NameInfo itemNameInfo, NameInfo typeNameInfo); // 0x00000001815074F0-0x0000000181507500
		internal void WriteDelayedNullItem(); // 0x0000000181506CC0-0x0000000181506CD0
		internal void WriteItemEnd(); // 0x0000000181506DC0-0x0000000181506DD0
		private void InternalWriteItemNull(); // 0x0000000181506720-0x00000001815067D0
		internal void WriteItemObjectRef(NameInfo nameInfo, int idRef); // 0x0000000181506DD0-0x0000000181506E10
		internal void WriteAssembly(Type type, string assemblyString, int assemId, bool isNew); // 0x0000000181506920-0x0000000181506A70
		internal void WriteValue(InternalPrimitiveTypeE code, object value); // 0x00000001815089E0-0x0000000181509270
	}
}
