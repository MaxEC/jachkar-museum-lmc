using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Diagnostics;

public class SmoothCameraButton : MonoBehaviour
{


    [SerializeField]
    public List<Text> metaText;
    public GameObject scrollView;
    public GameObject mainCamera;
    public GameObject addStoneMenu;
    public String sceneName;
    public float speed = 0.3F;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private Transform endMarker;
    private Transform startMarker;
    private Transform selection = null;
    private Transform targetGameObject;
    private int stoneMask = 1 << 9;
    private int groundMask = 1 << 10;
    //private float startTime;
    private FirstPersonController fps;
    private bool start;

    //static private Stopwatch stopWatch;

    bool flip_right, flip_left;
    int angle;
    Quaternion quat;

    // Use this for initialization
    void Start()
    {
        fps = mainCamera.gameObject.GetComponent<FirstPersonController>();
        flip_right = false;
        flip_left = false;
        angle = 180;

        //stopWatch = new Stopwatch();
    }

    public void RotateRight() {
        flip_right = true;
        flip_left = false;
        angle = angle + 15;
    }

    public void RotateLeft() {
        flip_left = true;
        flip_right = false;
        angle = angle - 15;
    }

    public void ShowMenus()
    {
        addStoneMenu.SetActive(true);
    }

    public void HideMenus()
    {
        addStoneMenu.SetActive(false);
    }

    void LateUpdate() {
        if (flip_right) {
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));
        }
        if (flip_left) {
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));
        }
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));
    }

}