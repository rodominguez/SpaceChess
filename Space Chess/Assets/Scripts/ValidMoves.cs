using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidMoves : MonoBehaviour
{
    [SerializeField] private DragAndDrop dragAndDrop;
    [SerializeField] private ShipMovement shipMovement;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private float returnSpeed;
    [SerializeField] private float timeToReachTarget;
  
    private bool isFirstDrag;
    private int invalidMoves;
    private bool isReturningToValidMove;
    private bool isValid;

    private float t;

    private void Update()
    {
        if (isReturningToValidMove)
        {
            ReturnToValidMove();
        }
        else if (dragAndDrop.GetIsDragged() && !isFirstDrag)
        {
            isValid = false;
            isFirstDrag = true;
        }
        else if (!dragAndDrop.GetIsDragged() && dragAndDrop.GetIsFinalPositionSet() && isFirstDrag)
        {
            isFirstDrag = false;
            CheckValidMove();
            //levelManager.GetCurrentLevel().SubstractBounce();
        }
    }

    private void CheckValidMove()
    {
        Vector3 result = dragAndDrop.GetInitialPosition() - transform.position;
        result.x *= result.x;
        result.y *= result.y;

        result.x = Mathf.RoundToInt(result.x);
        result.y = Mathf.RoundToInt(result.y);

        isValid = result.x == result.y;

        isValid &= IsBlackHoleInMiddle();

        if (!isValid)
        {
            t = 0;
            invalidMoves++;
            isReturningToValidMove = true;
            dragAndDrop.enabled = false;
            shipMovement.enabled = false;
            GetComponent<ShipMovement>().SetIsShoot(false);
        }
        else
        {
            DestroyRay();
        }   
    }

    private bool IsBlackHoleInMiddle()
    {
        RaycastHit[] hits;
        Vector3 direction = transform.position - dragAndDrop.GetInitialPosition();
        hits = Physics.RaycastAll(dragAndDrop.GetInitialPosition(), direction, Vector3.Distance(transform.position, dragAndDrop.GetInitialPosition()));

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.tag.Equals("BlackHole"))
                return false;
        }

        return true;
    }

    private void DestroyRay()
    {
        RaycastHit hit;
        Vector3 direction = transform.position - dragAndDrop.GetInitialPosition();

        while (Physics.Raycast(dragAndDrop.GetInitialPosition(), direction, out hit, Vector3.Distance(transform.position, dragAndDrop.GetInitialPosition())))
        {
            Debug.DrawRay(transform.position, direction * 10, Color.yellow);
            if (!hit.transform.gameObject.tag.Equals("Game Achievement"))
                return;

            hit.transform.gameObject.GetComponent<Destroy>().DestroyObject();
        }
    }

    private void ReturnToValidMove()
    {
        if (transform.position.Equals(dragAndDrop.GetInitialPosition()) || AlmostEqual(transform.position, dragAndDrop.GetInitialPosition()))
        {
            transform.position = dragAndDrop.GetInitialPosition();
            isReturningToValidMove = false;
            dragAndDrop.enabled = true;
            shipMovement.enabled = true;
            GetComponent<ShipMovement>().SetIsShoot(true);
            return;
        }

        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(transform.position, dragAndDrop.GetInitialPosition(), t);
    }

    private bool AlmostEqual(Vector3 v1, Vector3 v2)
    {
        return Mathf.Abs(v1.x - v2.x) < 0.1 && Mathf.Abs(v1.y - v2.y) < 0.1 && Mathf.Abs(v1.z - v2.z) < 0.1;
    }

    public int GetInvalidMoves()
    {
        return invalidMoves;
    }

    public void ResetMoves()
    {
        invalidMoves = 0;
    }

    public bool GetIsValid()
    {
        return isValid;
    }
}
