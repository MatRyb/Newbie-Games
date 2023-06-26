using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackControl : MonoBehaviour
{

    public Material nightSky;

    void Start()
    {
        RenderSettings.skybox = nightSky;
    }

}
