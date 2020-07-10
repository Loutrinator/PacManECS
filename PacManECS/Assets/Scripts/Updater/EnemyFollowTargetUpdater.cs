using Accessor;
using Modules;
using UnityEngine;

namespace Updater {
    public class EnemyFollowTargetUpdater : IUpdater {
        public float targetDetectionDistance = 3f;
        public float destinationDetectionPrecision = 1f;
        public Material enemyScaredMaterial;
        public float minX = -10f;
        public float maxX = 10f;
        public float minY = 10f;
        public float maxY = -20f;

        public override void DoUpdate() {
            if (!GameManager.Instance.GameIsRunning) return;
            for (int i = 0; i < TAccessor<FollowTarget>.Instance.Modules.Count; ++i)
            {
            
                FollowTarget follower = TAccessor<FollowTarget>.Instance.Modules[i];

                switch (follower.state)
                {
                    case FollowTargetState.Idle:
                        SetRandomDestination(follower);
                        AudioManager.Instance.PlayEnemy();
                        follower.state = FollowTargetState.Patrolling;
                        break;
                    case FollowTargetState.Patrolling :
                        CheckDistanceToDestination(follower);
                        CheckDistanceToTarget(follower);
                        break;
                    case FollowTargetState.Chasing :
                        RefreshTargetDestination(follower);
                        CheckKillPacMan(follower);
                        break;
                    case FollowTargetState.RunAway :
                        RunFromTarget(follower);
                        
                        break;
                }

                if (GameManager.Instance.isFruitActive)
                {
                    if(follower.state != FollowTargetState.RunAway) SetScared(follower);
                }
                else
                {
                    if(follower.state == FollowTargetState.RunAway) SetIdle(follower);
                }
            }
        }

        void CheckDistanceToDestination(FollowTarget follower)
        {
            float distanceToPacMan = (follower.transform.position - follower.navAgent.destination).magnitude;
            if (distanceToPacMan <= destinationDetectionPrecision )
            {
                SetRandomDestination(follower);
            }
        }
        void CheckDistanceToTarget(FollowTarget follower)
        {
            float distanceToPacMan = (follower.transform.position - follower.target.transform.position).magnitude;
            //Debug.Log("distanceToPacMan " + distanceToPacMan);
            if (distanceToPacMan <= targetDetectionDistance)
            {
                SetTargetAsDestination(follower);
                AudioManager.Instance.StopEnemy();
                AudioManager.Instance.PlayChasing();
                follower.state = FollowTargetState.Chasing;
            }
        }
        void CheckKillPacMan(FollowTarget follower)
        {
            float distanceToPacMan = (follower.transform.position - follower.target.transform.position).magnitude;
            if (distanceToPacMan <= destinationDetectionPrecision)
            {
                TargetEdibleModule pacPac = TAccessor<TargetEdibleModule>.Instance.Get(follower.target);
                KillPlayerScript.KillPlayer(pacPac);
            }
        }
        void SetRandomDestination(FollowTarget follower)
        {
            //Debug.Log("SetRandomDestination");
            
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Vector3 d = new Vector3(x, 0, y);
            
            follower.navAgent.SetDestination(d);
            follower.navAgent.isStopped = false;
            
            //Debug.Log("d " + d + " destination " + follower.navAgent.destination);
        }
        void SetTargetAsDestination(FollowTarget follower)
        {
            //Debug.Log("SetTargetAsDestination");
            follower.navAgent.SetDestination(follower.target.transform.position);
            follower.navAgent.isStopped = false;
            //Debug.Log("FOLLOWING PLAYER");
        }
        void RefreshTargetDestination(FollowTarget follower)
        {
            follower.navAgent.SetDestination(follower.target.transform.position);
        }

        void SetScared(FollowTarget follower)
        {
            //Debug.Log("SetScared for " + follower.name);
            follower.mr.material = enemyScaredMaterial;
            follower.state = FollowTargetState.RunAway;
        }
        void SetIdle(FollowTarget follower)
        {
            //Debug.Log("SetIdle for " + follower.name);
            follower.mr.material = follower.color;
            follower.state = FollowTargetState.Idle;
        }
        
        void RunFromTarget(FollowTarget follower)
        {
            //Debug.Log("RunFromTarget for " + follower.name);
            var followerTransform = follower.transform;
            var followerPosition = followerTransform.position;
            Vector3 dir = followerPosition - follower.target.transform.position;
            Vector3 newPos = followerPosition + dir;
            follower.navAgent.SetDestination(newPos);
        }
        
        
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 a = new Vector3(minX,0,maxY);
            Vector3 b = new Vector3(maxX,0,maxY);
            Vector3 c = new Vector3(maxX,0,minY);
            Vector3 d = new Vector3(minX,0,minY);
            Gizmos.DrawLine(a,b);
            Gizmos.DrawLine(b,c);
            Gizmos.DrawLine(c,d);
            Gizmos.DrawLine(d,a);
            if (Application.isPlaying)
            {
                for (int i = 0; i < TAccessor<FollowTarget>.Instance.Modules.Count; ++i)
                {
                
                    FollowTarget follower = TAccessor<FollowTarget>.Instance.Modules[i];
                
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(follower.navAgent.destination,follower.transform.position);
                }
            }
        }
    }
}