/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("This is not longer supported Please use DebugDisplaySettingsVolume. #from(6000.2)")]
	public abstract class VolumeDebugSettings<T> : IVolumeDebugSettings // TypeDefIndex: 5522
		where T : MonoBehaviour, IAdditionalData
	{
		// Fields
		[CompilerGenerated]
		private int _selectedComponent_k__BackingField;
		protected int m_SelectedCameraIndex;
		private Camera[] m_CamerasArray;
		private List<Camera> m_Cameras;
		[CompilerGenerated]
		private readonly Type _targetRenderPipeline_k__BackingField;
		private float[] weights;
		private Volume[] volumes;
		private VolumeParameter[,] savedStates;
		[NoAutoStaticsCleanup]
		private static List<Type> s_ComponentTypes;
		[CompilerGenerated]
		private static List<T> _additionalCameraDatas_k__BackingField;
	
		// Properties
		public int selectedComponent { [CompilerGenerated] get; [CompilerGenerated] set; }
		public Camera selectedCamera { get; }
		public int selectedCameraIndex { get; set; }
		public IEnumerable<Camera> cameras { get; }
		public abstract VolumeStack selectedCameraVolumeStack { get; }
		public abstract LayerMask selectedCameraLayerMask { get; }
		public abstract Vector3 selectedCameraPosition { get; }
		public Type selectedComponentType { get; set; }
		public List<ValueTuple<string, Type>> volumeComponentsPathAndType { get; }
		[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(2023.2)")]
		public virtual Type targetRenderPipeline { [CompilerGenerated] get; }
		[Obsolete("Please use volumeComponentsPathAndType instead, and get the second element of the tuple. Note: Not compatible with Fast Enter Playmode. #from(2022.2)")]
		public static List<Type> componentTypes { get; }
		[NoAutoStaticsCleanup]
		[Obsolete("Cameras are auto registered/unregistered, use property cameras. Note: Not compatible with Fast Enter Playmode. #from(2022.2)")]
		protected static List<T> additionalCameraDatas { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5523
		{
			// Fields
			public static readonly __c<T> __9;
			public static Func<Volume, bool> __9__34_0;
			public static Func<FieldInfo, bool> __9__36_0;
			public static Func<Type, bool> __9__43_0;
			public static Func<Type, bool> __9__43_1;
			public static Func<Type, string> __9__43_2;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal bool _GetVolumes_b__34_0(Volume v);
			internal bool _GetStates_b__36_0(FieldInfo t);
			internal bool _get_componentTypes_b__43_0(Type t);
			internal bool _get_componentTypes_b__43_1(Type t);
			internal string _get_componentTypes_b__43_2(Type t);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 5524
		{
			// Fields
			public Type value;
	
			// Constructors
			public __c__DisplayClass22_0();
	
			// Methods
			internal bool _set_selectedComponentType_b__0(ValueTuple<string, Type> t);
		}
	
		// Constructors
		protected VolumeDebugSettings();
		static VolumeDebugSettings();
	
		// Methods
		internal VolumeParameter GetParameter(VolumeComponent component, FieldInfo field);
		internal VolumeParameter GetParameter(FieldInfo field);
		internal VolumeParameter GetParameter(Volume volume, FieldInfo field);
		private float ComputeWeight(Volume volume, Vector3 triggerPos);
		public Volume[] GetVolumes();
		private VolumeParameter[,] GetStates();
		private bool ChangedStates(VolumeParameter[,] newStates);
		public bool RefreshVolumes(Volume[] newVolumes);
		public float GetVolumeWeight(Volume volume);
		public bool VolumeHasInfluence(Volume volume);
		[Obsolete("Please use componentPathAndType instead, and get the first element of the tuple #from(2022.2)")]
		public static string ComponentDisplayName(Type component);
		[Obsolete("Cameras are auto registered/unregistered. Note: Not compatible with Fast Enter Playmode.  #from(2022.2)")]
		public static void RegisterCamera(T additionalCamera);
		[Obsolete("Cameras are auto registered/unregistered. Note: Not compatible with Fast Enter Playmode.  #from(2022.2)")]
		public static void UnRegisterCamera(T additionalCamera);
	}
}
