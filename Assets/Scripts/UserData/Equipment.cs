public enum EquipmentType
{
    Head,
    UpperBody,
    LowerBody,
    Hand,
    Shoes,
    Face,
    Earring,
    Necklace,
    Ring,
    UpperAccessory,
    LowerAccessory,
}


[System.Serializable]
public class Equipment
{

    public int code;
    public EquipmentType type;

}
