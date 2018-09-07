using UniRx;

[System.Serializable]
public class Character
{

    public string name;
    public int hp;
    public int atk;
    public int def;
    public int matk;
    public int mdef;
}


public class CharacterModel
{
    public ReactiveProperty<int> hpRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> atkRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> defRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> mAtkRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> mDefRp = new ReactiveProperty<int>();

    Character character;


    public CharacterModel(Character character)
    {
        this.character = character;
    }

    public void SetCharacter()
    {

    }

}
