class CreditosInsuficientesException : Exception
{
    public CreditosInsuficientesException() { }

    public CreditosInsuficientesException(string message) : base(message) { }

    public CreditosInsuficientesException(string message, Exception inner) : base(message, inner) { }
}
