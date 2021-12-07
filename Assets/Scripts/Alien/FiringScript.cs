using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    private Animator animator;
    private int maxNumBullets = 25;
    private int numBullets;
    private EnclosingSphereContact enclosingSphereContact;
    // Start is called before the first frame update
    void Start()
    {
        enclosingSphereContact = this.gameObject.transform.parent.GetChild(0).GetComponent<EnclosingSphereContact>();
        if (enclosingSphereContact == null)
            Debug.Log("Enclosing sphere script not found");

        numBullets = StaticDataHolder.bullets;
        maxNumBullets = StaticDataHolder.maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    void DetectBulletFire()
    {
        if (numBullets > 0)
        {
            numBullets -= 1;
            enclosingSphereContact.SetBulletsText();
            StaticDataHolder.bullets = numBullets;
        }
        Debug.Log("bullet fire event detected. numBullets=" + numBullets);
    }

    public void ResetNumBullets()
    {
        numBullets = maxNumBullets;
        StaticDataHolder.bullets = numBullets;
    }

    public int GetNumBullets()
    {
        return numBullets;
    }

    public void SetNumBullets(int num)
    {
        if (num < maxNumBullets)
            numBullets = num;
        else
            numBullets = maxNumBullets;
        StaticDataHolder.bullets = numBullets;
    }
}
