using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollQuestion : MonoBehaviour
{
    public float rate = 1f;

    public Vector2 direction;


    // Update is called once per frame
    void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material mat = meshRenderer.material;
        Vector2 displacement = direction * rate * Time.deltaTime;
        mat.mainTextureOffset += displacement;
    }
}
