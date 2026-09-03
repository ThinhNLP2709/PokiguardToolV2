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
	internal sealed class ObjectHolder // TypeDefIndex: 3035
	{
		// Fields
		private object m_object; // 0x10
		internal long m_id; // 0x18
		private int m_missingElementsRemaining; // 0x20
		private int m_missingDecendents; // 0x24
		internal SerializationInfo m_serInfo; // 0x28
		internal ISerializationSurrogate m_surrogate; // 0x30
		internal FixupHolderList m_missingElements; // 0x38
		internal LongList m_dependentObjects; // 0x40
		internal ObjectHolder m_next; // 0x48
		internal int m_flags; // 0x50
		private bool m_markForFixupWhenAvailable; // 0x54
		private ValueTypeFixupInfo m_valueFixup; // 0x58
		private TypeLoadExceptionHolder m_typeLoad; // 0x60
		private bool m_reachable; // 0x68
	
		// Properties
		internal bool IsIncompleteObjectReference { get; set; } // 0x00000001814F5280-0x00000001814F5290 0x00000001814F5310-0x00000001814F5330
		internal bool RequiresDelayedFixup { get; } // 0x00000001814F5290-0x00000001814F52A0 
		internal bool RequiresValueTypeFixup { get; } // 0x00000001814F52C0-0x00000001814F52D0 
		internal bool ValueTypeFixupPerformed { get; set; } // 0x00000001814F52E0-0x00000001814F5310 0x00000001814F5350-0x00000001814F5360
		internal bool HasISerializable { get; } // 0x00000001814F5260-0x00000001814F5270 
		internal bool HasSurrogate { get; } // 0x00000001814F5270-0x00000001814F5280 
		internal bool CanSurrogatedObjectValueChange { get; } // 0x00000001814F51B0-0x00000001814F5220 
		internal bool CanObjectValueChange { get; } // 0x00000001814F5130-0x00000001814F51B0 
		internal int DirectlyDependentObjects { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		internal int TotalDependentObjects { get; } // 0x000000018146B7F0-0x000000018146B800 
		internal bool Reachable { get; set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000180B262C0-0x0000000180B262D0
		internal bool TypeLoadExceptionReachable { get; } // 0x00000001814F52D0-0x00000001814F52E0 
		internal TypeLoadExceptionHolder TypeLoadException { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		internal object ObjectValue { get; } // 0x0000000180377550-0x0000000180377560 
		internal SerializationInfo SerializationInfo { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal ISerializationSurrogate Surrogate { get; } // 0x000000018031E110-0x000000018031E120 
		internal LongList DependentObjects { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		internal bool RequiresSerInfoFixup { get; set; } // 0x00000001814F52A0-0x00000001814F52C0 0x00000001814F5330-0x00000001814F5350
		internal ValueTypeFixupInfo ValueFixup { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal bool CompletelyFixed { get; } // 0x00000001814F5220-0x00000001814F5240 
		internal long ContainerID { get; } // 0x00000001814F5240-0x00000001814F5260 
	
		// Constructors
		internal ObjectHolder(long objID); // 0x00000001814F4CC0-0x00000001814F4D80
		internal ObjectHolder(object obj, long objID, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainingObj, FieldInfo field, int[] arrayIndex); // 0x00000001814F4D80-0x00000001814F5010
		internal ObjectHolder(string obj, long objID, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainingObj, FieldInfo field, int[] arrayIndex); // 0x00000001814F5010-0x00000001814F5130
	
		// Methods
		private void IncrementDescendentFixups(int amount); // 0x00000001814F4720-0x00000001814F4730
		internal void DecrementFixupsRemaining(ObjectManager manager); // 0x00000001814F46C0-0x00000001814F4720
		internal void RemoveDependency(long id); // 0x00000001814F4740-0x00000001814F47C0
		internal void AddFixup(FixupHolder fixup, ObjectManager manager); // 0x00000001814F4590-0x00000001814F46C0
		private void UpdateDescendentDependencyChain(int amount, ObjectManager manager); // 0x00000001814F4C60-0x00000001814F4CC0
		internal void AddDependency(long dependentObject); // 0x00000001814F4420-0x00000001814F4590
		internal void UpdateData(object obj, SerializationInfo info, ISerializationSurrogate surrogate, long idOfContainer, FieldInfo field, int[] arrayIndex, ObjectManager manager); // 0x00000001814F4980-0x00000001814F4C60
		internal void MarkForCompletionWhenAvailable(); // 0x00000001814F4730-0x00000001814F4740
		internal void SetFlags(); // 0x00000001814F47C0-0x00000001814F4850
		internal void SetObjectValue(object obj, ObjectManager manager); // 0x00000001814F4850-0x00000001814F4980
	}
}
