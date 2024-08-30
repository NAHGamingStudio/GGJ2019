using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActionManager : MonoBehaviour {

    [SerializeField]
    List<GameObject> ActionObjects;
    public GameObject LightingObjects;

    [SerializeField]
    bool HasAudio;
    [SerializeField]
    AudioSource Sound;

    [SerializeField]
    bool HasVideo;
    [SerializeField]
    VideoPlayer Video;
    [SerializeField]
    int videoStart;

    [SerializeField]
    int endingTime;
    public void PerformActions()
    {
        for (int i = 0; i < ActionObjects.Count; i++)
        {
            ActionObjects[i].SetActive(true);
        }
        if (HasAudio)
        {
            Sound.Play();
        }
        if(HasVideo)
        {
            Video.time=videoStart;
            Video.Play();
        }
        //change l materials
        Invoke("EndActions", endingTime);

        Renderer[] renders = LightingObjects.GetComponentsInChildren<Renderer>();

        foreach (var render in renders)
        {
            //render.material.SetFloat("_BWEffect", 0);
            StartCoroutine(LerpColor(render.material));
        }
    }

    IEnumerator LerpColor(Material material)
    {
        float bwEffect = 1;
        while (bwEffect > 0)
        {
            material.SetFloat("_BWEffect", bwEffect);
            bwEffect -= Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndActions()
    {
        if (HasAudio)
        {
            Sound.Stop();
        }
        if (HasVideo)
        {
            Video.Stop();
        }
        //for (int i = 0; i < ActionObjects.Count; i++)
        //{
        //    ActionObjects[i].SetActive(false);
        //}
    }


}
