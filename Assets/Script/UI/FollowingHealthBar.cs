using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowingHealthBar : MonoBehaviour
{
    public static FollowingHealthBar Instance { get; private set; }

    private Image image;
    private Transform bossTransform;
    public float yOffset = 2.3f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Attention, il y a plusieurs instances de FollowingHealthBar.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        image = GetComponent<Image>();
    }

    public void SetHealth(Transform parentTransform)
    {
        bossTransform = parentTransform;
    }

    private void Update()
    {
        if (bossTransform != null)
        {
            Vector3 bossPosition = bossTransform.position;
            bossPosition.y += yOffset;
            transform.position = bossPosition;
        }
    }
}
