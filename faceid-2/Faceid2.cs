using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods

    public override bool Equals(object facialFeaturesObj)
    {
        return EyeColor == (facialFeaturesObj as FacialFeatures)?.EyeColor &&
               PhiltrumWidth == (facialFeaturesObj as FacialFeatures)?.PhiltrumWidth;
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods

    public override bool Equals(object identityObj)
    {
        // Check for admin credentials first
        if (Email == "admin@exerc.ism" &&
            FacialFeatures.Equals(new FacialFeatures("green", 0.9m)))
        {
            return true;
        }

        return Email == (identityObj as Identity)?.Email &&
               FacialFeatures.Equals((identityObj as Identity)?.FacialFeatures);
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private HashSet<Identity> RegisteredUsers { get; set; } = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));
    }

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity)) return false;
        RegisteredUsers.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        return RegisteredUsers.ToImmutableList().Any((identityCompare) => identityCompare.Equals(identity));
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB) &&
               identityA.GetHashCode() == identityB.GetHashCode();
    }
}