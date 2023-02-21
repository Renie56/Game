using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teapot_Attack : MonoBehaviour
{
    private Animator anim;
    private bool statement;
    public Transform Firepoint;
    public Transform Firepoint2;
    public Transform Firepoint3;
    public GameObject BulletPref;
    public GameObject Bullet2Pref;
    public GameObject Bullet3Pref;
    public GameObject WindPref;
    public GameObject Cloud1Pref;
    public GameObject Cloud2Pref;
    public GameObject Cloud3Pref;
    private float typeOfAttack;
    public int health = 100;
    public HaelthBar Healthbar;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Delay());
    }
    
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("WinScene");
        }
        Healthbar.SetHealth(damage);
    }

    IEnumerator Delay()
    {
        typeOfAttack = Random.Range(0f, 10f);
        statement = true;
        Debug.Log(typeOfAttack);
        if (typeOfAttack <= 5)
        {
            anim.SetBool("Attack2", statement == true);
            yield return new WaitForSeconds(0.65f);
            yield return Instantiate(Bullet2Pref, Firepoint2.position, Firepoint2.rotation);
            yield return new WaitForSeconds(0.85f);
            anim.SetBool("Attack2", statement != true);
        }
        else if(typeOfAttack <= 8)
        {
            anim.SetBool("Attack", statement == true);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            anim.SetBool("Attack", statement != true);
        }
        else
        {
            anim.SetBool("SuperAttack", statement == true);
            yield return new WaitForSeconds(1);
            yield return Instantiate(WindPref, new Vector3(0f, 0f, 0f), WindPref.transform.rotation);
            yield return Instantiate(Cloud1Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            StartCoroutine(DelayForBullet3());
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud2Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud3Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            StartCoroutine(DelayForBullet3());
            yield return new WaitForSeconds(2);
            StartCoroutine(DelayForBullet3());
            yield return Instantiate(Cloud1Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud2Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud3Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            StartCoroutine(DelayForBullet3());
            yield return new WaitForSeconds(2);
            StartCoroutine(DelayForBullet3());
            yield return Instantiate(Cloud1Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud2Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            yield return Instantiate(Cloud3Pref, new Vector3(3.3f, 1f, 0f), WindPref.transform.rotation);
            StartCoroutine(DelayForBullet3());
            yield return new WaitForSeconds(1);
            anim.SetBool("SuperAttack", statement != true);
        }
        yield return new WaitForSeconds(Mathf.Round(Random.Range(4, 6)));
        StartCoroutine(Delay());
    }

    IEnumerator DelayForBullet()
    {
        yield return Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
    }
    IEnumerator DelayForBullet3()
    {
        yield return Instantiate(Bullet3Pref, Firepoint3.position, Firepoint3.rotation);
    }
}
