using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private bool hasLanded;
    [SerializeField]
    private bool thrown;
    private Vector3 initPosition;
    [SerializeField]
    private int diceValue;

    public DiceSide[] diceSides;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            SideValueCheck();
            hasLanded = true;
            rb.useGravity = false;
        }
    }

    private void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(-100,100)*1000,Random.Range(-100,100)*1000,Random.Range(-100,100)*1000, ForceMode.Impulse);
            rb.AddForce(Vector3.up *500);
        } else if (thrown && hasLanded)
        {
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    private void SideValueCheck()
    {
        foreach (DiceSide side in diceSides)
        {
            if (side.getOnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue+"has been rolled!");
            }
        }
        
    }
}
