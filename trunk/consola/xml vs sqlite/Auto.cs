using System;
using System.Collections.Generic;

public class Auto {
    private string _matricula;
    private string _marca;
    private string _modelo;

    public string Matricula {
        get {
            return _matricula;
        }
        set {
            _matricula = value;
        }
    }

    public string Marca {
        get {
            return _marca;
        }
        set {
            _marca = value;
        }
    }

    public string Modelo {
        get {
            return _modelo;
        }
        set {
            _modelo = value;
        }
    }

    public static Auto GenerarAutoAleatorio() {
        return null;
    }
    public override string ToString()
    {
        return Marca + Modelo + " ("+Matricula+")";
    }

}
