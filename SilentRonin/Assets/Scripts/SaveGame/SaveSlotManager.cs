using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveSlotManager : MonoBehaviour
{
    [System.Serializable]
    public class SlotUI
    {
        public string slotName; // Slot1, Slot2, Slot3
        public TMP_Text slotLabel;
        public TMP_Text infoText;
    }

    public SlotUI[] slots;

    private void Start()
    {
        RefreshSlots();
    }

    public void RefreshSlots()
    {
        foreach (var slot in slots)
        {
            if (SaveSystem.HasSave(slot.slotName))
            {
                SaveSlotData data = SaveSystem.LoadGame(slot.slotName);
                slot.infoText.text = $"Lv.{data.level} - {data.areaName}\n{data.playTime:F1}h";
            }
            else
            {
                slot.infoText.text = "No Data";
            }
        }
    }

    public void SelectSlot(string slotName)
    {
        if (SaveSystem.HasSave(slotName))
        {
            // load game đã có
            SaveSlotData data = SaveSystem.LoadGame(slotName);
            Debug.Log($"Loading {slotName}...");
            SceneManager.LoadScene("Map1");
        }
        else
        {
            // tạo save mới
            SaveSlotData newData = new SaveSlotData
            {
                slotName = slotName,
                level = 1,
                areaName = "Village",
                playTime = 0,
                hasData = true
            };
            SaveSystem.SaveGame(newData);
            Debug.Log($"Created new save: {slotName}");
            SceneManager.LoadScene("Map1");
        }
    }
}
