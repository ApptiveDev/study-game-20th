using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GearItem : MonoBehaviour
{
    GearSceneManager gearSceneManager;
    public bool isDragging = false;
    Transform objectTransform;
    Vector3 temp = new Vector3(0, 0, 9);

    int gearTypeId; // 0 : head // 1 : body // 2 : foot
    int gearSpaceId;

    void Start()
    {
        gearSceneManager = GearSceneManager.Instance;
        objectTransform = gameObject.GetComponent<Transform>();
        GearSpace gearSpace = gearSceneManager.GetMostCloseSpace(transform.position);
        gearSpaceId = gearSpace.id;
        StartCoroutine(MoveTo(gearSpace.position));
    }

    private void OnMouseDown()
    {
        gearSceneManager.GearOut(gearSpaceId);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        temp.Set(0, 0, 9);
        if (isDragging)
        {
            objectTransform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + temp;
        }
    }

    private void OnMouseUp()
    {
        GearSpace gearSpace = gearSceneManager.GetMostCloseSpace(transform.position);
        gearSpaceId = gearSpace.id;
        StartCoroutine(MoveTo(gearSpace.position));
        isDragging = false;
    }

    IEnumerator MoveTo(Vector3 position)
    {
        float deltaX = position.x - transform.position.x;
        float deltaY = position.y - transform.position.y;


        for (int i = 0; i <10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            
            temp.Set(deltaX/10, deltaY/10, 0);
            transform.position += temp;
        }
    }

}
