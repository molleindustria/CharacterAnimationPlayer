using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendPlayer : MonoBehaviour
{

    [Tooltip("The renderer with blendshapes")]
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Tooltip("The number of the blendshape to animate starting from 0")]
    public int blendNumber = 0;

    [Tooltip("The key that triggers the animation")]
    public KeyCode keyTrigger = KeyCode.Space;

    [Tooltip("The transition speed")]
    public float transitionSpeed = 0.5f;

    public float blendWeight = 0;
     
    
    // Start is called before the first frame update
    void Start()
    {
        if (skinnedMeshRenderer == null)
            skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (skinnedMeshRenderer == null)
        {
            Debug.LogWarning("Please add an SkinnedMeshRenderer component");
        }
        else if (Input.GetKey(keyTrigger))
        {
            blendWeight += Time.deltaTime * transitionSpeed;

            if (blendWeight > 1)
                blendWeight = 1;

            skinnedMeshRenderer.SetBlendShapeWeight(blendNumber, blendWeight*100);

        }
        else
        {
            blendWeight -= Time.deltaTime * transitionSpeed;

            if (blendWeight < 0)
                blendWeight = 0;

            skinnedMeshRenderer.SetBlendShapeWeight(blendNumber, blendWeight*100);
        }
        
    }



    //similar to p5 map function remap OldValue from a range between OldMin and OldMax
    //to a range NewMin NewMax
    public static float Map(float OldValue, float OldMin, float OldMax, float NewMin, float NewMax, bool clamp = false)
    {
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        if (clamp)
            NewValue = Mathf.Clamp(NewValue, NewMin, NewMax);

        return (NewValue);
    }
}
