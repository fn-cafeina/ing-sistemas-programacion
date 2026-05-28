class ProcesadorFinanciero
{
    public static T CalcularImpuesto<T>(T monto, double tasa) where T : struct
    {
        dynamic montoDinamico = monto;
        double porcentaje = tasa / 100.0;

        if (typeof(T) == typeof(decimal))
            return (T)(object)(montoDinamico * (decimal)porcentaje);

        if (typeof(T) == typeof(int))
            return (T)(object)(int)Math.Round(montoDinamico * porcentaje);

        return (T)(object)(montoDinamico * porcentaje);
    }
}
