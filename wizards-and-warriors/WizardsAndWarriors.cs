using System;

abstract class Character
{
    protected bool _isVulnerable { get; set; } = false;
    protected string CharacterType { get; set; }

    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return _isVulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {CharacterType}";
    }
}

class Warrior : Character
{
    public Warrior()
        : base("Warrior") { }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    public Wizard()
        : base("Wizard")
    {
        _isVulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        return !Vulnerable() ? 12 : 3;
    }

    public override bool Vulnerable()
    {
        return _isVulnerable;
    }

    public void PrepareSpell()
    {
        _isVulnerable = false;
    }
}
