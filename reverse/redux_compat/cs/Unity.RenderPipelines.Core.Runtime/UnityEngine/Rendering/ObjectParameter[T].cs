/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public class ObjectParameter<T> : VolumeParameter<T> // TypeDefIndex: 5847
	{
		// Fields
		[CompilerGenerated]
		private ReadOnlyCollection<VolumeParameter> _parameters_k__BackingField;
	
		// Properties
		internal ReadOnlyCollection<VolumeParameter> parameters { [CompilerGenerated] get; [CompilerGenerated] private set; }
		public sealed override bool overrideState { get; set; }
		public sealed override T value { get; set; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5848
		{
			// Fields
			public static readonly __c<T> __9;
			public static Func<FieldInfo, bool> __9__9_0;
			public static Func<FieldInfo, int> __9__9_1;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal bool _set_value_b__9_0(FieldInfo t);
			internal int _set_value_b__9_1(FieldInfo t);
		}
	
		// Constructors
		public ObjectParameter(T value);
	
		// Methods
		internal override void Interp(VolumeParameter from, VolumeParameter to, float t);
		[CompilerGenerated]
		private VolumeParameter _set_value_b__9_2(FieldInfo t);
	}
}
