using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Diagnostics;

[CreateAssetMenu( fileName = "DetailViewManager")]
public class DetailViewManager : ScriptableObject
{


    [SerializeField]
    private FirstPersonController fps;
    private Stopwatch stopWatch;

    [System.NonSerialized]
    private bool initialized = false;
    private bool deleteMode = false;

    // Use this for initialization
    private void Init()
    {   
        initialized = true;
        deleteMode = false;
        stopWatch = new Stopwatch();
    }

    public void startTime() {
        if ( !initialized ) Init();
        stopWatch.Start();
    }

    public void stopTime() {
        if ( !initialized ) Init();
        stopWatch.Stop();
        stopWatch.Reset();
    }

    public void ViewDetails(string stoneName) {
        if ( !initialized ) Init();
        long ts = stopWatch.ElapsedMilliseconds;
        if (ts >= 3000) {
            stopWatch.Reset();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            StaticValues.stone_name = stoneName;
            SceneManager.LoadScene("StoneDetails", LoadSceneMode.Single);
            
        }
    } 

    public void changeDeleteMode() {
        if ( !initialized ) Init();
        deleteMode = !deleteMode;
    }

    public void deleteStone(GameObject obj) {
        if (deleteMode) {
            Destroy(obj);
        }
    }

}