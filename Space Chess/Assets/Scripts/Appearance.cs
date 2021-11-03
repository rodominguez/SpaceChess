using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    [SerializeField] private GameObject core;
    [SerializeField] private GameObject spawn;

    [SerializeField] private Material coreWhite;
    [SerializeField] private Material spawnWhite;

    [SerializeField] private Material coreBlack;
    [SerializeField] private Material spawnBlack;

    [SerializeField] private GameObject vfxWhite;
    [SerializeField] private GameObject vfxBlack;

    private bool isBlack;

    public void SetAppearance(bool isBlack)
    {
        this.isBlack = isBlack;
        if (isBlack)
        {
            core.GetComponent<MeshRenderer>().material = coreBlack;
            spawn.GetComponent<MeshRenderer>().material = spawnBlack;
            vfxBlack.SetActive(true);
            vfxWhite.SetActive(false);
        }
        else
        {
            core.GetComponent<MeshRenderer>().material = coreWhite;
            spawn.GetComponent<MeshRenderer>().material = spawnWhite;
            vfxBlack.SetActive(false);
            vfxWhite.SetActive(true);
        }
    }

    public bool GetIsBlack()
    {
        return isBlack;
    }
}
