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
	internal interface IMemberInfo // TypeDefIndex: 14459
	{
		// Properties
		string Name { get; }
		bool IsReadOnly { get; }
		Type ValueType { get; }
	
		// Methods
		object GetValue(object obj);
		void SetValue(object obj, object value);
		IEnumerable<Attribute> GetCustomAttributes();
	}
}
