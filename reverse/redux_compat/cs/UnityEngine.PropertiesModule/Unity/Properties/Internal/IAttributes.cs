/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties.Internal
{
	internal interface IAttributes // TypeDefIndex: 14543
	{
		// Properties
		List<Attribute> Attributes { get; set; }
	
		// Methods
		void AddAttribute(Attribute attribute);
		void AddAttributes(IEnumerable<Attribute> attributes);
		AttributesScope CreateAttributesScope(IAttributes attributes);
	}
}
