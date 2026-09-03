/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public abstract class VolumeParameter : ICloneable // TypeDefIndex: 5806
	{
		// Fields
		public const string k_DebuggerDisplay = "{m_Value} ({m_OverrideState})"; // Metadata: 0x00661B21
		[SerializeField]
		protected bool m_OverrideState; // 0x10
	
		// Properties
		public virtual bool overrideState { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Constructors
		protected VolumeParameter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal abstract void Interp(VolumeParameter from, VolumeParameter to, float t);
		public T GetValue<T>();
		public abstract void SetValue(VolumeParameter parameter);
		protected internal virtual void OnEnable(); // 0x00000001802E76C0-0x00000001802E76D0
		protected internal virtual void OnDisable(); // 0x00000001802E76C0-0x00000001802E76D0
		public static bool IsObjectParameter(Type type); // 0x0000000181ED0250-0x0000000181ED0380
		public virtual void Release(); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract object Clone();
	}
}
