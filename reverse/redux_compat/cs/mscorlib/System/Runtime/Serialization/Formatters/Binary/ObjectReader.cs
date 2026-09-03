/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class ObjectReader // TypeDefIndex: 3100
	{
		// Fields
		internal Stream m_stream; // 0x10
		internal ISurrogateSelector m_surrogates; // 0x18
		internal StreamingContext m_context; // 0x20
		internal ObjectManager m_objectManager; // 0x30
		internal InternalFE formatterEnums; // 0x38
		internal SerializationBinder m_binder; // 0x40
		internal long topId; // 0x48
		internal bool bSimpleAssembly; // 0x50
		internal object handlerObject; // 0x58
		internal object m_topObject; // 0x60
		internal Header[] headers; // 0x68
		internal HeaderHandler handler; // 0x70
		internal SerObjectInfoInit serObjectInfoInit; // 0x78
		internal IFormatterConverter m_formatterConverter; // 0x80
		internal SerStack stack; // 0x88
		private SerStack valueFixupStack; // 0x90
		internal object[] crossAppDomainArray; // 0x98
		private bool bFullDeserialization; // 0xA0
		private bool bOldFormatDetected; // 0xA1
		private IntSizedArray valTypeObjectIdTable; // 0xA8
		private NameCache typeCache; // 0xB0
		private string previousAssemblyString; // 0xB8
		private string previousName; // 0xC0
		private Type previousType; // 0xC8
	
		// Properties
		private SerStack ValueFixupStack { get; } // 0x00000001814FA5F0-0x00000001814FA680 
		internal object TopObject { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001814FA680-0x00000001814FA6D0
	
		// Nested types
		internal class TypeNAssembly // TypeDefIndex: 3101
		{
			// Fields
			public Type type; // 0x10
			public string assemblyName; // 0x18
	
			// Constructors
			public TypeNAssembly(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal sealed class TopLevelAssemblyTypeResolver // TypeDefIndex: 3102
		{
			// Fields
			private Assembly m_topLevelAssembly; // 0x10
	
			// Constructors
			public TopLevelAssemblyTypeResolver(Assembly topLevelAssembly); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public Type ResolveType(Assembly assembly, string simpleTypeName, bool ignoreCase); // 0x00000001815046E0-0x0000000181504760
		}
	
		// Constructors
		internal ObjectReader(Stream stream, ISurrogateSelector selector, StreamingContext context, InternalFE formatterEnums, SerializationBinder binder); // 0x00000001814FA490-0x00000001814FA5F0
	
		// Methods
		internal object Deserialize(HeaderHandler handler, __BinaryParser serParser, bool fCheck); // 0x00000001814F6900-0x00000001814F6D60
		private bool HasSurrogate(Type t); // 0x00000001814F75A0-0x00000001814F7690
		private void CheckSerializable(Type t); // 0x00000001814F64F0-0x00000001814F6630
		private void InitFullDeserialization(); // 0x00000001814F7690-0x00000001814F77D0
		internal object CrossAppDomainArray(int index); // 0x00000001814F68D0-0x00000001814F6900
		internal ReadObjectInfo CreateReadObjectInfo(Type objectType); // 0x00000001814F66F0-0x00000001814F6740
		internal ReadObjectInfo CreateReadObjectInfo(Type objectType, string[] memberNames, Type[] memberTypes); // 0x00000001814F6740-0x00000001814F68D0
		internal void Parse(ParseRecord pr); // 0x00000001814F9FF0-0x00000001814FA230
		private void ParseError(ParseRecord processing, ParseRecord onStack); // 0x00000001814F8D60-0x00000001814F8FC0
		private void ParseSerializedStreamHeader(ParseRecord pr); // 0x00000001814F9ED0-0x00000001814F9F00
		private void ParseSerializedStreamHeaderEnd(ParseRecord pr); // 0x00000001814F9EA0-0x00000001814F9ED0
		private void ParseObject(ParseRecord pr); // 0x00000001814F9AE0-0x00000001814F9EA0
		private void ParseObjectEnd(ParseRecord pr); // 0x00000001814F97B0-0x00000001814F9AE0
		private void ParseArray(ParseRecord pr); // 0x00000001814F8430-0x00000001814F8D60
		private void NextRectangleMap(ParseRecord pr); // 0x00000001814F77D0-0x00000001814F78D0
		private void ParseArrayMember(ParseRecord pr); // 0x00000001814F7900-0x00000001814F8430
		private void ParseArrayMemberEnd(ParseRecord pr); // 0x00000001814F78D0-0x00000001814F7900
		private void ParseMember(ParseRecord pr); // 0x00000001814F9080-0x00000001814F97B0
		private void ParseMemberEnd(ParseRecord pr); // 0x00000001814F8FC0-0x00000001814F9080
		private void ParseString(ParseRecord pr, ParseRecord parentPr); // 0x00000001814F9F00-0x00000001814F9FF0
		private void RegisterObject(object obj, ParseRecord pr, ParseRecord objectPr); // 0x00000001814FA350-0x00000001814FA420
		private void RegisterObject(object obj, ParseRecord pr, ParseRecord objectPr, bool bIsString); // 0x00000001814FA230-0x00000001814FA350
		internal long GetId(long objectId); // 0x00000001814F6FE0-0x00000001814F70E0
		internal Type Bind(string assemblyString, string typeString); // 0x00000001814F6490-0x00000001814F64F0
		internal Type FastBindToType(string assemblyName, string typeName); // 0x00000001814F6D60-0x00000001814F6FE0
		private static Assembly ResolveSimpleAssemblyName(AssemblyName assemblyName); // 0x00000001814FA420-0x00000001814FA490
		private static void GetSimplyNamedTypeFromAssembly(Assembly assm, string typeName, ref Type type); // 0x00000001814F70E0-0x00000001814F7270
		internal Type GetType(BinaryAssemblyInfo assemblyInfo, string name); // 0x00000001814F7270-0x00000001814F75A0
		private static void CheckTypeForwardedTo(Assembly sourceAssembly, Assembly destAssembly, Type resolvedType); // 0x00000001814F6630-0x00000001814F66F0
	}
}
