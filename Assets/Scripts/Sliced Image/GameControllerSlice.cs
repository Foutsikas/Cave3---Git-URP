using UnityEngine;
using System.Linq;
public class GameControllerSlice : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PicturePieces;
    [SerializeField]
    private GameObject WinPanel;

    public static bool youWin = false;
    private readonly int[] randomZ = new int[] {90, 180, 270};
    private int randomIndex;

    void Start()
    {
        Randomizer();
        WinPanel.SetActive(false);
    }

    void Update()
    {
        RotationCheck();
    }

    //Randomizes the rotation of the Z-axis value.
    private void Randomizer()
    {
        for (int i = 0; i < PicturePieces.Length; i++)
        {
            randomIndex = Random.Range(1, randomZ.Length);
            PicturePieces[i].transform.Rotate(0, 0, randomZ[randomIndex]);
        }
    }

    //Checks if all the pieces are back to the original 0 Z-axis rotation.
    private void RotationCheck()
    {
        if (PicturePieces.All(pic => pic.transform.up == Vector3.up))
        {
            youWin = true;
            WinPanel.SetActive(true);
        }
    }
}
