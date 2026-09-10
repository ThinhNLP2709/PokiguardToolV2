/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LTDescrOptional // TypeDefIndex: 309
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
	public Transform toTrans { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803199D0-0x00000001803199E0 0x0000000180317090-0x00000001803170A0
	public Vector3 point { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803199A0-0x00000001803199C0 0x0000000180319CE0-0x0000000180319CF0
	public Vector3 axis { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319880-0x00000001803198A0 0x0000000180319B10-0x0000000180319B20
	public float lastVal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198A0-0x00000001803198B0 0x0000000180319B20-0x0000000180319B30
	public Quaternion origRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319980-0x0000000180319990 0x0000000180319CC0-0x0000000180319CD0
	public LTBezierPath path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319990-0x00000001803199A0 0x0000000180319CD0-0x0000000180319CE0
	public LTSpline spline { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803199C0-0x00000001803199D0 0x0000000180319CF0-0x0000000180319D00
	public LTRect ltRect { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802FF650-0x00000001802FF660 0x00000001802FF6B0-0x00000001802FF6C0
	public Action<float> onUpdateFloat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319930-0x0000000180319940 0x0000000180319C30-0x0000000180319C40
	public Action<float, float> onUpdateFloatRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319920-0x0000000180319930 0x0000000180319C10-0x0000000180319C30
	public Action<float, object> onUpdateFloatObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319910-0x0000000180319920 0x0000000180319BF0-0x0000000180319C10
	public Action<Vector2> onUpdateVector2 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319950-0x0000000180319960 0x0000000180319C60-0x0000000180319C80
	public Action<Vector3> onUpdateVector3 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319970-0x0000000180319980 0x0000000180319CA0-0x0000000180319CC0
	public Action<Vector3, object> onUpdateVector3Object { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319960-0x0000000180319970 0x0000000180319C80-0x0000000180319CA0
	public Action<Color> onUpdateColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319900-0x0000000180319910 0x0000000180319BD0-0x0000000180319BF0
	public Action<Color, object> onUpdateColorObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198F0-0x0000000180319900 0x0000000180319BB0-0x0000000180319BD0
	public Action onComplete { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198D0-0x00000001803198E0 0x0000000180319B70-0x0000000180319B90
	public Action<object> onCompleteObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198B0-0x00000001803198C0 0x0000000180319B30-0x0000000180319B50
	public object onCompleteParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198C0-0x00000001803198D0 0x0000000180319B50-0x0000000180319B70
	public object onUpdateParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319940-0x0000000180319950 0x0000000180319C40-0x0000000180319C60
	public Action onStart { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803198E0-0x00000001803198F0 0x0000000180319B90-0x0000000180319BB0

	// Constructors
	public LTDescrOptional(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void reset(); // 0x00000001803199E0-0x0000000180319B10
	public void callOnUpdate(float val, float ratioPassed); // 0x0000000180319680-0x0000000180319880
}

