using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController _Instance = null;
    public static MusicController Instance {
        get { return _Instance; }
    }

    void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else
        {
            _Instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }
}
