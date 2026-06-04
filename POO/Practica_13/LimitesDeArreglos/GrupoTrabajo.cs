namespace LimitesDeArreglos;

public class GrupoTrabajo(int capacidad)
{
    public string[] Integrantes { get; set; } = new string[capacidad];
    public int Contador { get; set; } = 0;

    public void AgregarIntegrante(string nombre)
    {
        Integrantes[Contador] = nombre;
        Contador++;
    }
}
