using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed = new Vector2(0f, 0.1f);

    Material material;
    Vector2 offset;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}