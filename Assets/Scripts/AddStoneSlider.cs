using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AddStoneSlider : MonoBehaviour { 

	public GameObject Slider;
	public GameObject Grid;

	public Transform spawnPoint;

	public MeshRenderer deleteButton;
	private bool deleteMode = false;

	public void UpdatePosition() {
		Vector3 temp = Slider.transform.localPosition ;
		Grid.transform.localPosition  = new Vector3(Grid.transform.localPosition.x, 30836*temp.x + 170, Grid.transform.localPosition.z);
	}

	public void SpawnStone(int stoneId) {
		Quaternion rt = StoneSpawnHelper.GetStoneRotationById(stoneId);
        Vector3 sp = spawnPoint.position + StoneSpawnHelper.GetStoneSpawnPointOffsetById(stoneId);

        float scale = StoneSpawnHelper.GetStoneScaleById(stoneId);
        if (stoneId < 10) {
        	GameObject obj = (GameObject)Instantiate(Resources.Load("Stone0" + stoneId), sp, rt);
        	obj.transform.localScale *= scale;
        } else {
        	GameObject obj = (GameObject)Instantiate(Resources.Load("Stone" + stoneId), sp, rt);
        	obj.transform.localScale *= scale;
        }
        
	}

	public void changeColor() {
		deleteMode = !deleteMode;
		if (deleteMode) {
			deleteButton.sharedMaterial.SetColor("_Color", Color.green);
		} else {
			deleteButton.sharedMaterial.SetColor("_Color", Color.grey);
		}
	}
}