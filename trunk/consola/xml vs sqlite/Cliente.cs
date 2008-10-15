using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Cliente {
    private long _id;
    private string _nombre;
    private string _apellido;
    private List<Auto> _autos;

    public long Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public string Nombre {
        get {
            return _nombre;
        }
        set {
            _nombre = value;
        }
    }

    public string Apellido {
        get {
            return _apellido;
        }
        set {
            _apellido = value;
        }
    }
    public List<Auto> Autos {
        get {
            return _autos;
        }
        set {
            _autos = value;
        }
    }

    public override bool Equals(object obj)
    {
        return this.Id == ((Cliente)obj).Id;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }





}