using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private List<GameObject> projectiles = new List<GameObject>();

    [SerializeField] private Transform parent;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private AudioClip clip;

    [SerializeField] private AudioSource audioSource;

    private int currentIndex = 0;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (GetComponent<Appearance>().GetIsBlack())
            currentIndex = 1;
        else
            currentIndex = 0;
        GameObject effectToSpawnRight = projectiles[currentIndex];
        if (InputManager.Instance.GetShoot(1f / effectToSpawnRight.GetComponent<ProjectileMoveScript>().fireRate) && levelManager.GetCurrentLevel().IsCanFire())
        {
            GameObject vfx;

            ScriptParams script = SetProjectileMoveScript(effectToSpawnRight.GetComponent<ProjectileMoveScript>().accuracy);

            if (spawnPoint != null)
            {
                vfx = Instantiate(effectToSpawnRight, spawnPoint.position, Quaternion.identity);
                vfx.transform.parent = parent;
                vfx.transform.localRotation = spawnPoint.rotation;
                vfx.GetComponent<ProjectileMoveScript>().SetLevel(levelManager.GetCurrentLevel());

                levelManager.GetCurrentLevel().SetBullet(vfx);

                GameObject muzzlePrefab = effectToSpawnRight.GetComponent<ProjectileMoveScript>().getMuzzlePrefab();

                if (muzzlePrefab != null)
                {
                    var muzzleVFX = Instantiate(muzzlePrefab, spawnPoint.position, Quaternion.identity);
                    muzzleVFX.transform.rotation = spawnPoint.rotation;
                    var ps = muzzleVFX.GetComponent<ParticleSystem>();
                    if (ps != null)
                        Destroy(muzzleVFX, ps.main.duration);
                    else
                    {
                        var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                        Destroy(muzzleVFX, psChild.main.duration);
                    }
                    muzzleVFX.transform.parent = spawnPoint;
                }
                vfx.GetComponent<ProjectileMoveScript>().angleUp = script.angleUp;
                vfx.GetComponent<ProjectileMoveScript>().angleRight = script.angleRight;
                vfx.GetComponent<ProjectileMoveScript>().range = script.range;
                vfx.GetComponent<ProjectileMoveScript>().directionUp = script.directionUp;
                vfx.GetComponent<ProjectileMoveScript>().directionRight = script.directionRight;
                vfx.GetComponent<ProjectileMoveScript>().offset = script.offset;


                

                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }
            }
        }

        private struct ScriptParams
    {
        public Vector3 offset;
        public float range;
        public float startTime;
        public bool directionUp;
        public bool directionRight;
        public float angleUp;
        public float angleRight;
    }

    private ScriptParams SetProjectileMoveScript(float accuracy)
    {
        ScriptParams script = new ScriptParams();
        script.angleUp = Random.Range(0f, 1f);
        script.angleRight = Random.Range(0f, 1f);
        script.range = Random.Range(100f, 150f);
        script.directionUp = (Random.Range(0f, 1f) < 0.5 ? true : false);
        script.directionRight = (Random.Range(0f, 1f) < 0.5 ? true : false);
        script.startTime = Time.time;

        if (accuracy != 100)
        {
            accuracy = 1 - (accuracy / 100);

            for (int i = 0; i < 2; i++)
            {
                var val = 1 * Random.Range(-accuracy, accuracy);
                var index = Random.Range(0, 2);
                if (i == 0)
                {
                    if (index == 0)
                        script.offset = new Vector3(0, -val, 0);
                    else
                        script.offset = new Vector3(0, val, 0);
                }
                else
                {
                    if (index == 0)
                        script.offset = new Vector3(0, script.offset.y, -val);
                    else
                        script.offset = new Vector3(0, script.offset.y, val);
                }
            }
        }
        return script;
    }
}
