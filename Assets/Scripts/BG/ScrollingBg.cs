using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public float scrollSpeed = 0.3f;


    private MeshRenderer mesRenderer;

    void Awake()
    {
        mesRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _scroll();
    }


    void _scroll()
    {
        Vector2 offer = mesRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offer.x += Time.deltaTime * scrollSpeed;
        mesRenderer.sharedMaterial.SetTextureOffset("_MainTex", offer);
    }

}
