/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public abstract class SerializedDictionary<K, V, SK, SV> : Dictionary<K, V>, ISerializationCallbackReceiver // TypeDefIndex: 5402
	{
		// Fields
		[SerializeField]
		private List<SK> m_Keys;
		[SerializeField]
		private List<SV> m_Values;
	
		// Constructors
		protected SerializedDictionary();
	
		// Methods
		public abstract SK SerializeKey(K key);
		public abstract SV SerializeValue(V value);
		public abstract K DeserializeKey(SK serializedKey);
		public abstract V DeserializeValue(SV serializedValue);
		public void OnBeforeSerialize();
		public void OnAfterDeserialize();
	}
}
