/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public class ListPropertyBag<TElement> : IndexedCollectionPropertyBag<List<TElement>, TElement> // TypeDefIndex: 14493
	{
		// Properties
		protected override InstantiationKind InstantiationKind { get; }
	
		// Constructors
		public ListPropertyBag();
	
		// Methods
		protected override List<TElement> InstantiateWithCount(int count);
		protected override List<TElement> Instantiate();
	}
}
