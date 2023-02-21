using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerationHeart : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Rigidbody2D HeartLock;
    private bool statement;

    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(HeartLock, new Vector3(Random.Range(-8f, 5f), 5, 0), Quaternion.Euler(0f, 0f, 0f));
    }
}