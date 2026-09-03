/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	internal class ReflectionMethodsCache // TypeDefIndex: 13131
	{
		// Fields
		public Raycast3DCallback raycast3D; // 0x10
		public RaycastAllCallback raycast3DAll; // 0x18
		public GetRaycastNonAllocCallback getRaycastNonAlloc; // 0x20
		public Raycast2DCallback raycast2D; // 0x28
		public GetRayIntersectionAllCallback getRayIntersectionAll; // 0x30
		public GetRayIntersectionAllNonAllocCallback getRayIntersectionAllNonAlloc; // 0x38
		private static ReflectionMethodsCache s_ReflectionMethodsCache; // 0x00
	
		// Properties
		public static ReflectionMethodsCache Singleton { get; } // 0x00000001825BCCB0-0x00000001825BCD40 
	
		// Nested types
		public delegate bool Raycast3DCallback(Ray r, out RaycastHit hit, float f, int i); // TypeDefIndex: 13132; 0x00000001825B2A70-0x00000001825B2AB0
	
		public delegate RaycastHit[] RaycastAllCallback(Ray r, float f, int i); // TypeDefIndex: 13133; 0x00000001825B2890-0x00000001825B28D0
	
		public delegate int GetRaycastNonAllocCallback(Ray r, RaycastHit[] results, float f, int i); // TypeDefIndex: 13134; 0x00000001825B2A70-0x00000001825B2AB0
	
		public delegate RaycastHit2D Raycast2DCallback(Vector2 p1, Vector2 p2, float f, int i); // TypeDefIndex: 13135; 0x00000001825BB0C0-0x00000001825BB120
	
		public delegate RaycastHit2D[] GetRayIntersectionAllCallback(Ray r, float f, int i); // TypeDefIndex: 13136; 0x00000001825B2890-0x00000001825B28D0
	
		public delegate int GetRayIntersectionAllNonAllocCallback(Ray r, RaycastHit2D[] results, float f, int i); // TypeDefIndex: 13137; 0x00000001825B2A70-0x00000001825B2AB0
	
		// Constructors
		public ReflectionMethodsCache(); // 0x00000001825BBEC0-0x00000001825BCCB0
	}
}
