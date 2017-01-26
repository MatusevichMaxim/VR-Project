using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenuInteraction : MonoBehaviour {

    public Vector3 rotateIndex;

    private GameObject _loading;
    private bool _menuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            OnMenuOpen();
    }

    public void OnMenuOpen()
    {
        GetComponent<Renderer>().material = Manager.Instance.color1;

        _loading = Instantiate(Manager.Instance.loadingProgress);
        _loading.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _loading.transform.Rotate(rotateIndex.x, rotateIndex.y, rotateIndex.z);

        StartCoroutine(WaitAndOpen(1));
    }

    public void OnMenuClose()
    {
        GetComponent<Renderer>().material = Manager.Instance.color2;
        Destroy(_loading);
        StopAllCoroutines();
    }

    IEnumerator WaitAndOpen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OpenMenu();
    }

    void OpenMenu()
    {
        if (!_menuOpen)
        {
            Manager.Instance.extendedMenu.SetActive(true);
            _menuOpen = true;
        }
        else
        {
            Manager.Instance.extendedMenu.SetActive(false);
            _menuOpen = false;
        }

        Destroy(_loading);
        StopAllCoroutines();
    }

    public void OnBuy_1_ElementEnter()
    {
        GetComponent<Renderer>().material = Manager.Instance.color1;

        _loading = Instantiate(Manager.Instance.loadingProgress);
        _loading.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _loading.transform.Rotate(rotateIndex.x, rotateIndex.y, rotateIndex.z);

        StartCoroutine(WaitAndBuy(1, 1));
    }

    public void OnBuy_2_ElementEnter()
    {
        GetComponent<Renderer>().material = Manager.Instance.color1;

        _loading = Instantiate(Manager.Instance.loadingProgress);
        _loading.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _loading.transform.Rotate(rotateIndex.x, rotateIndex.y, rotateIndex.z);

        StartCoroutine(WaitAndBuy(1, 2));
    }

    public void OnBuy_3_ElementEnter()
    {
        GetComponent<Renderer>().material = Manager.Instance.color1;

        _loading = Instantiate(Manager.Instance.loadingProgress);
        _loading.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _loading.transform.Rotate(rotateIndex.x, rotateIndex.y, rotateIndex.z);

        StartCoroutine(WaitAndBuy(1, 3));
    }

    public void OnBuyElementExit()
    {
        GetComponent<Renderer>().material = Manager.Instance.color2;
        Destroy(_loading);
        StopAllCoroutines();
    }

    IEnumerator WaitAndBuy(float waitTime, int elementId)
    {
        yield return new WaitForSeconds(waitTime);
        SetNewElement(elementId);
    }

    void SetNewElement(int id)
    {
        Manager.Instance.sofa.SetActive(false);
        Manager.Instance.table.SetActive(false);
        Manager.Instance.bed.SetActive(false);
        Manager.Instance.chair_1.SetActive(false);
        Manager.Instance.chair_2.SetActive(false);
        
        switch (id)
        {
            case 1:
                Manager.Instance.sofa.SetActive(true);
                Manager.Instance.table.SetActive(true);
                break;
            case 2:
                Manager.Instance.bed.SetActive(true);
                break;
            case 3:
                Manager.Instance.chair_1.SetActive(true);
                Manager.Instance.chair_2.SetActive(true);
                break;
        }

        Destroy(_loading);
        StopAllCoroutines();
    }
}
