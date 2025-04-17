using UnityEngine;

public class FlashlightFreeze : MonoBehaviour
{
    public float maxDistance = 20f;

    private MonsterBehavior currentMonster;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            MonsterBehavior monster = hit.collider.GetComponent<MonsterBehavior>();

            if (monster != null)
            {
                if (currentMonster != null && currentMonster != monster)
                    currentMonster.SetFrozen(false);

                currentMonster = monster;
                currentMonster.SetFrozen(true);
            }
            else if (currentMonster != null)
            {
                currentMonster.SetFrozen(false);
                currentMonster = null;
            }
        }
        else if (currentMonster != null)
        {
            currentMonster.SetFrozen(false);
            currentMonster = null;
        }
    }
}