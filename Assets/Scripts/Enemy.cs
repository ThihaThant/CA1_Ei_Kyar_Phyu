//second script for the vision

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public enum Enemy_state
    {
        idle,
        chase,
        attack,
        patrol
    }

    public Enemy_state _state;
    public NavMeshAgent _nav;
    public Animator _ani;
    public GameObject Target_obj;
    public float Attack_range, Notice_range;
    public int patrolList = 0;
    public int Patrol_index;
    public float VisionAngle = 45f;
    public float VisionRange = 10f;
    private Animator[] animators;
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>();
        // _state = Enemy_state.idle;
        animators = GetComponentsInChildren<Animator>();
    }

    private bool PlayerInSight()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            if (Vector3.Angle(direction, transform.forward) < VisionAngle / 2f)
            {
                int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
                if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, VisionRange, playerLayerMask))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void Update()
    {
        List<GameObject> selectedPatrolList = GetSelectedPatrolList();

        switch (_state)
        {
            case Enemy_state.idle:
                if (PlayerInSight())
                {
                    Target_obj = GameObject.FindGameObjectWithTag("Player");
                    _state = Enemy_state.chase;
                }
                if(!Target_obj)
                {
                    _state = Enemy_state.patrol;
                    Target_obj = selectedPatrolList[0];
                }
                break;

            case Enemy_state.patrol:
                if (PlayerInSight())
                {
                    Target_obj = GameObject.FindGameObjectWithTag("Player");
                    _state = Enemy_state.chase;
                }
                else
                {
                    if (Vector3.Distance(Target_obj.transform.position, transform.position) > 0.1f)
                    {
                        _nav.SetDestination(Target_obj.transform.position);
                    }
                    else
                    {
                        if (Patrol_index == selectedPatrolList.Count - 1)
                        {
                            Patrol_index = 0;
                        }
                        else
                        {
                            Patrol_index++;
                        }
                        Target_obj = selectedPatrolList[Patrol_index];
                    }
                }
                break;

            case Enemy_state.chase:
                
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (PlayerInSight() || (Vector3.Distance(player.transform.position, transform.position) < Notice_range))
                {
                    Target_obj = GameObject.FindGameObjectWithTag("Player");

                    if (Vector3.Distance(Target_obj.transform.position, transform.position) < Attack_range)
                    {
                      
                        Vector3 targetPosition = new Vector3(Target_obj.transform.position.x, transform.position.y, Target_obj.transform.position.z);
                        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

                        if (Vector3.Angle(transform.forward, directionToTarget) > 0.1f)
                        {
                            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _nav.angularSpeed * Time.deltaTime);
                            _ani.SetFloat("Blend", 0);
                        }
                        else
                        {
                            _state = Enemy_state.attack;
                            SetTriggerAllLOD("Attack");
                            _nav.isStopped = true;
                        }
                    }
                    else
                    {
                        SetTriggerAllLOD("Run");
                        _nav.SetDestination(Target_obj.transform.position);
                    }
                }
                else
                {
                    Target_obj = null;
                   // _state = Enemy_state.idle;
                }
                break;

            case Enemy_state.attack:
               
                // Implement attack logic or cooldown here
                break;
        }

       _ani.SetFloat("Blend", _nav.velocity.magnitude);
    }

    public void Attack()
    {
       // if (Target_obj != null && Target_obj.CompareTag("Player"))
       // {
            Target_obj.GetComponent<Player>().Damage(10f);
       // }
    }

    public void AttackFinish()
    {
        _state = Enemy_state.chase;
        _nav.isStopped = false;
    }

    private List<GameObject> GetSelectedPatrolList()
    {
        List<GameObject> selectedList = PatrolPointsList.me.Patrol_list; // Default

        switch (patrolList)
        {
            case 0:
                selectedList = PatrolPointsList.me.Patrol_list;
                break;
            case 1:
                selectedList = PatrolPointsList.me.Patrol_list_one;
                break;
            case 2:
                selectedList = PatrolPointsList.me.Patrol_list_two;
                break;
            case 3:
                selectedList = PatrolPointsList.me.Patrol_list_three;
                break;
            case 4:
                selectedList = PatrolPointsList.me.Patrol_list_four;
                break;
            case 5:
                selectedList = PatrolPointsList.me.Patrol_list_five;
                break;
            case 6:
                selectedList = PatrolPointsList.me.Patrol_list_six;
                break;
            case 7:
                selectedList = PatrolPointsList.me.Patrol_list_seven;
                break;
            case 8:
                selectedList = PatrolPointsList.me.Patrol_list_eight;
                break;
            case 9:
                selectedList = PatrolPointsList.me.Patrol_list_nine;
                break;
            case 10:
                selectedList = PatrolPointsList.me.Patrol_list_ten;
                break;

        }

        return selectedList;
    }
    
    public void SetTriggerAllLOD(string trigger)//animate all lod
    {
        foreach (var item in animators)
        {
            item.SetTrigger(trigger);
        }
    }
}
