﻿using UnityEngine;
using System.Collections;
public class Resolution : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        //Screen.SetResolution(1280, 800, true, 60);
        mainCamera = Camera.main;
          float screenAspect = 1920 / 1080; // 现在android手机的主流分辨。
        //  mainCamera.aspect --->  摄像机的长宽比（宽度除以高度）
        mainCamera.aspect = 1.78f;
    }
}
