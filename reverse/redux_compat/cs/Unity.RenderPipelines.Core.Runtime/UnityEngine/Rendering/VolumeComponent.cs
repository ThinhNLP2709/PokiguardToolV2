/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class VolumeComponent : ScriptableObject // TypeDefIndex: 5802
	{
		// Fields
		public bool active; // 0x18
		[CompilerGenerated]
		private string _displayName_k__BackingField; // 0x20
		internal VolumeParameter[] parameterList; // 0x28
		private ReadOnlyCollection<VolumeParameter> m_ParameterReadOnlyCollection; // 0x30
	
		// Properties
		[Obsolete("Use DisplayInfo attribute to define a display name instead. #from(6000.3)", false)]
		public string displayName { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public ReadOnlyCollection<VolumeParameter> parameters { get; } // 0x0000000181ED01D0-0x0000000181ED0250 
	
		// Nested types
		public sealed class Indent : PropertyAttribute // TypeDefIndex: 5803
		{
			// Fields
			public readonly int relativeAmount; // 0x18
	
			// Constructors
			public Indent(int relativeAmount = 1 /* Metadata: 0x00661B20 */); // 0x0000000181EBF720-0x0000000181EBF750
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5804
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<FieldInfo, int> __9__10_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181ECE500-0x0000000181ECE570
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _FindParameters_b__10_0(FieldInfo t); // 0x0000000180A68E00-0x0000000180A68E30
		}
	
		// Constructors
		public VolumeComponent(); // 0x0000000181ED01C0-0x0000000181ED01D0
	
		// Methods
		internal static void FindParameters(object o, List<VolumeParameter> parameters, Func<FieldInfo, bool> filter = null); // 0x0000000181ECF540-0x0000000181ECF9D0
		protected virtual void OnEnable(); // 0x0000000181ECFAF0-0x0000000181ECFCE0
		protected virtual void OnDisable(); // 0x0000000181ECFA80-0x0000000181ECFAF0
		public virtual void Override(VolumeComponent state, float interpFactor); // 0x0000000181ECFCE0-0x0000000181ECFE30
		public void SetAllOverridesTo(bool state); // 0x0000000181ECFEC0-0x0000000181ECFED0
		internal void SetOverridesTo(IEnumerable<VolumeParameter> enumerable, bool state); // 0x0000000181ECFED0-0x0000000181ED01C0
		public bool AnyPropertiesIsOverridden(); // 0x0000000181ECF4A0-0x0000000181ECF540
		public int GetStateHash(); // 0x0000000181ECF9D0-0x0000000181ECFA70
		protected virtual void OnDestroy(); // 0x0000000181ECFA70-0x0000000181ECFA80
		public void Release(); // 0x0000000181ECFE30-0x0000000181ECFEC0
	}
}
