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
	public interface IListPropertyVisitor // TypeDefIndex: 14516
	{
		// Methods
		void Visit<TContainer, TList, TElement>(Property<TContainer, TList> property, ref ref TContainer container, ref ref TList list)
			where TList : IList<TElement>;
	}
}
