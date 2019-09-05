using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameContext {

    public static bool isPlayerHid;
    public static string Player = "Player";
    public static string Head = "Head";
    public static string Shoulders = "Shoulders";
    public static string Pelvis = "Pelvis";
    public static string Knees = "Knees";
    public static string Feet = "Feet";
    public static string UI = "UI";
    public static string WinTarget = "WinTarget";
    public static string bornTransform = "bornTransform";
    public static Vector3 BornPos;
    public static int playerGroundCount;
    public static string lastJumpedBodyPart;
    public static bool isHardMode = false;
}
