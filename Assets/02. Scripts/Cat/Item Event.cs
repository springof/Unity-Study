using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType {Pipe, Cherry, Both}
    public ColliderType colliderType;

    public GameObject particle;
    public GameObject cherry;
    public GameObject pipe;

    public float moveSpeed = 0.0001f;
    public float returnPosX = 10f;
    public float randomPosY;
    public Vector3 returnPos;

    private Vector3 initPos;

    private void Awake()
    {
        initPos = transform.position;
    }

    private void OnEnable()
    {
        SetRandomSetting(initPos.x);
    }

    void Update()
    {
        //배경 왼쪽으로 이동
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        //이미지가 왼쪽으로 이동하여 화면 밖으로 나갔을 때, 위치를 초기화
        if (transform.position.x <= -returnPosX)
            SetRandomSetting(returnPosX);
    }

    public void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-7.5f, -3.5f); // y축 위치를 랜덤으로 설정
        transform.position = new Vector3(posX, randomPosY, 0);

        colliderType = (ColliderType)Random.Range(0, 3);

        pipe.SetActive(false);
        cherry.SetActive(false);
        particle.SetActive(false);

        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Cherry:
                cherry.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                cherry.SetActive(true);
                break;
        }
    }
}
