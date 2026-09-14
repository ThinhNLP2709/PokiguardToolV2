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
	public class HubAvatarNameFit : MonoBehaviour // TypeDefIndex: 2614
	{
		// Fields
		private const string N_HEADER = "PanelIconheader"; // Metadata: 0x005F11D1
		private const float BAND_OVERLAP = 0.35f; // Metadata: 0x005F11E1
		private UnityEngine.UI.Text _label; // 0x20
		private RectTransform _rt; // 0x28
		private RectTransform _cluster; // 0x30
		private Transform _header; // 0x38
		private bool _headerSearched; // 0x40
		private RectTransform _canvasRt; // 0x48
		private float _lastCanvasW; // 0x50
		private string _fullText; // 0x58
		private float _designCenterX; // 0x60
		private float _designCenterY; // 0x64
		private float _designHeight; // 0x68
		private int _designFont; // 0x6C
		private bool _bound; // 0x70
		[CompilerGenerated]
		private float _FittedWidth_k__BackingField; // 0x74
		[CompilerGenerated]
		private float _FittedLeft_k__BackingField; // 0x78
		[CompilerGenerated]
		private float _FittedRight_k__BackingField; // 0x7C
		[CompilerGenerated]
		private int _FittedFont_k__BackingField; // 0x80
		[CompilerGenerated]
		private bool _Ellipsized_k__BackingField; // 0x84
		private const string DECOR_PLATE = "vipNamePlate"; // Metadata: 0x005F11E5
	
		// Properties
		public static float VipBadgeScale { get; } // 0x0000000180C04A40-0x0000000180C04AA0 
		public float FittedWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C04AA0-0x0000000180C04AB0 0x0000000180C04AB0-0x0000000180C04AC0
		public float FittedLeft { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C04AC0-0x0000000180C04AD0 0x0000000180C04AD0-0x0000000180C04AE0
		public float FittedRight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C04AE0-0x0000000180C04AF0 0x0000000180C04AF0-0x0000000180C04B00
		public int FittedFont { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C60B0-0x00000001803C60C0 0x00000001803C60C0-0x00000001803C60D0
		public bool Ellipsized { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C04B00-0x0000000180C04B10 0x0000000180C04B10-0x0000000180C04B20
	
		// Constructors
		public HubAvatarNameFit(); // 0x0000000180C07310-0x0000000180C073C0
	
		// Methods
		public static HubAvatarNameFit Ensure(UnityEngine.UI.Text label); // 0x0000000180C04B20-0x0000000180C04F10
		private void OnEnable(); // 0x0000000180C04F10-0x0000000180C04F30
		private void LateUpdate(); // 0x0000000180C04F30-0x0000000180C05100
		private void BindOnce(UnityEngine.UI.Text label); // 0x0000000180C05100-0x0000000180C05510
		private static float PushOf(UnityEngine.UI.Text label); // 0x0000000180C05510-0x0000000180C05600
		public void Apply(); // 0x0000000180C05600-0x0000000180C05FA0
		private void FitOneLine(HubAvatarConfig.Cfg cfg, float avail); // 0x0000000180C05FA0-0x0000000180C063E0
		private float MeasureWidth(string s, int size); // 0x0000000180C063E0-0x0000000180C06590
		private static string Ellipsize(string s, int keep, string tail); // 0x0000000180C06590-0x0000000180C06770
		private void RefreshVipPlate(); // 0x000000018028A320-0x000000018028A330
		private float PillLimit(Rect box, HubAvatarConfig.Cfg cfg); // 0x0000000180C06770-0x0000000180C06B60
		private Transform ResolveHeader(); // 0x0000000180C06B60-0x0000000180C06FE0
		private static Transform FindDeep(Transform root, string name); // 0x0000000180C06FE0-0x0000000180C07250
		private static bool IsNameDecor(Transform node); // 0x0000000180C07250-0x0000000180C07310
	}
}
