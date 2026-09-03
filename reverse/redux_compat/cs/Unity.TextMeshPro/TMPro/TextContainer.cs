/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[RequireComponent(typeof(RectTransform))]
	public class TextContainer : UIBehaviour // TypeDefIndex: 11941
	{
		// Fields
		private bool m_hasChanged; // 0x20
		[SerializeField]
		private Vector2 m_pivot; // 0x24
		[SerializeField]
		private TextContainerAnchors m_anchorPosition; // 0x2C
		[SerializeField]
		private Rect m_rect; // 0x30
		private bool m_isDefaultWidth; // 0x40
		private bool m_isDefaultHeight; // 0x41
		private bool m_isAutoFitting; // 0x42
		private Vector3[] m_corners; // 0x48
		private Vector3[] m_worldCorners; // 0x50
		[SerializeField]
		private Vector4 m_margins; // 0x58
		private RectTransform m_rectTransform; // 0x68
		private static readonly Vector2 k_defaultSize; // 0x00
		private TextMeshPro m_textMeshPro; // 0x70
	
		// Properties
		public bool hasChanged { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public Vector2 pivot { get; set; } // 0x00000001820F57A0-0x00000001820F57C0 0x00000001820F5BA0-0x00000001820F5C20
		public TextContainerAnchors anchorPosition { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001820F5990-0x00000001820F5A90
		public Rect rect { get; set; } // 0x0000000181E304D0-0x0000000181E304E0 0x00000001820F5C20-0x00000001820F5CE0
		public Vector2 size { get; set; } // 0x00000001820F5850-0x00000001820F58B0 0x00000001820F5CE0-0x00000001820F5D90
		public float width { get; set; } // 0x00000001820F5940-0x00000001820F5990 0x00000001820F5D90-0x00000001820F5E10
		public float height { get; set; } // 0x00000001820F5750-0x00000001820F57A0 0x00000001820F5A90-0x00000001820F5B10
		public bool isDefaultWidth { get; } // 0x00000001803B1170-0x00000001803B1180 
		public bool isDefaultHeight { get; } // 0x00000001815B1190-0x00000001815B11A0 
		public bool isAutoFitting { get; set; } // 0x00000001819C0430-0x00000001819C0440 0x00000001819C0460-0x00000001819C0470
		public Vector3[] corners { get; } // 0x00000001803272B0-0x00000001803272C0 
		public Vector3[] worldCorners { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public Vector4 margins { get; set; } // 0x0000000181B2AD40-0x0000000181B2AD50 0x00000001820F5B10-0x00000001820F5BA0
		public RectTransform rectTransform { get; } // 0x00000001820F57C0-0x00000001820F5850 
		public TextMeshPro textMeshPro { get; } // 0x00000001820F58B0-0x00000001820F5940 
	
		// Constructors
		public TextContainer(); // 0x00000001820F56D0-0x00000001820F5750
		static TextContainer(); // 0x00000001820F5690-0x00000001820F56D0
	
		// Methods
		protected override void Awake(); // 0x00000001820F4BD0-0x00000001820F4C80
		protected override void OnEnable(); // 0x00000001820F5160-0x00000001820F5170
		protected override void OnDisable(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnContainerChanged(); // 0x00000001820F4FB0-0x00000001820F5160
		protected override void OnRectTransformDimensionsChange(); // 0x00000001820F5170-0x00000001820F5450
		private void SetRect(Vector2 size); // 0x00000001820F5450-0x00000001820F54D0
		private void UpdateCorners(); // 0x00000001820F54D0-0x00000001820F5690
		private Vector2 GetPivot(TextContainerAnchors anchor); // 0x00000001820F4E90-0x00000001820F4FB0
		private TextContainerAnchors GetAnchorPosition(Vector2 pivot); // 0x00000001820F4C80-0x00000001820F4E90
	}
}
