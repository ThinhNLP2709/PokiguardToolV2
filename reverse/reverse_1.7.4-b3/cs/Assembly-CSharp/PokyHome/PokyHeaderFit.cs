/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHeaderFit : MonoBehaviour // TypeDefIndex: 2615
	{
		// Fields
		private const string HEADER_NODE = "PanelIconheader"; // Metadata: 0x005F11F2
		private const float FALLBACK_GROUP_LEFT = -358.36f; // Metadata: 0x005F1202
		private const float FALLBACK_GROUP_RIGHT = 408.01f; // Metadata: 0x005F1206
		private const float MARGIN = 8f; // Metadata: 0x005F120A
		private const float SANE_MAX = 1200f; // Metadata: 0x005F120E
		private const float MIN_SCALE = 0.35f; // Metadata: 0x005F1212
		private RectTransform _rt; // 0x20
		private RectTransform _canvasRt; // 0x28
		private float _baseScale; // 0x30
		private float _centerX; // 0x34
		private float _groupLeft; // 0x38
		private float _groupRight; // 0x3C
		private float _appliedWidth; // 0x40
		private bool _ready; // 0x44
	
		// Constructors
		public PokyHeaderFit(); // 0x0000000180C08A80-0x0000000180C08AF0
	
		// Methods
		public static bool TryApply(Component hub); // 0x0000000180C073C0-0x0000000180C076E0
		private void Awake(); // 0x0000000180C076E0-0x0000000180C07B70
		private void OnEnable(); // 0x0000000180C07B70-0x0000000180C07B80
		private void OnRectTransformDimensionsChange(); // 0x0000000180C07B80-0x0000000180C07B90
		private void MeasureGroup(); // 0x0000000180C07B90-0x0000000180C080B0
		public string Probe(string halfWidthText); // 0x0000000180C080B0-0x0000000180C08530
		private float ScaleFor(float halfWidth); // 0x0000000180C08530-0x0000000180C085B0
		private void Apply(); // 0x0000000180C085B0-0x0000000180C08A80
	}
}
