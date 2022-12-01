using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolveController : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    private Material[] skinnedMaterials;

    // Start is called before the first frame update
    void Start()
    {
        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;
    }

    // Update is called once per frame
    void Update()
    {
        // TO DO
        // For now it's on buttton press but will be changed to when the mob dies
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo()
    {
        /*
        alive = false;

        if (animator != null)
            animator.SetTrigger("Die");
        else
        {
            Debug.Log("No Animator assigned in the inspector");
            alive = true;
            yield break;
        }
        */

        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }


        if (skinnedMaterials.Length > 0)
        {
            float counter = 0;

            while (skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i=0; i < skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
