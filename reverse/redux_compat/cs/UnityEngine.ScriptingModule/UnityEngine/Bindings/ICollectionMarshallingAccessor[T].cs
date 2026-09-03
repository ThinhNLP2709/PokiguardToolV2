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
	internal interface ICollectionMarshallingAccessor<T> // TypeDefIndex: 15484
	{
		// Methods
		void CollectionChanged(int newSize);
		void SetNull();
		void SetEmpty();
		Span<T> AsSpan();
	}
}
