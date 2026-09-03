/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LTDescrOptional // TypeDefIndex: 283
{
	// Fields
	[CompilerGenerated]
	private Transform _toTrans_k__BackingField; // 0x10
	[CompilerGenerated]
	private Vector3 _point_k__BackingField; // 0x18
	[CompilerGenerated]
	private Vector3 _axis_k__BackingField; // 0x24
	[CompilerGenerated]
	private float _lastVal_k__BackingField; // 0x30
	[CompilerGenerated]
	private Quaternion _origRotation_k__BackingField; // 0x34
	[CompilerGenerated]
	private LTBezierPath _path_k__BackingField; // 0x48
	[CompilerGenerated]
	private LTSpline _spline_k__BackingField; // 0x50
	public AnimationCurve animationCurve; // 0x58
	public int initFrameCount; // 0x60
	public Color color; // 0x64
	[CompilerGenerated]
	private LTRect _ltRect_k__BackingField; // 0x78
	[CompilerGenerated]
	private Action<float> _onUpdateFloat_k__BackingField; // 0x80
	[CompilerGenerated]
	private Action<float, float> _onUpdateFloatRatio_k__BackingField; // 0x88
	[CompilerGenerated]
	private Action<float, object> _onUpdateFloatObject_k__BackingField; // 0x90
	[CompilerGenerated]
	private Action<Vector2> _onUpdateVector2_k__BackingField; // 0x98
	[CompilerGenerated]
	private Action<Vector3> _onUpdateVector3_k__BackingField; // 0xA0
	[CompilerGenerated]
	private Action<Vector3, object> _onUpdateVector3Object_k__BackingField; // 0xA8
	[CompilerGenerated]
	private Action<Color> _onUpdateColor_k__BackingField; // 0xB0
	[CompilerGenerated]
	private Action<Color, object> _onUpdateColorObject_k__BackingField; // 0xB8
	[CompilerGenerated]
	private Action _onComplete_k__BackingField; // 0xC0
	[CompilerGenerated]
	private Action<object> _onCompleteObject_k__BackingField; // 0xC8
	[CompilerGenerated]
	private object _onCompleteParam_k__BackingField; // 0xD0
	[CompilerGenerated]
	private object _onUpdateParam_k__BackingField; // 0xD8
	[CompilerGenerated]
	private Action _onStart_k__BackingField; // 0xE0

	// Properties
	public Transform toTrans { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	public Vector3 point { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBE0-0x00000001806CCC00 0x00000001806CCE70-0x00000001806CCE80
	public Vector3 axis { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB20-0x00000001806CCB40 0x00000001806CCD40-0x00000001806CCD50
	public float lastVal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
	public Quaternion origRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBD0-0x00000001806CCBE0 0x00000001806CCE60-0x00000001806CCE70
	public LTBezierPath path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
	public LTSpline spline { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	public LTRect ltRect { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
	public Action<float> onUpdateFloat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
	public Action<float, float> onUpdateFloatRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
	public Action<float, object> onUpdateFloatObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
	public Action<Vector2> onUpdateVector2 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
	public Action<Vector3> onUpdateVector3 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
	public Action<Vector3, object> onUpdateVector3Object { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
	public Action<Color> onUpdateColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
	public Action<Color, object> onUpdateColorObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
	public Action onComplete { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
	public Action<object> onCompleteObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
	public object onCompleteParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001806CCD80-0x00000001806CCDA0
	public object onUpdateParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x00000001806CCE00-0x00000001806CCE20
	public Action onStart { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001806CCDC0-0x00000001806CCDE0

	// Constructors
	public LTDescrOptional(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void reset(); // 0x00000001806CCC10-0x00000001806CCD40
	public void callOnUpdate(float val, float ratioPassed); // 0x00000001806CC920-0x00000001806CCB20
}

