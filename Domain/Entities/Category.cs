﻿namespace MinimalVSA.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}