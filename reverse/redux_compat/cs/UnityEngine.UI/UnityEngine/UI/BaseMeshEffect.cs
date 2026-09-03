/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[ExecuteAlways]
	public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier // TypeDefIndex: 13139
	{
		// Fields
		[NonSerialized]
		private Graphic m_Graphic; // 0x20
	
		// Properties
		protected Graphic graphic { get; } // 0x00000001825AE070-0x00000001825AE100 
	
		// Constructors
		protected BaseMeshEffect(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		protected override void OnEnable(); // 0x00000001825ADFD0-0x00000001825AE070
		protected override void OnDisable(); // 0x00000001825ADF30-0x00000001825ADFD0
		protected override void OnDidApplyAnimationProperties(); // 0x00000001825ADE90-0x00000001825ADF30
		[Obsolete("Use IMeshModifier.ModifyMesh(VertexHelper verts) instead", true)]
		public virtual void ModifyMesh(Mesh mesh); // 0x00000001825ADD70-0x00000001825ADE90
		public abstract void ModifyMesh(VertexHelper vh);
	}
}
