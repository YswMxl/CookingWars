using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

interface isViablePlate
{
    public void Interact();
}

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    float v;
    float h;
    CharacterController controler;
    Animator anim;
    public Transform interactionPoint;
    [SerializeField] float interactionRange;//No se que rango poner
    [SerializeField] float speed;
    public int points;

    List<string> isViablePlate = new List<string> { "Smoothie", "Pizza" };
    List<string> isViableIngridient = new List<string> { "NutNBolt", "Fuse", "Antifreeze", "Oil", "Gear" };

    string currentPlate;
    List<string> currentPlateIngridients;
    bool plated = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        controler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInput = new Vector3 { 
            //Rellenar en codigo player
        };
        if (playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }
        Vector3 movevector = transform.TransformDirection(playerInput);
        Movement(playerInput);
    }
    public void Movement(Vector3 inputPlayer)
    {
        controler.Move(speed * inputPlayer * Time.deltaTime);
    }
    public void Check()
    {
        Ray r = new Ray(interactionPoint.position, interactionPoint.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactionRange))
        {
            for (int i = 0; i < 4; i++)
            {
                string checkedCook = hitInfo.collider.gameObject.tag;
                if (isViablePlate.Contains(checkedCook))
                {
                    Plate(checkedCook);
                }
                else if (isViableIngridient.Contains(checkedCook))
                {
                    AddIngridient(checkedCook);
                }
                else if (checkedCook == "Client")
                {
                    ClientScript currentClient = hitInfo.collider.gameObject.GetComponent<ClientScript>();
                    RankPlate(currentClient.GiveOrderIngridients(), currentClient.GiveOrderPlate(), currentClient.GiveTimeTaken());
                }
            }
        }
    }
    void CleanPlate()
    {
        currentPlateIngridients.Clear();
        plated = false;
    }
    public void Plate(string plateType)
    {
        if (plated)
        {
            currentPlateIngridients.Clear();
        }
        currentPlate = plateType;
        plated = true;
    }
    public void AddIngridient(string ingridientType)
    {
        if (currentPlateIngridients.Count < 5)
        {
            currentPlateIngridients.Add(ingridientType);
        }
        else
        {
            //Cant add ingridient
            //anim.SetTrigger("Effort");

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    public string RankPlate(List<string> consumerOpinionIngridient, string consumerOpinionPlate,int consumerPatience)
    {
        int plateValue = 5;
        int diff = consumerOpinionIngridient.Count();
        if (consumerOpinionPlate != currentPlate)
        {
            plateValue -= 3;
        }
        string returnCode;
        bool k = true;
        int l = 0;
        int res = diff - currentPlateIngridients.Count();
        plateValue -= res + consumerPatience;
        while (plateValue > 0 && k)
        {
            if (consumerOpinionIngridient[l] != currentPlateIngridients[l])
            {
                plateValue--;
            }
            l++;
            if (l == diff)
            {
                k = false;
            }
        }
        points += (diff * plateValue);
        switch (plateValue)
        {
            case 5:
                returnCode = "Perfect";
                break;
            case 4:
                returnCode = "Meh";
                break;
            case 3:
                returnCode = "Meh";
                break;
            case 2:
                returnCode = "Meh";
                break;
            default:
                returnCode = "Bad";
                break;
        }
        CleanPlate();
        return returnCode;
    }
}
