using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{



    public Shader shader;
    // Use this for initialization
    void Start()
    {
        ChangeToColorfull(0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ChangeToColorfull(1, 0);

    }


    //void ChangeShader()
    //{
    //    Renderer[] renders = GetComponentsInChildren<Renderer>();
    //    foreach (var render in renders)
    //    {
    //        render.material.shader = shader;
    //    }

    //    ChangeToColorfull(0,1);
    //}

    void ChangeToColorfull(int from, int to)
    {
        Renderer[] renders = GetComponentsInChildren<Renderer>();
        foreach (var render in renders)
            foreach (var material in render.materials)
                StartCoroutine(LerpColor(material,from,to));
    }

    IEnumerator LerpColor(Material material, int  from, int to)
    {
        float bwEffect = 0;
        while (bwEffect < 1)
        {
            print(bwEffect);
            material.SetFloat("_BWEffect", (from>to?(1-bwEffect):bwEffect));
            bwEffect += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
