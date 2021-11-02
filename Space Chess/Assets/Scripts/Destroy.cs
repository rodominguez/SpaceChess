using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Destroy : MonoBehaviour
{

    [SerializeField] private VisualEffect visualEffect;
    [SerializeField] private GameObject beam;
    [SerializeField] private AudioSource audioSource;

    private float timeToDie;
    private bool isDead;

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet")) { 
            if (audioSource != null)
                audioSource.Play();

            if (visualEffect != null)
                visualEffect.SetInt("Rate", 0);
            if (beam != null)
                beam.SetActive(false);
            timeToDie = Time.time + 5;
            isDead = true;
            GetComponent<Collider>().enabled = false;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
