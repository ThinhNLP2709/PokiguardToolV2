/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
	internal static class PointerDeviceState // TypeDefIndex: 4095
	{
		// Fields
		private static RuntimePointerState[] s_RuntimePointerStates; // 0x00
		private static PointerLocation[] s_PlayerPointerLocations; // 0x08
		private static int[] s_PressedButtons; // 0x10
		private static readonly BaseVisualElementPanel[] s_PlayerPanelWithSoftPointerCapture; // 0x18
		private static readonly IPanelComponent[] s_WorldSpacePanelComponentWithSoftPointerCapture; // 0x20
		private static readonly Camera[] s_CameraWithSoftPointerCapture; // 0x28
	
		// Nested types
		[Flags]
		internal enum LocationFlag // TypeDefIndex: 4096
		{
			None = 0,
			OutsidePanel = 1
		}
	
		private struct PointerLocation // TypeDefIndex: 4097
		{
			// Fields
			[CompilerGenerated]
			private Vector3 _Position_k__BackingField; // 0x00
			[CompilerGenerated]
			private IPanel _Panel_k__BackingField; // 0x10
			[CompilerGenerated]
			private LocationFlag _Flags_k__BackingField; // 0x18
	
			// Properties
			internal Vector3 Position { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8BE70-0x0000000181D8BE90 0x0000000181D8BED0-0x0000000181D8BEE0
			internal IPanel Panel { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			internal LocationFlag Flags { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
			// Methods
			internal void SetLocation(Vector3 position, IPanel panel); // 0x00000001824A64C0-0x00000001824A6620
		}
	
		public class RuntimePointerState // TypeDefIndex: 4098
		{
			// Fields
			public RaycastHit hit; // 0x10
			public int updateFrameCount; // 0x30
	
			// Nested types
			public struct RaycastHit // TypeDefIndex: 4099
			{
				// Fields
				public float distance; // 0x00
				public Collider collider; // 0x08
				public IPanelComponent panelComponent; // 0x10
				public VisualElement element; // 0x18
			}
	
			// Constructors
			public RuntimePointerState(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public virtual void Reset(); // 0x00000001824A7F40-0x00000001824A7F60
		}
	
		public class ScreenPointerState : RuntimePointerState // TypeDefIndex: 4100
		{
			// Fields
			public Vector2 mousePosition; // 0x38
			public int? targetDisplay; // 0x40
	
			// Constructors
			public ScreenPointerState(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override void Reset(); // 0x00000001824A8440-0x00000001824A8480
		}
	
		public class TrackedPointerState : RuntimePointerState // TypeDefIndex: 4101
		{
			// Fields
			public Vector3 worldPosition; // 0x38
			public Quaternion worldOrientation; // 0x44
			public float maxDistance; // 0x54
	
			// Properties
			public Ray worldRay { get; } // 0x00000001824A8880-0x00000001824A89C0 
	
			// Constructors
			public TrackedPointerState(); // 0x00000001824A8840-0x00000001824A8880
	
			// Methods
			public override void Reset(); // 0x00000001824A87E0-0x00000001824A8840
		}
	
		// Constructors
		static PointerDeviceState(); // 0x00000001824A5830-0x00000001824A5A70
	
		// Methods
		internal static void RemovePanelData(IPanel panel); // 0x00000001824A5120-0x00000001824A5480
		internal static void RemovePanelComponentData(IPanelComponent panelComponent); // 0x00000001824A4F50-0x00000001824A5120
		public static void SavePointerPosition(int pointerId, Vector3 position, IPanel panel, ContextType contextType); // 0x00000001824A5550-0x00000001824A5600
		public static void PressButton(int pointerId, int buttonId); // 0x00000001824A4CF0-0x00000001824A4DE0
		public static void ReleaseButton(int pointerId, int buttonId); // 0x00000001824A4E60-0x00000001824A4F50
		public static void ReleaseAllButtons(int pointerId); // 0x00000001824A4DE0-0x00000001824A4E60
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		public static Vector3 GetPointerPosition(int pointerId, ContextType contextType); // 0x00000001824A46E0-0x00000001824A4780
		public static Vector3 GetPointerDeltaPosition(int pointerId, ContextType contextType, Vector3 newPosition); // 0x00000001824A45C0-0x00000001824A46E0
		public static IPanel GetPanel(int pointerId, ContextType contextType); // 0x00000001824A44B0-0x00000001824A4530
		private static bool HasFlagFast(LocationFlag flagSet, LocationFlag flag); // 0x00000001814F3910-0x00000001814F3920
		public static bool HasLocationFlag(int pointerId, ContextType contextType, LocationFlag flag); // 0x00000001824A4C60-0x00000001824A4CF0
		public static int GetPressedButtons(int pointerId); // 0x00000001824A4780-0x00000001824A47F0
		internal static IRuntimePanel GetPlayerPanelWithSoftPointerCapture(int pointerId); // 0x00000001824A4530-0x00000001824A45C0
		internal static IPanelComponent GetWorldSpacePanelComponentWithSoftPointerCapture(int pointerId); // 0x00000001824A4BF0-0x00000001824A4C60
		internal static Camera GetCameraWithSoftPointerCapture(int pointerId); // 0x00000001824A4440-0x00000001824A44B0
		internal static void SetElementWithSoftPointerCapture(int pointerId, VisualElement element, Camera camera); // 0x00000001824A5600-0x00000001824A5830
		internal static TrackedPointerState GetTrackedState(int pointerId, bool createIfNull = false /* Metadata: 0x0066050E */); // 0x00000001824A49D0-0x00000001824A4BF0
		internal static void RemoveTrackedState(int pointerId); // 0x00000001824A5480-0x00000001824A5550
		internal static ScreenPointerState GetScreenPointerState(int pointerId, bool createIfNull = false /* Metadata: 0x0066050F */); // 0x00000001824A47F0-0x00000001824A49D0
	}
}
