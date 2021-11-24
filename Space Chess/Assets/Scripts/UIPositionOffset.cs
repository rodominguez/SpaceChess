using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionOffset : MonoBehaviour
{
    [SerializeField] private GameObject objectToTrack;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private RectTransform rectTransform;

    void Update()
    {
        Vector3 position = mainCamera.WorldToScreenPoint(objectToTrack.transform.position);
        transform.position = new Vector3(position.x + offset.x + rectTransform.rect.width / 2, transform.position.y, transform.position.z);
    }

}
