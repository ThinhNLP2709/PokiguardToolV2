/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	internal struct PanelInputSettings // TypeDefIndex: 4181
	{
		// Fields
		private static PanelInputSettings s_Default; // 0x00
		[SerializeField]
		[Tooltip("Determines whether world space panels process input events. Disable this if you need UGUI support but do not require world space input to improve performance.")]
		internal bool m_ProcessWorldSpaceInput; // 0x00
		[SerializeField]
		[Tooltip("Determines which layers can block input events on world space panels.")]
		internal LayerMask m_InteractionLayers; // 0x04
		[SerializeField]
		[Tooltip("Sets how far away interactions with world-space UI are possible. Defaults to unlimited (infinity), but you can customize it for XR or performance needs. The distance uses GameObject units, consistent with transform positions and Camera clipping planes.")]
		internal float m_MaxInteractionDistance; // 0x08
		[SerializeField]
		[Tooltip("Defines whether the Main Camera is used as the Event Camera for world space panels. Disable to specify alternative Event Camera(s) for raycasting input.")]
		internal bool m_DefaultEventCameraIsMainCamera; // 0x0C
		[SerializeField]
		[Tooltip("Defines the Event Camera(s) used for world space raycasting input.")]
		internal Camera[] m_EventCameras; // 0x10
		[SerializeField]
		[Tooltip("Determines which input event system is used for UI interactions when combining UI Toolkit and UGUI.")]
		internal InputRedirection m_PanelInputRedirection; // 0x18
		[SerializeField]
		[Tooltip("Automatically adds UI Toolkit components under the EventSystem to handle input redirection between UI Toolkit and UGUI panels. Disable to manually assign these components through code.")]
		internal bool m_AutoCreatePanelComponents; // 0x1C
	
		// Properties
		public static PanelInputSettings Default { get; } // 0x00000001824A1650-0x00000001824A16C0 
		public bool processWorldSpaceInput { get; } // 0x0000000180333490-0x00000001803334A0 
		public LayerMask interactionLayers { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public float maxInteractionDistance { get; } // 0x00000001802DB050-0x00000001802DB060 
		public bool defaultEventCameraIsMainCamera { get; } // 0x0000000181D11B10-0x0000000181D11B20 
		public Camera[] eventCameras { get; } // 0x0000000180377550-0x0000000180377560 
		public bool autoCreatePanelComponents { get; } // 0x0000000180E38E30-0x0000000180E38E40 
		internal bool shouldRedirectInput { get; } // 0x00000001824A16C0-0x00000001824A16D0 
	
		// Nested types
		internal enum InputRedirection // TypeDefIndex: 4182
		{
			AutoSwitch = 0,
			Never = 1,
			Always = 2
		}
	
		// Constructors
		static PanelInputSettings(); // 0x00000001824A1550-0x00000001824A1650
	}
}
