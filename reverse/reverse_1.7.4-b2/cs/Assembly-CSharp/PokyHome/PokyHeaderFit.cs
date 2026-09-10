/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHeaderFit : MonoBehaviour // TypeDefIndex: 2179
	{
		// Fields
		private const string HEADER_NODE = "PanelIconheader"; // Metadata: 0x0068E0D4
		private const float FALLBACK_GROUP_LEFT = -358.36f; // Metadata: 0x0068E0E4
		private const float FALLBACK_GROUP_RIGHT = 408.01f; // Metadata: 0x0068E0E8
		private const float MARGIN = 8f; // Metadata: 0x0068E0EC
		private const float SANE_MAX = 1200f; // Metadata: 0x0068E0F0
		private const float MIN_SCALE = 0.35f; // Metadata: 0x0068E0F4
		private RectTransform _rt; // 0x20
		private RectTransform _canvasRt; // 0x28
		private float _baseScale; // 0x30
		private float _centerX; // 0x34
		private float _groupLeft; // 0x38
		private float _groupRight; // 0x3C
		private float _appliedWidth; // 0x40
		private bool _ready; // 0x44
	
		// Constructors
		public PokyHeaderFit(); // 0x000000018076B380-0x000000018076B3B0
	
		// Methods
		public static bool TryApply(Component hub); // 0x000000018076B250-0x000000018076B380
		private void Awake(); // 0x000000018076A890-0x000000018076AA80
		private void OnEnable(); // 0x000000018076ADA0-0x000000018076ADB0
		private void OnRectTransformDimensionsChange(); // 0x000000018076ADB0-0x000000018076ADC0
		private void MeasureGroup(); // 0x000000018076AA80-0x000000018076ADA0
		public string Probe(string halfWidthText); // 0x000000018076ADC0-0x000000018076B1D0
		private float ScaleFor(float halfWidth); // 0x000000018076B1D0-0x000000018076B250
		private void Apply(); // 0x000000018076A600-0x000000018076A890
	}
}
