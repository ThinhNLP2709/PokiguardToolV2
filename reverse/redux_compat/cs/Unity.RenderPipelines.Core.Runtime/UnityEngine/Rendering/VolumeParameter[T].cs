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
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public class VolumeParameter<T> : VolumeParameter, IEquatable<VolumeParameter<T>> // TypeDefIndex: 5807
	{
		// Fields
		[SerializeField]
		protected T m_Value;
	
		// Properties
		public virtual T value { get; set; }
	
		// Constructors
		public VolumeParameter();
		protected VolumeParameter(T value, bool overrideState = false /* Metadata: 0x00661B3F */);
	
		// Methods
		internal override void Interp(VolumeParameter from, VolumeParameter to, float t);
		public virtual void Interp(T from, T to, float t);
		public void Override(T x);
		public override void SetValue(VolumeParameter parameter);
		public override int GetHashCode();
		public override string ToString();
		public static bool operator ==(VolumeParameter<T> lhs, T rhs);
		public static bool operator !=(VolumeParameter<T> lhs, T rhs);
		public bool Equals(VolumeParameter<T> other);
		public override bool Equals(object obj);
		public override object Clone();
		public static explicit operator T(VolumeParameter<T> prop);
	}
}
