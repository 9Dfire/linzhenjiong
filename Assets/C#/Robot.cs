using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot
{
    public int Life;
    public int Power;

    public Robot(int life, int power = 0)
    {
        Life = life;
        Power = power;
    }
}
