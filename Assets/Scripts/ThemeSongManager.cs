﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}