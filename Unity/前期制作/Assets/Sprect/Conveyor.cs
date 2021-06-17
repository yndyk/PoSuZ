using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConveyorSamples 
{
    public class Conveyor : MonoBehaviour
    {
        public bool InOn = false;//ベルトコンベアの稼働状況
        public float TargetDriveSpeed = 3.0f;//ベルトコンベアの設定速度
        public float CurentSpeed { get { return _currentSpeed; } }//現代のベルトコンベアの速度
        public Vector3 DriveDirection = Vector3.forward;//ベルトコンベアが物体を動かす方向
        [SerializeField] private float _forcePower = 50f;//コンベアが物体を押す力(加速力)
        private float _currentSpeed = 0;
        private List<Rigidbody2D> _rigidbodies = new List<Rigidbody2D>();
        // Start is called before the first frame update
        void Start()
        {
            //方向は正規化しておく
            DriveDirection = DriveDirection.normalized;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _currentSpeed = InOn ? TargetDriveSpeed : 0;
            //消滅したオブジェクトは除去する
            _rigidbodies.RemoveAll(r => r == null);
            foreach (var r in _rigidbodies) 
            {
                //物体の移動速度のベルトコンベア方向の成分だけを取り出す
                var objectSpeed = Vector3.Dot(r.velocity,DriveDirection);

                //目標以下なら加速する
                if (objectSpeed < Mathf.Abs(TargetDriveSpeed)) 
                {
                    r.AddForce(DriveDirection * _forcePower,ForceMode2D.Force);
                }
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rigidbodies.Add(rigidBody);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rigidbodies.Remove(rigidBody);
        }

    }
}

