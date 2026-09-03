/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	public struct LazyLoadReference<T> // TypeDefIndex: 7758
		where T : Object
	{
		// Fields
		[SerializeField]
		private EntityId m_EntityId;
	
		// Properties
		public bool isSet { get; }
		public T asset { get; set; }
	
		// Methods
		public static implicit operator LazyLoadReference<T>(T asset);
	}
}
