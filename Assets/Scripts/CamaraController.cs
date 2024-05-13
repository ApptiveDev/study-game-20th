using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    float shakeCameraTime = 1.0f;
    float shakeCameraSpeed = 2.0f;
    float shakeCameraAmount = 1.0f;
    Transform playerTransform;
    Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameManager.Instance.getPlayer().transform;
        nextPosition = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = playerTransform.position;
        nextPosition.z = -10;
        transform.position = nextPosition;
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakingCamera());
    }

    IEnumerator ShakingCamera()
    {
        Vector3 originPosition = transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeCameraTime)
        {
            Vector3 randomPoint = originPosition +
                Random.insideUnitSphere * shakeCameraAmount;
            transform.position = Vector3.Lerp(transform.position,
                randomPoint, Time.deltaTime * shakeCameraSpeed);
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        transform.position = originPosition;
    }

}
