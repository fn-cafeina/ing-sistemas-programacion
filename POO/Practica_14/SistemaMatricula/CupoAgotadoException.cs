class CupoAgotadoException : Exception
{
    public CupoAgotadoException() { }

    public CupoAgotadoException(string message) : base(message) { }

    public CupoAgotadoException(string message, Exception inner) : base(message, inner) { }
}
