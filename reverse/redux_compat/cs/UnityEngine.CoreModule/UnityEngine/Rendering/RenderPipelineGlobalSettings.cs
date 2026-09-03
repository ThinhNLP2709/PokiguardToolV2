/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public abstract class RenderPipelineGlobalSettings : ScriptableObject, ISerializationCallbackReceiver // TypeDefIndex: 8426
	{
		// Fields
		[CompilerGenerated]
		private readonly Dictionary<Type, int> _settingsMap_k__BackingField; // 0x18
	
		// Properties
		protected virtual List<IRenderPipelineGraphicsSettings> settingsList { get; } // 0x000000018225EEA0-0x000000018225F100 
		private Dictionary<Type, int> settingsMap { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		protected RenderPipelineGlobalSettings(); // 0x000000018225EE20-0x000000018225EEA0
	
		// Methods
		private void RecreateSettingsMap(); // 0x000000018225EC20-0x000000018225ED30
		protected internal bool TryGet(Type type, out IRenderPipelineGraphicsSettings settings); // 0x000000018225ED30-0x000000018225EE20
		protected internal bool TryGetFirstSettingsImplementingInterface<TSettingsInterfaceType>(out ref TSettingsInterfaceType settings)
			where TSettingsInterfaceType : class, IRenderPipelineGraphicsSettings;
		protected internal bool GetSettingsImplementingInterface<TSettingsInterfaceType>(out List<TSettingsInterfaceType> settings)
			where TSettingsInterfaceType : class, IRenderPipelineGraphicsSettings;
		protected internal bool Contains(Type type); // 0x000000018225EBA0-0x000000018225EC20
		public virtual void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnAfterDeserialize(); // 0x000000018225EC20-0x000000018225ED30
	}
}
