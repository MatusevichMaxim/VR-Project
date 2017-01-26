using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInteraction : MonoBehaviour {

    public Transform currentTarget;
    public Vector3 rotateIndex;

    private GameObject _loading;
    private bool _pointEnter = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnObjectEnter();
    }

    public void OnObjectEnter()
    {
        GetComponent<Renderer>().material = Manager.Instance.color1;

        _loading = Instantiate(Manager.Instance.loadingProgress);
        _loading.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _loading.transform.Rotate(rotateIndex.x, rotateIndex.y, rotateIndex.z);

        StartCoroutine(WaitAndMove(1));
    }

    public void OnObjectExit()
    {
        GetComponent<Renderer>().material = Manager.Instance.color2;
        Destroy(_loading);
        StopAllCoroutines();
    }

    IEnumerator WaitAndMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Move();
    }

    void Move()
    {
        Destroy(_loading);
        Seeker.Instance.targetPoint = currentTarget;
        Seeker.Instance.newPoint = true;
        StopAllCoroutines();
    }
}
