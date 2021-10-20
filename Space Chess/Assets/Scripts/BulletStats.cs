using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public int damage = 10;
    public int energy = 10;
    public AudioClip audioClip;

    public int GetDamage()
    {
        return damage;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public AudioClip GetAudioClip()
    {
        return audioClip;
    }
}
