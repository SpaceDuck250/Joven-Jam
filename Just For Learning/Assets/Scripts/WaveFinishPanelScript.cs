using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveFinishPanelScript : MonoBehaviour
{
    public WaveManagerScript waveManagerScript;

    public Animator animator;
    public TextMeshProUGUI waveNumberText;

    private void Awake()
    {
        waveManagerScript.OnNewWaveStart += OnWaveStart;

    }

    private void OnDestroy()
    {
        waveManagerScript.OnNewWaveStart -= OnWaveStart;

    }

    private void OnWaveStart(WaveData waveData)
    {
        waveNumberText.text = waveData.waveName;
        animator.SetTrigger("ShowWavePanel");
    }

}
