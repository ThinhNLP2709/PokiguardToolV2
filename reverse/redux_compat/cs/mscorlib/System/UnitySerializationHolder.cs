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

namespace System
{
	[Serializable]
	internal class UnitySerializationHolder : ISerializable, IObjectReference // TypeDefIndex: 2439
	{
		// Fields
		private Type[] m_instantiation; // 0x10
		private int[] m_elementTypes; // 0x18
		private int m_genericParameterPosition; // 0x20
		private Type m_declaringType; // 0x28
		private MethodBase m_declaringMethod; // 0x30
		private string m_data; // 0x38
		private string m_assemblyName; // 0x40
		private int m_unityType; // 0x48
	
		// Constructors
		internal UnitySerializationHolder(SerializationInfo info, StreamingContext context); // 0x0000000181662B60-0x0000000181662FB0
	
		// Methods
		internal static RuntimeType AddElementTypes(SerializationInfo info, RuntimeType type); // 0x00000001816619F0-0x0000000181661C40
		internal Type MakeElementTypes(Type type); // 0x0000000181662980-0x0000000181662AB0
		internal static void GetUnitySerializationInfo(SerializationInfo info, int unityType); // 0x0000000181662880-0x0000000181662980
		internal static void GetUnitySerializationInfo(SerializationInfo info, RuntimeType type); // 0x00000001816622E0-0x0000000181662730
		internal static void GetUnitySerializationInfo(SerializationInfo info, int unityType, string data, RuntimeAssembly assembly); // 0x0000000181662730-0x0000000181662880
		private void ThrowInsufficientInformation(string field); // 0x0000000181662AB0-0x0000000181662B60
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181661C40-0x0000000181661CA0
		public virtual object GetRealObject(StreamingContext context); // 0x0000000181661CA0-0x00000001816622E0
	}
}
