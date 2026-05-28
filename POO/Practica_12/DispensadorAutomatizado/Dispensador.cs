class Dispensador<T> where T : Producto
{
    private List<T> _elementos = new List<T>();

    public void Agregar(T item)
    {
        _elementos.Add(item);
    }

    public bool Despachar(T item)
    {
        if (_elementos.Remove(item))
        {
            Console.WriteLine($"Despachando {item.Nombre}...");
            Console.WriteLine($"Tipo: {item.GetType().Name}");
            Console.WriteLine($"Precio: ${item.Precio}");
            Console.WriteLine("¡Producto despachado exitosamente!");
            return true;
        }
        return false;
    }

    public void MostrarInventario()
    {
        if (_elementos.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
            return;
        }
        for (int i = 0; i < _elementos.Count; i++)
            Console.WriteLine($"{i + 1}. {_elementos[i]}");
    }

    public List<T> Buscar(Predicate<T> condicion)
    {
        return _elementos.FindAll(condicion);
    }

    public int Contar()
    {
        return _elementos.Count;
    }

    public T ObtenerPorIndice(int indice)
    {
        return _elementos[indice];
    }
}
