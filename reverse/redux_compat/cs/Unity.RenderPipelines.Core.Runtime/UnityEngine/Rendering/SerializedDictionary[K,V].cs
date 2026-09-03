/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SerializedDictionaryDebugView<K, V>))]
	public class SerializedDictionary<K, V> : SerializedDictionary<K, V, K, V> // TypeDefIndex: 5401
	{
		// Constructors
		public SerializedDictionary();
	
		// Methods
		public override K SerializeKey(K key);
		public override V SerializeValue(V val);
		public override K DeserializeKey(K key);
		public override V DeserializeValue(V val);
	}
}
