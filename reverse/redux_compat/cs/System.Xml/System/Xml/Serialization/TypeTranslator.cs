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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class TypeTranslator // TypeDefIndex: 6930
	{
		// Fields
		private static Hashtable nameCache; // 0x00
		private static Hashtable primitiveTypes; // 0x08
		private static Hashtable primitiveArrayTypes; // 0x10
		private static Hashtable nullableTypes; // 0x18
	
		// Constructors
		static TypeTranslator(); // 0x0000000181A908A0-0x0000000181A92E40
	
		// Methods
		public static TypeData GetTypeData(Type type); // 0x0000000181A906C0-0x0000000181A90710
		public static TypeData GetTypeData(Type runtimeType, string xmlDataType, bool underlyingEnumType = false /* Metadata: 0x0069B829 */); // 0x0000000181A8FCA0-0x0000000181A906C0
		public static TypeData GetPrimitiveTypeData(string typeName); // 0x0000000181A8FC50-0x0000000181A8FCA0
		public static TypeData GetPrimitiveTypeData(string typeName, bool nullable); // 0x0000000181A8FA60-0x0000000181A8FC50
		public static TypeData FindPrimitiveTypeData(string typeName); // 0x0000000181A8F8B0-0x0000000181A8F980
		public static string GetArrayName(string elemName); // 0x0000000181A8F980-0x0000000181A8FA60
		public static void ParseArrayType(string arrayType, out string type, out string ns, out string dimensions); // 0x0000000181A90710-0x0000000181A908A0
	}
}
