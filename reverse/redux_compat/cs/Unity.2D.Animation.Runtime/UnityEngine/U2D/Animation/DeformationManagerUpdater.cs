/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[AddComponentMenu("")]
	[DefaultExecutionOrder(10)]
	[ExecuteInEditMode]
	internal class DeformationManagerUpdater : MonoBehaviour // TypeDefIndex: 14350
	{
		// Fields
		[CompilerGenerated]
		private Action<GameObject> _onDestroyingComponent_k__BackingField; // 0x20
	
		// Properties
		public Action<GameObject> onDestroyingComponent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public DeformationManagerUpdater(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnDestroy(); // 0x0000000181C1AEF0-0x0000000181C1AF30
		private void LateUpdate(); // 0x0000000181C1AD30-0x0000000181C1AEF0
	}
}
