/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHeaderFit : MonoBehaviour // TypeDefIndex: 1852
	{
		// Fields
		private const string HEADER_NODE = "PanelIconheader"; // Metadata: 0x0064DC5E
		private const float FALLBACK_GROUP_LEFT = -358.36f; // Metadata: 0x0064DC6E
		private const float FALLBACK_GROUP_RIGHT = 408.01f; // Metadata: 0x0064DC72
		private const float MARGIN = 8f; // Metadata: 0x0064DC76
		private const float SANE_MAX = 1200f; // Metadata: 0x0064DC7A
		private const float MIN_SCALE = 0.35f; // Metadata: 0x0064DC7E
		private RectTransform _rt; // 0x20
		private RectTransform _canvasRt; // 0x28
		private float _baseScale; // 0x30
		private float _centerX; // 0x34
		private float _groupLeft; // 0x38
		private float _groupRight; // 0x3C
		private float _appliedWidth; // 0x40
		private bool _ready; // 0x44
	
		// Constructors
		public PokyHeaderFit(); // 0x0000000180600C40-0x0000000180600C70
	
		// Methods
		public static bool TryApply(Component hub); // 0x0000000180600B10-0x0000000180600C40
		private void Awake(); // 0x0000000180600150-0x0000000180600340
		private void OnEnable(); // 0x0000000180600660-0x0000000180600670
		private void OnRectTransformDimensionsChange(); // 0x0000000180600670-0x0000000180600680
		private void MeasureGroup(); // 0x0000000180600340-0x0000000180600660
		public string Probe(string halfWidthText); // 0x0000000180600680-0x0000000180600A90
		private float ScaleFor(float halfWidth); // 0x0000000180600A90-0x0000000180600B10
		private void Apply(); // 0x00000001805FFEC0-0x0000000180600150
	}
}
