using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager Instance { get; private set; }

    public GameObject loadingProgress;
    public GameObject extendedMenu;
    public GameObject sofa;  // 1
    public GameObject table; // 1
    public GameObject bed;   // 2
    public GameObject chair_1; // 3
    public GameObject chair_2; // 3
    public Material color1;
    public Material color2;

    void Awake()
    {
        Instance = this;
    }
}
