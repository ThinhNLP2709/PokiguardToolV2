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
	public interface ISetPropertyBagVisitor // TypeDefIndex: 14513
	{
		// Methods
		void Visit<TSet, TValue>(ISetPropertyBag<TSet, TValue> properties, ref ref TSet container)
			where TSet : ISet<TValue>;
	}
}
