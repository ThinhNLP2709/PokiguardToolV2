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
	public abstract class DebugDisplaySettings<T> : IDebugDisplaySettings // TypeDefIndex: 5406
		where T : IDebugDisplaySettings, new()
	{
		// Fields
		protected readonly HashSet<IDebugDisplaySettingsData> m_Settings;
		private static readonly Lazy<T> s_Instance;
	
		// Properties
		public static T Instance { get; }
		public virtual bool AreAnySettingsActive { get; }
		public virtual bool IsPostProcessingAllowed { get; }
		public virtual bool IsLightingActive { get; }
	
		// Nested types
		private class IDebugDisplaySettingsDataComparer : IEqualityComparer<IDebugDisplaySettingsData> // TypeDefIndex: 5407
		{
			// Constructors
			public IDebugDisplaySettingsDataComparer();
	
			// Methods
			public bool Equals(IDebugDisplaySettingsData x, IDebugDisplaySettingsData y);
			public int GetHashCode(IDebugDisplaySettingsData obj);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5408
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal T _.cctor_b__17_0();
		}
	
		// Constructors
		protected DebugDisplaySettings();
		static DebugDisplaySettings();
	
		// Methods
		protected TData Add<TData>(TData newData)
			where TData : IDebugDisplaySettingsData;
		IDebugDisplaySettingsData IDebugDisplaySettings.Add(IDebugDisplaySettingsData newData);
		public void ForEach(Action<IDebugDisplaySettingsData> onExecute);
		public virtual void Reset();
		public virtual bool TryGetScreenClearColor(ref Color color);
	}
}
