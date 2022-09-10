using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainUICanvas : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI districtName,buildingName;

    public IntUnityAction unityAction;

    public GameObject DistrictsCanvasNew, MainSpotsCanvasNew, BuildingsInfoCanvasNew, BuildingsCamPositions, DistrictHolder,ZoomIn,ZoomOut;

    private void Start()
    {
        foreach (Transform T in DistrictHolder.transform)
        {
            T.gameObject.GetComponent<Button>().onClick.AddListener(() => Highlight_Districts(T.gameObject));
        }
        foreach (Transform T in MainSpotsCanvasNew.transform)
        {
            T.gameObject.SetActive(false);
        }
        for (int i = 0; i < MainSpotsCanvasNew.transform.childCount; i++)
        {
            foreach (Transform T1 in MainSpotsCanvasNew.transform.GetChild(i).transform.GetChild(0).transform)
            {
                T1.gameObject.GetComponent<Button>().onClick.AddListener(() => Highlight_Buildings(T1.gameObject.name));
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    #region Buildings
    public void ChangeBuildingNameInAdress(string currentBuildingName) 
    {
        buildingName.text = currentBuildingName;
    }
    public void Highlight_Buildings(string buildingName)
    {
        foreach (Transform T in MainSpotsCanvasNew.transform)
        {
            T.gameObject.SetActive(false);
        }
        switch (buildingName) 
        {
            case "BurjKalifa":
                AssignBuildingPoint(0);
                break;
            case "PalmHotel":
                AssignBuildingPoint(1);
                break;
            case "AddressSkyView":
                AssignBuildingPoint(2);
                break;
            case "HolidayInnHotel":
                AssignBuildingPoint(3);
                break;
            case "Mercure":
                AssignBuildingPoint(4);
                break;
            case "Sheraton":
                AssignBuildingPoint(5);
                break;
            case "Kempinski":
                AssignBuildingPoint(6);
                break;
            case "DusitD2KenzHotel":
                AssignBuildingPoint(7);
                break;
            case "MediaByRotana":
                AssignBuildingPoint(8);
                break;
            case "IBIS&NovotelHotel":
                AssignBuildingPoint(9);
                break;
            case "NaraCafe":
                AssignBuildingPoint(10);
                break;
            case "LeMeridien":
                AssignBuildingPoint(11);
                break;
            case "WyndhamDubaiMarina":
                AssignBuildingPoint(12);
                break;
            case "MazahRestaurant":
                AssignBuildingPoint(13);
                break;
            case "FirstCentralHotelSuites":
                AssignBuildingPoint(14);
                break;
            case "ClassHotelApartments":
                AssignBuildingPoint(15);
                break;
            case "GrandCosmopolitanHotelDubaiAlBarshaAlDubaiUnitedArabEmirates":
                AssignBuildingPoint(16);
                break;
            case "HiltonDubaiAlHabtoorCity":
                AssignBuildingPoint(17);
                break;
            case "MajesticCityRetreatHotel":
                AssignBuildingPoint(18);
                break;
            case "Dummy":
                AssignBuildingPoint(19);
                break;
            default:
                break;
        }
    }
    public void AssignBuildingPoint(int i)
    {
        GameManager.Instance.CameraController.MoveCameraToCertainPoint(BuildingsCamPositions.transform.GetChild(i).transform, false, 800);
        GameManager.Instance.UIManager.mainUICanvas.ZoomIn.gameObject.SetActive(false);
        GameManager.Instance.UIManager.mainUICanvas.ZoomOut.gameObject.SetActive(false);
        GameManager.Instance.GridSystem.ChangeBuilding(i);
        StartCoroutine(EnableInfo(i));
    }
    IEnumerator EnableInfo(int i)
    {
        yield return new WaitForSeconds(2.5f);
        if (BuildingsInfoCanvasNew.transform.childCount > i)
        {
            BuildingsInfoCanvasNew.transform.GetChild(i)?.gameObject.SetActive(true);
        }
    }

    #endregion

    #region Districts
    public void Highlight_Districts(GameObject district)
    {
        GameManager.Instance.GridSystem.ChangeDistrict(district.GetComponent<DistrictButton>().districtData.name);
    }
    public void ChangeDistrictNameInAdress(string currentDistrictName)
    {
        districtName.text = currentDistrictName;
    }

    #endregion

    //private void OnDisable() {

    //        for (int i = 0; i < MainSpotsCanvasNew.transform.childCount; i++) {
    //            foreach (Transform T1 in MainSpotsCanvasNew.transform.GetChild(i).transform.GetChild(0).transform) {
    //            if (T1.gameObject.GetComponent<Button>() != null) T1.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    //            }
    //        }


    //}

}
