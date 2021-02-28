using UnityEngine.UI;
using UnityEngine;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI")]
    public Image fillImage;
    public Text startText;
    public Text endText;

    [Header("Player & Endline")]
    public Transform player;
    public Transform endLine;

    private Vector3 endLinePos;
    private float distance;

    public bool levelFinish = false;

    private void Start()
    {
        endLinePos = endLine.position;
        distance = GetDistance();
    }
    public void LevelTexts(int level)
    {
        startText.text = level.ToString();
        endText.text = (level + 1).ToString();
    }

    float GetDistance()
    {
        return Vector3.Distance(player.position, endLinePos);
        //return (endLinePos - player.position).sqrMagnitude; Performance
    }

    void FillProgress(float value)
    {
        fillImage.fillAmount = value;
    }

    private void Update()
    {
        if (player.position.z <= endLine.position.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(distance, 0f, newDistance);
            FillProgress(progressValue);
        }
        else if (player.position.z >= endLine.position.z)
        {
            levelFinish = true;
        }
    }
}
