using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public List<Building> buildings = new List<Building>();
    public List<District> districts = new List<District>();
    public List<Sprite> HealthLevel = new List<Sprite>();

    public Transform buildingsHolder;
    public Material selectedMaterial, mediumHelathSelectedBuilding, badHelathSelectedBuilding;
    public Material currentBuildingMaterial;
    public SearchBox searchBox;

    public bool m_isValid;
    public bool reset;

    Building target;
    //runtime
   // private Building target;
    private List<IleaderBoardMember> boardMembers = new List<IleaderBoardMember>();

    /// <summary>
    /// ObserverPattern Implementation for Leaderboard elements
    /// </summary>
    /// <param name="boardMember"></param>
    public void AssignToBoardMembers(IleaderBoardMember boardMember) {
        boardMembers.Add(boardMember);
    }
    public List<LeaderBoardMember> InvokeBoardMembers() {
        List<LeaderBoardMember> leaderBoardMembers = new List<LeaderBoardMember>();

        int boardIndex = boardMembers.Count - 1;
        for (int i = 0; i < boardMembers.Count; i++) {
            leaderBoardMembers.Add(boardMembers[i].GetMember());
        }
        return leaderBoardMembers;
    }
    public void FilterBuildings()
    {
        if (searchBox && searchBox.SearchWordInputField?.text != "")
        {
            searchBox.DeactivateAllBuildingBtnsExceptForInSearch();
        }
    }
    public void GoToOrigin()
    {
        GameManager.Instance.CameraController.SetCameraBack();
        ChangeBuildingMaterialToOriginal();

        if (GameManager.Instance.UIManager.mainUICanvas.animator != null)
        {
            if (!GameManager.Instance.UIManager.mainUICanvas.animator.GetBool("FadeIn"))
            {
                GameManager.Instance.UIManager.mainUICanvas.buildingName.text = "Building";
            }
        }
        foreach (Transform T in GameManager.Instance.UIManager.mainUICanvas.MainSpotsCanvasNew.transform)
        {
            T.gameObject.SetActive(false);
        }
        GameManager.Instance.UIManager.mainUICanvas.BuildingsInfoCanvasNew.SetActive(false);
        //foreach (Transform T in GameManager.Instance.UIManager.mainUICanvas.BuildingsInfoCanvasNew.transform)
        //{
        //    T.gameObject.SetActive(false);
        //}
        StartCoroutine(EnableDistricts());
        reset = false;
    }
    public void ChangeBuilding(int buildingIndex)
    {
        Debug.Log(buildingIndex);
        target = buildingsHolder.transform.GetChild(buildingIndex).GetComponent<Building>();
        //ChangeBuildingMaterialToSelected();

        GameManager.Instance.UIManager.mainUICanvas.ChangeBuildingNameInAdress(target?.buildingData.name);
        Debug.Log("Building name is : " + GameManager.Instance.UIManager.mainUICanvas.buildingName);
    }
    public void ChangeBuildingMaterialToSelected()
    {
        currentBuildingMaterial = target.GetComponent<Renderer>().material;
        target.GetComponent<Renderer>().material = selectedMaterial;
    }
    public void ChangeBuildingMaterialToSelected(int buildingIndex, Material material, bool isChangeCurrent = false)
    {
        if (!isChangeCurrent)
        {
            target = buildingsHolder.transform.GetChild(buildingIndex).GetComponent<Building>();
        }
        target.GetComponent<Renderer>().material = material;
    }
    public void ChangeBuildingMaterialToOriginal()
    {
        if (target)
        {
            target.GetComponent<Renderer>().material = currentBuildingMaterial;
        }
    }
    public void ChangeDistrict(string currentDistrictName)
    {
        GameManager.Instance.UIManager.mainUICanvas.ChangeDistrictNameInAdress(currentDistrictName);
    }
    IEnumerator EnableDistricts()
    {
        yield return new WaitForSeconds(2f);
        foreach (Transform T in GameManager.Instance.UIManager.mainUICanvas.DistrictsCanvasNew.transform.GetChild(0).transform)
        {
            T.gameObject.GetComponent<Image>().enabled = true;
            T.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
       

    }
}
