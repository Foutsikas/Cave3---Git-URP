using UnityEngine;
using System.Linq;
using System.Collections;

public class GameControllerSlice : MonoBehaviour
{
    [SerializeField] private GameObject[] PicturePieces;
    [SerializeField] private GameObject WinPanel;

    public static bool youWin = false;
    private readonly int[] randomZ = new int[] { 90, 180, 270 };
    private int randomIndex;
    private bool isRotating = false; // Add a flag to control rotation

    void Start()
    {
        Randomizer();
        WinPanel.SetActive(false);
    }

    void Update()
    {
        if (!isRotating) // Check if not rotating before allowing rotation check
        {
            RotationCheck();
        }
    }

    //Randomizes the rotation of the Z-axis value.
    private void Randomizer()
    {
        for (int i = 0; i < PicturePieces.Length; i++)
        {
            randomIndex = Random.Range(0, randomZ.Length);
            PicturePieces[i].transform.Rotate(0, 0, randomZ[randomIndex]);
        }
    }

    //Checks if all the pieces are back to the original 0 Z-axis rotation.
    private void RotationCheck()
    {
        if (PicturePieces.All(pic => pic.transform.up == Vector3.up))
        {
            youWin = true;
            isRotating = true; // Lock rotation during the check
            DisableColliders(); // Disable colliders when the puzzle is solved
            StartCoroutine(Timer());
        }
    }

    //Disables the Box Collider 2d Component to allow the user to see the completed image before the "win box" pops up.
    private void DisableColliders()
    {
        foreach (var piece in PicturePieces)
        {
            BoxCollider2D collider = piece.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the Box Collider 2D component
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        WinPanel.SetActive(true);
    }
}
