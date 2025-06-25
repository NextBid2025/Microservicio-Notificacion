namespace Notificacion.Domain.Expcetions;


using System;



/// <summary>
/// Excepción lanzada cuando un Value Object recibe un valor inválido.
/// </summary>
public class ValueObjectValidationException : Exception
{
    public ValueObjectValidationException(string mensaje) : base(mensaje) { }
}