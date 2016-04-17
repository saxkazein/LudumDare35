using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TraerAlFrente : MonoBehaviour
{

    void Start()
    {
        this.gameObject.SetActive(false);

    }

    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}