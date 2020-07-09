using System;
using Accessor;
using Modules;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Updater {
    public class FollowTargetUpdater : IUpdater
    {
        public float targetDistanceThreshold = 1f;
        public float detectionDistance = 3f;
        public float minX = -10f;
        public float maxX = 10f;
        public float minY = 10f;
        public float maxY = -20f;
        public bool dumbModeActivated = false;
        public override void DoUpdate()
        {
            for (int i = 0; i < TAccessor<FollowTarget>.Instance.Modules.Count; ++i)
            {
                FollowTarget follower = TAccessor<FollowTarget>.Instance.Modules[i];
                Debug.Log("Follower ID : " + i + ", stopped : " + follower.navAgent.isStopped + " distance : " + (follower.transform.position - follower.navAgent.destination).magnitude);
                if (!dumbModeActivated)
                {
                    if (!follower.isChasing)//si l'enemi chasse personne
                    {
                        SetTargetAsDestination(follower);
                    }
                }
                else
                {
                    if (!follower.isChasing)//si l'enemi chasse personne
                    {
                        SetRandomDestination(follower);
                    }else if (follower.isChasing || (follower.transform.position - follower.navAgent.destination).magnitude <=
                              targetDistanceThreshold)
                    {
                        SetRandomDestination(follower);
                    }

                    if (!follower.chasingTarget) //si l'enemi ne poursuit pas un pacMan
                    {
                        if ((follower.transform.position - follower.target.transform.position).magnitude <=
                            detectionDistance) //si l'enemi est assez proche d'un pacMan
                        {
                            SetTargetAsDestination(follower);
                        }

                        if (follower.isChasing || (follower.transform.position - follower.navAgent.destination).magnitude <=
                            targetDistanceThreshold)
                        {
                            //SetRandomDestination(follower);
                        }
                    } 
                }
                
            }
        }

        void SetRandomDestination(FollowTarget follower)
        {
            Debug.Log("SetRandomDestination");
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            follower.navAgent.SetDestination(new Vector3(x,0,y));
            follower.navAgent.isStopped = false;
            follower.isChasing = true;
        }
        void SetTargetAsDestination(FollowTarget follower)
        {
            Debug.Log("SetTargetAsDestination");
            follower.navAgent.SetDestination(follower.target.transform.position);
            follower.navAgent.isStopped = false;
            follower.isChasing = true;
            follower.chasingTarget = true;
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 A = new Vector3(minX,0,maxY);
            Vector3 B = new Vector3(maxX,0,maxY);
            Vector3 C = new Vector3(maxX,0,minY);
            Vector3 D = new Vector3(minX,0,minY);
            Gizmos.DrawLine(A,B);
            Gizmos.DrawLine(B,C);
            Gizmos.DrawLine(C,D);
            Gizmos.DrawLine(D,A);
        }
    }
}
