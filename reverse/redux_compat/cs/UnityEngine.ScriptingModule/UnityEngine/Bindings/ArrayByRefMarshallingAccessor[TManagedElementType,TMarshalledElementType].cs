/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[DefaultMember("Item")]
	[VisibleToOtherModules]
	internal struct ArrayByRefMarshallingAccessor<TManagedElementType, TMarshalledElementType> : ICollectionMarshallingAccessor<TMarshalledElementType> // TypeDefIndex: 15492
	{
		// Fields
		private TMarshalledElementType[] array;
	
		// Constructors
		public ArrayByRefMarshallingAccessor(TManagedElementType[] array);
	
		// Methods
		public Span<TMarshalledElementType> AsSpan();
		public void CollectionChanged(int newSize);
		public void SetNull();
		public void SetEmpty();
		public TManagedElementType[] GetArray();
	}
}
