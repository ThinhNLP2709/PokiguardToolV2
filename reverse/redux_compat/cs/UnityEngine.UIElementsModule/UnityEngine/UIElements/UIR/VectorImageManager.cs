/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class VectorImageManager : IDisposable // TypeDefIndex: 5164
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static List<VectorImageManager> instances; // 0x00
		private static readonly ProfilerMarker s_MarkerRegister; // 0x08
		private static readonly ProfilerMarker s_MarkerUnregister; // 0x10
		private readonly AtlasBase m_Atlas; // 0x10
		private Dictionary<VectorImage, VectorImageRenderInfo> m_Registered; // 0x18
		private VectorImageRenderInfoPool m_RenderInfoPool; // 0x20
		private GradientRemapPool m_GradientRemapPool; // 0x28
		private GradientSettingsAtlas m_GradientSettingsAtlas; // 0x30
		private bool m_LoggedExhaustedSettingsAtlas; // 0x38
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x39
	
		// Properties
		public Texture2D atlas { get; } // 0x000000018244BC40-0x000000018244BC50 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
	
		// Constructors
		public VectorImageManager(AtlasBase atlas); // 0x000000018244B7B0-0x000000018244BC40
		static VectorImageManager(); // 0x000000018244B6A0-0x000000018244B7B0
	
		// Methods
		public void Dispose(); // 0x000000018244ACB0-0x000000018244AD20
		protected virtual void Dispose(bool disposing); // 0x000000018244ABC0-0x000000018244ACB0
		public void Commit(); // 0x000000018244AB90-0x000000018244ABC0
		public GradientRemap AddUser(VectorImage vi, VisualElement context); // 0x000000018244AA40-0x000000018244AB90
		public void RemoveUser(VectorImage vi); // 0x000000018244B390-0x000000018244B490
		private VectorImageRenderInfo Register(VectorImage vi, VisualElement context); // 0x000000018244AD20-0x000000018244B390
		private void Unregister(VectorImage vi, VectorImageRenderInfo renderInfo); // 0x000000018244B490-0x000000018244B6A0
	}
}
