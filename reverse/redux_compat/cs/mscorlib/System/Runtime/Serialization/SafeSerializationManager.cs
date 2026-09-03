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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	[Serializable]
	internal sealed class SafeSerializationManager : IObjectReference, ISerializable // TypeDefIndex: 3044
	{
		// Fields
		private IList<object> m_serializedStates; // 0x10
		private SerializationInfo m_savedSerializationInfo; // 0x18
		private object m_realObject; // 0x20
		private RuntimeType m_realType; // 0x28
		[CompilerGenerated]
		private EventHandler<SafeSerializationEventArgs> SerializeObjectState; // 0x30
	
		// Properties
		internal bool IsActive { get; } // 0x00000001815014A0-0x00000001815014B0 
	
		// Constructors
		internal SafeSerializationManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
		private SafeSerializationManager(SerializationInfo info, StreamingContext context); // 0x0000000181501290-0x00000001815014A0
	
		// Methods
		internal void CompleteSerialization(object serializedObject, SerializationInfo info, StreamingContext context); // 0x0000000181500AF0-0x0000000181500D70
		internal void CompleteDeserialization(object deserializedObject); // 0x0000000181500810-0x0000000181500AF0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181501160-0x0000000181501290
		object IObjectReference.GetRealObject(StreamingContext context); // 0x0000000181500E20-0x0000000181501160
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context); // 0x0000000181500D70-0x0000000181500E20
	}
}
