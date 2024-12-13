namespace DecouplingPatterns.EventQueue
{
    using System.Collections.Generic;
    using UnityEngine;

    public class EventQueue : MonoBehaviour
    {
        public GameObject PosIndicator;
        public Holder Holder;
        private Queue<Transform> _destinationQueue;
        private Transform _destination;
        public float Speed = 10;

        private void Start()
        {
            MouseInputManager.Instance.OnMouseClick += AddDestination;
            _destinationQueue = new Queue<Transform>();
        }

        private void OnDestroy()
        {
            MouseInputManager.Instance.OnMouseClick -= AddDestination;
        }

        private void AddDestination()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //将屏幕坐标转换为世界坐标射线
            /*
             *? 在三维空间中，射线是一个从某个起点开始并沿着某个方向无限延伸的线。Unity 中的Ray 结构体有两个主要属性：
             *? origin：射线的起点，通常是一个三维坐标 (x, y, z)
             *? direction：射线的方向，也是一个三维向量，表示射线延伸的方向
             *? GetPoint(float distance)方法接受一个浮点数参数，它指定了从射线起点出发的距离。该方法会计算并返回射线上距离起点distance单位长度的那个点的坐标
             * GetPoint(10)返回的是距离射线起点（即相机位置）10 个单位远的点。这意味着无论在屏幕上哪里点击，都会得到一个与相机保持固定距离的新位置作为目的地
             * 择 10 个单位作为一个固定值是为了确保生成的目的地不会太近或太远
             * 如果距离设置得太小，可能会导致目标点出现在相机前非常靠近的地方；
             * 而如果太大，则可能使目标点超出合理范围或难以控制。
             */
            Vector3 destination = ray.GetPoint(10);
            GameObject indicator = Instantiate(PosIndicator, destination, Quaternion.identity);
            _destinationQueue.Enqueue(indicator.transform);
        }

        private void Update()
        {
            if (_destination == null && _destinationQueue.Count > 0)
            {
                _destination = _destinationQueue.Dequeue();
            }

            if (_destination == null) return;

            Vector3 startPosition = Holder.transform.position;
            Vector3 destinationPosition = _destination.position;

            float distance = Vector3.Distance(startPosition, destinationPosition); //计算当前位置与目标位置之间的距离
            //使用 Lerp 方法平滑地向目标位置移动
            startPosition = Vector3.Lerp(startPosition, destinationPosition, Mathf.Clamp01((Time.deltaTime * Speed) / distance));
            Holder.transform.position = startPosition;
            Holder.ExecuteEvent(destinationPosition);

            if (distance < 0.01f)
            {
                Destroy(_destination.gameObject);
                _destination = null;
            }
        }
    }
}