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
	internal sealed class ObjectMap // TypeDefIndex: 3089
	{
		// Fields
		internal string objectName; // 0x10
		internal Type objectType; // 0x18
		internal BinaryTypeEnum[] binaryTypeEnumA; // 0x20
		internal object[] typeInformationA; // 0x28
		internal Type[] memberTypes; // 0x30
		internal string[] memberNames; // 0x38
		internal ReadObjectInfo objectInfo; // 0x40
		internal bool isInitObjectInfo; // 0x48
		internal ObjectReader objectReader; // 0x50
		internal int objectId; // 0x58
		internal BinaryAssemblyInfo assemblyInfo; // 0x60
	
		// Constructors
		internal ObjectMap(string objectName, Type objectType, string[] memberNames, ObjectReader objectReader, int objectId, BinaryAssemblyInfo assemblyInfo); // 0x00000001814F5BF0-0x00000001814F6020
		internal ObjectMap(string objectName, string[] memberNames, BinaryTypeEnum[] binaryTypeEnumA, object[] typeInformationA, int[] memberAssemIds, ObjectReader objectReader, int objectId, BinaryAssemblyInfo assemblyInfo, SizedArray assemIdToAssemblyTable); // 0x00000001814F56D0-0x00000001814F5BF0
	
		// Methods
		internal ReadObjectInfo CreateObjectInfo(ref SerializationInfo si, ref object[] memberData); // 0x00000001814F5510-0x00000001814F5560
		internal static ObjectMap Create(string name, Type objectType, string[] memberNames, ObjectReader objectReader, int objectId, BinaryAssemblyInfo assemblyInfo); // 0x00000001814F5560-0x00000001814F5600
		internal static ObjectMap Create(string name, string[] memberNames, BinaryTypeEnum[] binaryTypeEnumA, object[] typeInformationA, int[] memberAssemIds, ObjectReader objectReader, int objectId, BinaryAssemblyInfo assemblyInfo, SizedArray assemIdToAssemblyTable); // 0x00000001814F5600-0x00000001814F56D0
	}
}
