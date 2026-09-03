/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
	[ComVisible(true)]
	public sealed class BinaryFormatter // TypeDefIndex: 3092
	{
		// Fields
		internal ISurrogateSelector m_surrogates; // 0x10
		internal StreamingContext m_context; // 0x18
		internal SerializationBinder m_binder; // 0x28
		internal FormatterTypeStyle m_typeFormat; // 0x30
		internal FormatterAssemblyStyle m_assemblyFormat; // 0x34
		internal TypeFilterLevel m_securityLevel; // 0x38
		internal object[] m_crossAppDomainArray; // 0x40
		private static Dictionary<Type, TypeInformation> typeNameCache; // 0x00
	
		// Properties
		public FormatterAssemblyStyle AssemblyFormat { set; } // 0x000000018033E770-0x000000018033E780
		public ISurrogateSelector SurrogateSelector { set; } // 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public BinaryFormatter(); // 0x00000001814EF850-0x00000001814EF8C0
		public BinaryFormatter(ISurrogateSelector selector, StreamingContext context); // 0x00000001814EF8C0-0x00000001814EF920
		static BinaryFormatter(); // 0x00000001814EF7C0-0x00000001814EF850
	
		// Methods
		public object Deserialize(Stream serializationStream); // 0x00000001814EF190-0x00000001814EF1B0
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck); // 0x00000001814EEE40-0x00000001814EF170
		public object Deserialize(Stream serializationStream, HeaderHandler handler); // 0x00000001814EF170-0x00000001814EF190
		public void Serialize(Stream serializationStream, object graph); // 0x00000001814EF7A0-0x00000001814EF7C0
		public void Serialize(Stream serializationStream, object graph, Header[] headers); // 0x00000001814EF400-0x00000001814EF420
		internal void Serialize(Stream serializationStream, object graph, Header[] headers, bool fCheck); // 0x00000001814EF420-0x00000001814EF7A0
		internal static TypeInformation GetTypeInformation(Type type); // 0x00000001814EF1B0-0x00000001814EF400
	}
}
