/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public sealed class ArrayPropertyBag<TElement> : IndexedCollectionPropertyBag<TElement[], TElement> // TypeDefIndex: 14467
	{
		// Properties
		protected override InstantiationKind InstantiationKind { get; }
	
		// Constructors
		public ArrayPropertyBag();
	
		// Methods
		protected override TElement[] InstantiateWithCount(int count);
		protected override TElement[] Instantiate();
	}
}
