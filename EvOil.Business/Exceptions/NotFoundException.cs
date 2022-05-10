// NotFoundException.cs
//
// © 2021 FESB. All rights reserved.

namespace EvOil.Business.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }
}