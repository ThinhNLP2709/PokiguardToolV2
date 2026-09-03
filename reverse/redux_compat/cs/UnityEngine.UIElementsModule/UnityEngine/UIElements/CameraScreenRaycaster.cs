/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class CameraScreenRaycaster : IScreenRaycaster // TypeDefIndex: 4204
	{
		// Fields
		public Camera[] cameras; // 0x10
		public Camera[] singleCamera; // 0x18
		public int layerMask; // 0x20
	
		// Nested types
		public class CameraRayEnumerator : IEnumerator<ValueTuple<Ray, Camera, bool>>, IEnumerable<ValueTuple<Ray, Camera, bool>> // TypeDefIndex: 4205
		{
			// Fields
			private Camera[] m_Cameras; // 0x10
			private int m_LayerMask; // 0x18
			private Vector2 m_MousePosition; // 0x1C
			private int? m_TargetDisplay; // 0x24
			private int m_Index; // 0x2C
			private Camera m_CurrentCamera; // 0x30
			private Ray m_CurrentRay; // 0x38
			private bool m_IsInsideCameraRect; // 0x50
	
			// Properties
			public ValueTuple<Ray, Camera, bool> Current { get; } // 0x00000001824AD500-0x00000001824AD550 
			object IEnumerator.Current { get; } // 0x00000001824AD440-0x00000001824AD4F0 
	
			// Constructors
			public CameraRayEnumerator(); // 0x00000001824AD4F0-0x00000001824AD500
	
			// Methods
			public bool MoveNext(); // 0x00000001824AD300-0x00000001824AD430
			public void Reset(); // 0x00000001824AD430-0x00000001824AD440
			public IEnumerator<ValueTuple<Ray, Camera, bool>> GetEnumerator(); // 0x0000000180370C60-0x0000000180370C70
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000180370C60-0x0000000180370C70
			public static CameraRayEnumerator GetPooled(Camera[] cameras, int layerMask, Vector2 mousePosition, int? targetDisplay); // 0x00000001824AD240-0x00000001824AD300
			public void Dispose(); // 0x00000001824AD1C0-0x00000001824AD240
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4206
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<Camera> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001824BE730-0x00000001824BE7A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Update_b__3_0(Camera a, Camera b); // 0x00000001824BDF20-0x00000001824BDF80
		}
	
		// Constructors
		public CameraScreenRaycaster(); // 0x00000001824ADA90-0x00000001824ADB50
	
		// Methods
		public virtual void Update(); // 0x00000001824AD990-0x00000001824ADA90
		public IEnumerable<ValueTuple<Ray, Camera, bool>> MakeRay(Vector2 mousePosition, int pointerId, int? targetDisplay); // 0x00000001824AD620-0x00000001824AD790
		private static bool IsValid(Camera camera, int layerMask, int? targetDisplay); // 0x00000001824AD550-0x00000001824AD620
		private static bool MakeRay(Camera camera, Vector2 mousePosition, out Ray ray); // 0x00000001824AD790-0x00000001824AD990
	}
}
