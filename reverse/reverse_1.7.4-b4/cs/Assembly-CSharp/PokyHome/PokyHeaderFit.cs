/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHeaderFit : MonoBehaviour // TypeDefIndex: 2622
	{
		// Fields
		private const string HEADER_NODE = "PanelIconheader"; // Metadata: 0x005F2609
		private const float FALLBACK_GROUP_LEFT = -358.36f; // Metadata: 0x005F2619
		private const float FALLBACK_GROUP_RIGHT = 408.01f; // Metadata: 0x005F261D
		private const float MARGIN = 8f; // Metadata: 0x005F2621
		private const float SANE_MAX = 1200f; // Metadata: 0x005F2625
		private const float MIN_SCALE = 0.35f; // Metadata: 0x005F2629
		private RectTransform _rt; // 0x20
		private RectTransform _canvasRt; // 0x28
		private float _baseScale; // 0x30
		private float _centerX; // 0x34
		private float _groupLeft; // 0x38
		private float _groupRight; // 0x3C
		private float _appliedWidth; // 0x40
		private bool _ready; // 0x44
	
		// Constructors
		public PokyHeaderFit(); // 0x0000000180C15FD0-0x0000000180C16040
	
		// Methods
		public static bool TryApply(Component hub); // 0x0000000180C14910-0x0000000180C14C30
		private void Awake(); // 0x0000000180C14C30-0x0000000180C150C0
		private void OnEnable(); // 0x0000000180C150C0-0x0000000180C150D0
		private void OnRectTransformDimensionsChange(); // 0x0000000180C150D0-0x0000000180C150E0
		private void MeasureGroup(); // 0x0000000180C150E0-0x0000000180C15600
		public string Probe(string halfWidthText); // 0x0000000180C15600-0x0000000180C15A80
		private float ScaleFor(float halfWidth); // 0x0000000180C15A80-0x0000000180C15B00
		private void Apply(); // 0x0000000180C15B00-0x0000000180C15FD0
	}
}
