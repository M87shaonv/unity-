using UnityEngine;
using UnityEngine.UI;

namespace DirtyFlag
{
    public class UnsavedChangesController : MonoBehaviour
    {
        // 私有布尔变量，用作“脏”标志（dirty flag），用来表示自上次保存以来是否发生了更改。
        private bool isSaved = true;
        private readonly float speed = 5f;
        public Button saveBtn;
        public GameObject warningMessage;

        private void Start()
        {
            saveBtn.onClick.AddListener(Save);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(speed * Time.deltaTime * Vector3.up);
                // 标记为已修改（未保存）
                isSaved = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(speed * Time.deltaTime * -Vector3.up);
                // 标记为已修改（未保存）
                isSaved = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime * -Vector3.right);
                // 标记为已修改（未保存）
                isSaved = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed * Time.deltaTime * Vector3.right);
                // 标记为已修改（未保存）
                isSaved = false;
            }

            warningMessage.SetActive(!isSaved); // 如果isSaved为false，显示警告信息，提示用户有未保存的更改
        }

        private void Save()
        {
            Debug.Log("Game was saved");
            isSaved = true;
        }
    }
}