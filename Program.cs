using System;
using System.Collections.Generic;
public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj) => 
        ReferenceEquals(this, obj) || Equals(obj as FacialFeatures); // Verifica se os objetos são iguais

    public bool Equals(FacialFeatures otherF) => // sobrescreve o método equals para verificar se os parametros especificados são iguais
        otherF != null &&
        this.EyeColor == otherF.EyeColor &&
        this.PhiltrumWidth == otherF.PhiltrumWidth;

    public override int GetHashCode() => // combina o dois parametros e cria um HashCode de ambos unidos
        HashCode.Combine(this.EyeColor, this.PhiltrumWidth);
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

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) || Equals(obj as Identity);

    public bool Equals(Identity otherI) =>
        otherI != null &&
        this.Email == otherI.Email &&
        this.FacialFeatures.Equals(otherI.FacialFeatures);

    public override int GetHashCode() =>
        HashCode.Combine(this.Email, this.FacialFeatures);
}

public class Authenticator
{
    private static readonly Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)); // Seta como padrão o Administrador
    private HashSet<Identity> _registeredIdentities = new(); //Usamos HashSet ao invés de List pois retorna bool ao adicionar

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB); // Utilizamos o Equals que sobreescrevemos

    public bool IsAdmin(Identity identity) =>
        identity.Equals(_admin);


    public bool Register(Identity identity) =>
        _registeredIdentities.Add(identity); // Adiciona dentro do HashSet

    public bool IsRegistered(Identity identity) =>
        _registeredIdentities.Contains(identity); // Verifica se existe o identity dentro do HashSet

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}
