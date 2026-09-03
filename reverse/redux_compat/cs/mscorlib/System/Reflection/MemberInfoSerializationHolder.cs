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

namespace System.Reflection
{
	[Serializable]
	internal class MemberInfoSerializationHolder : ISerializable, IObjectReference // TypeDefIndex: 3339
	{
		// Fields
		private string m_memberName; // 0x10
		private RuntimeType m_reflectedType; // 0x18
		private string m_signature; // 0x20
		private string m_signature2; // 0x28
		private MemberTypes m_memberType; // 0x30
		private SerializationInfo m_info; // 0x38
	
		// Constructors
		internal MemberInfoSerializationHolder(SerializationInfo info, StreamingContext context); // 0x000000018152BB90-0x000000018152BF00
	
		// Methods
		public static void GetSerializationInfo(SerializationInfo info, string name, RuntimeType reflectedClass, string signature, MemberTypes type); // 0x000000018152BB60-0x000000018152BB90
		public static void GetSerializationInfo(SerializationInfo info, string name, RuntimeType reflectedClass, string signature, string signature2, MemberTypes type, Type[] genericArguments); // 0x000000018152B8A0-0x000000018152BB60
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018152AB70-0x000000018152ABD0
		public virtual object GetRealObject(StreamingContext context); // 0x000000018152ABD0-0x000000018152B8A0
	}
}
