/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyRankBoardAdapter : MonoBehaviour // TypeDefIndex: 2688
	{
		// Fields
		public Button row0; // 0x20
		public Button row1; // 0x28
		public Button row2; // 0x30
		public Button row3; // 0x38
		public Button row4; // 0x40
		public Button row5; // 0x48
		public Button row6; // 0x50
		public Button row7; // 0x58
		public Button row8; // 0x60
		[Tooltip("Controller n\u1EC1n c\u1EE7a pet (Assets/Animation/EIdleT.controller) \u2014 xem ch\u00FA th\u00EDch PET.")]
		public RuntimeAnimatorController petBaseController; // 0x68
		private Button[] _rows; // 0x70
	
		// Constructors
		public PokyRankBoardAdapter(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C45F40-0x0000000180C46580
		private void PreparePetAnimator(Transform row); // 0x0000000180C46580-0x0000000180C46AC0
	}
}
