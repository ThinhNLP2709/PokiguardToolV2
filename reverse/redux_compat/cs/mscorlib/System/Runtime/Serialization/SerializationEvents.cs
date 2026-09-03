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
	internal sealed class SerializationEvents // TypeDefIndex: 3025
	{
		// Fields
		private readonly List<MethodInfo> _onSerializingMethods; // 0x10
		private readonly List<MethodInfo> _onSerializedMethods; // 0x18
		private readonly List<MethodInfo> _onDeserializingMethods; // 0x20
		private readonly List<MethodInfo> _onDeserializedMethods; // 0x28
	
		// Properties
		internal bool HasOnSerializingEvents { get; } // 0x00000001814EB0B0-0x00000001814EB0D0 
	
		// Constructors
		internal SerializationEvents(Type t); // 0x00000001814EAFB0-0x00000001814EB0B0
	
		// Methods
		private List<MethodInfo> GetMethodsWithAttribute(Type attribute, Type t); // 0x00000001814EAC80-0x00000001814EAE80
		internal void InvokeOnSerializing(object obj, StreamingContext context); // 0x00000001814EAF60-0x00000001814EAFB0
		internal void InvokeOnDeserializing(object obj, StreamingContext context); // 0x00000001814EAF10-0x00000001814EAF60
		internal void InvokeOnDeserialized(object obj, StreamingContext context); // 0x00000001814EAEC0-0x00000001814EAF10
		internal SerializationEventHandler AddOnSerialized(object obj, SerializationEventHandler handler); // 0x00000001814EAC60-0x00000001814EAC80
		internal SerializationEventHandler AddOnDeserialized(object obj, SerializationEventHandler handler); // 0x00000001814EAC40-0x00000001814EAC60
		private static void InvokeOnDelegate(object obj, StreamingContext context, List<MethodInfo> methods); // 0x00000001814EAE80-0x00000001814EAEC0
		private static SerializationEventHandler AddOnDelegate(object obj, SerializationEventHandler handler, List<MethodInfo> methods); // 0x00000001814EAA60-0x00000001814EAC40
	}
}
