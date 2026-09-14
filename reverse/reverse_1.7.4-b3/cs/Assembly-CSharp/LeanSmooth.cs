/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class LeanSmooth // TypeDefIndex: 312
{
	// Methods
	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005ED9CF */, float deltaTime = -1f /* Metadata: 0x005ED9D3 */); // 0x00000001802DB600-0x00000001802DB7D0
	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005ED9D7 */, float deltaTime = -1f /* Metadata: 0x005ED9DB */); // 0x00000001802DB7D0-0x00000001802DB900
	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005ED9DF */, float deltaTime = -1f /* Metadata: 0x005ED9E3 */); // 0x00000001802DB900-0x00000001802DBA70
	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005ED9E7 */, float deltaTime = -1f /* Metadata: 0x005ED9EB */, float friction = 2f /* Metadata: 0x005ED9EF */, float accelRate = 0.5f /* Metadata: 0x005ED9F3 */); // 0x00000001802DBA70-0x00000001802DBB90
	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005ED9F7 */, float deltaTime = -1f /* Metadata: 0x005ED9FB */, float friction = 2f /* Metadata: 0x005ED9FF */, float accelRate = 0.5f /* Metadata: 0x005EDA03 */); // 0x00000001802DBB90-0x00000001802DBD10
	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDA07 */, float deltaTime = -1f /* Metadata: 0x005EDA0B */, float friction = 2f /* Metadata: 0x005EDA0F */, float accelRate = 0.5f /* Metadata: 0x005EDA13 */); // 0x00000001802DBD10-0x00000001802DBEE0
	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x005EDA17 */); // 0x00000001802DBEE0-0x00000001802DBFB0
	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x005EDA1B */); // 0x00000001802DBFB0-0x00000001802DC090
	public static Color linear(Color current, Color target, float moveSpeed); // 0x00000001802DC090-0x00000001802DC1A0
	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDA1F */, float deltaTime = -1f /* Metadata: 0x005EDA23 */, float friction = 2f /* Metadata: 0x005EDA27 */, float accelRate = 0.5f /* Metadata: 0x005EDA2B */, float hitDamping = 0.9f /* Metadata: 0x005EDA2F */); // 0x00000001802DC1A0-0x00000001802DC2F0
	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDA33 */, float deltaTime = -1f /* Metadata: 0x005EDA37 */, float friction = 2f /* Metadata: 0x005EDA3B */, float accelRate = 0.5f /* Metadata: 0x005EDA3F */, float hitDamping = 0.9f /* Metadata: 0x005EDA43 */); // 0x00000001802DC2F0-0x00000001802DC490
	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDA47 */, float deltaTime = -1f /* Metadata: 0x005EDA4B */, float friction = 2f /* Metadata: 0x005EDA4F */, float accelRate = 0.5f /* Metadata: 0x005EDA53 */, float hitDamping = 0.9f /* Metadata: 0x005EDA57 */); // 0x00000001802DC490-0x00000001802DC690
}

