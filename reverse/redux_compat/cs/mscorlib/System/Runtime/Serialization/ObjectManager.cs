/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public class ObjectManager // TypeDefIndex: 3034
	{
		// Fields
		private DeserializationEventHandler m_onDeserializationHandler; // 0x10
		private SerializationEventHandler m_onDeserializedHandler; // 0x18
		internal ObjectHolder[] m_objects; // 0x20
		internal object m_topObject; // 0x28
		internal ObjectHolderList m_specialFixupObjects; // 0x30
		internal long m_fixupCount; // 0x38
		internal ISurrogateSelector m_selector; // 0x40
		internal StreamingContext m_context; // 0x48
	
		// Properties
		internal object TopObject { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal ObjectHolderList SpecialFixupObjects { get; } // 0x00000001814E95B0-0x00000001814E9620 
	
		// Constructors
		internal ObjectManager(ISurrogateSelector selector, StreamingContext context, bool checkSecurity, bool isCrossAppDomain); // 0x00000001814E9520-0x00000001814E95B0
	
		// Methods
		private bool CanCallGetType(object obj); // 0x00000001802E7990-0x00000001802E79A0
		internal ObjectHolder FindObjectHolder(long objectID); // 0x00000001814E77C0-0x00000001814E7810
		internal ObjectHolder FindOrCreateObjectHolder(long objectID); // 0x00000001814E7810-0x00000001814E78C0
		private void AddObjectHolder(ObjectHolder holder); // 0x00000001814E56D0-0x00000001814E5810
		private bool GetCompletionInfo(FixupHolder fixup, out ObjectHolder holder, out object member, bool bThrowIfMissing); // 0x00000001814E7B70-0x00000001814E7F20
		private void FixupSpecialObject(ObjectHolder holder); // 0x00000001814E78C0-0x00000001814E7B70
		private bool ResolveObjectReference(ObjectHolder holder); // 0x00000001814E92D0-0x00000001814E9520
		private bool DoValueTypeFixup(FieldInfo memberToFix, ObjectHolder holder, object value); // 0x00000001814E7170-0x00000001814E77C0
		internal void CompleteObject(ObjectHolder holder, bool bObjectFullyComplete); // 0x00000001814E5CB0-0x00000001814E6C20
		private void DoNewlyRegisteredObjectFixups(ObjectHolder holder); // 0x00000001814E7070-0x00000001814E7170
		public virtual object GetObject(long objectID); // 0x00000001814E8050-0x00000001814E8130
		internal void RegisterString(string obj, long objectID, SerializationInfo info, long idOfContainingObj, MemberInfo member); // 0x00000001814E91D0-0x00000001814E92D0
		public void RegisterObject(object obj, long objectID, SerializationInfo info, long idOfContainingObj, MemberInfo member, int[] arrayIndex); // 0x00000001814E89D0-0x00000001814E91D0
		internal void CompleteISerializableObject(object obj, SerializationInfo info, StreamingContext context); // 0x00000001814E5950-0x00000001814E5CB0
		internal static RuntimeConstructorInfo GetConstructor(RuntimeType t); // 0x00000001814E7F20-0x00000001814E8050
		public virtual void DoFixups(); // 0x00000001814E6C20-0x00000001814E7070
		private void RegisterFixup(FixupHolder fixup, long objectToBeFixed, long objectRequired); // 0x00000001814E88D0-0x00000001814E89D0
		public virtual void RecordFixup(long objectToBeFixed, MemberInfo member, long objectRequired); // 0x00000001814E8610-0x00000001814E88D0
		public virtual void RecordDelayedFixup(long objectToBeFixed, string memberName, long objectRequired); // 0x00000001814E8490-0x00000001814E8610
		public virtual void RecordArrayElementFixup(long arrayToBeFixed, int[] indices, long objectRequired); // 0x00000001814E8310-0x00000001814E8490
		public virtual void RaiseDeserializationEvent(); // 0x00000001814E8130-0x00000001814E8190
		internal virtual void AddOnDeserialization(DeserializationEventHandler handler); // 0x00000001814E5810-0x00000001814E58B0
		internal virtual void AddOnDeserialized(object obj); // 0x00000001814E58B0-0x00000001814E5950
		internal virtual void RaiseOnDeserializedEvent(object obj); // 0x00000001814E8190-0x00000001814E8250
		public void RaiseOnDeserializingEvent(object obj); // 0x00000001814E8250-0x00000001814E8310
	}
}
