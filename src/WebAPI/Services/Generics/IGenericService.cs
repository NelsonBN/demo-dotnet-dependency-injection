﻿namespace WebAPI.Services.Generics;

public interface IGenericService<TSource> where TSource : Transport
{
    string GetInstanceType(TSource source);
}
