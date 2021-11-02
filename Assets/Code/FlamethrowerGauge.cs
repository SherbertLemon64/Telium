using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerGauge : MonoBehaviour
{
    public static FlamethrowerGauge instance { protected set; get; }
    public static event Action FuelUpdate;

    [SerializeField] private int _fuel;

    public int fuel { set {
            FuelUpdate();
            _fuel = Mathf.Clamp(value, 0, maxFuel);
        } get
        {
            return _fuel;
        }
    }

    public int maxFuel = 5;

    public float fillRate {
        get {
            return Mathf.Clamp((float)fuel / (float)maxFuel, 0, 1);
        }
    }

    void Awake()
    {
        instance = this;
        fuel = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            fuel++;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            fuel--;
    }
}
